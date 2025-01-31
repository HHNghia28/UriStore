using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using UriStore.Domain.Entities;
using UriStore.Infrastructure.Services;

namespace UriStore.Infrastructure.Repositories
{
    public class OrderRepository(MongoDBService mongoDBService) 
        : Repository<Order>(mongoDBService, "Orders"), IOrderRepository
    {
        private readonly IMongoCollection<Order> _ordersCollection = mongoDBService.GetCollection<Order>("Orders");

        public async Task<Order> GetOrder(long id)
        {
            var filter = Builders<Order>.Filter.Eq(o => o.Id, id);
            return await _ordersCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<PagedResponse<List<OrdersResponse>>> GetOrders(PagedRequest request)
        {
            var offset = (request.PageNumber - 1) * request.PageSize;

            var orders = await _ordersCollection
                .Find(FilterDefinition<Order>.Empty)
                .SortByDescending(o => o.LastModifiedAt)
                .Skip(offset)
                .Limit(request.PageSize)
                .ToListAsync();

            var totalRecords = await _ordersCollection.CountDocumentsAsync(FilterDefinition<Order>.Empty);

            var totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

            return new PagedResponse<List<OrdersResponse>>(
                orders.Select(o => new OrdersResponse
                {
                    Id = o.Id,
                    FullName = o.FullName,
                    Phone = o.Phone,
                    Address = o.Address,
                    TotalPrice = o.TotalPrice,
                    Status = o.Status,
                    LastModifiedAt = o.LastModifiedAt
                }).ToList(),
                request.PageNumber,
                request.PageSize,
                totalPages
            );
        }

        public async Task<PagedResponse<List<OrdersResponse>>> GetOrdersByUserId(PagedRequest request, Guid userId)
        {
            var offset = (request.PageNumber - 1) * request.PageSize;

            var filter = Builders<Order>.Filter.Eq(o => o.CreatedBy.Id, userId);

            var orders = await _ordersCollection
                .Find(filter)
                .SortByDescending(o => o.LastModifiedAt)
                .Skip(offset)
                .Limit(request.PageSize)
                .ToListAsync();

            var totalRecords = await _ordersCollection.CountDocumentsAsync(filter);

            var totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

            return new PagedResponse<List<OrdersResponse>>(
                orders.Select(o => new OrdersResponse
                {
                    Id = o.Id,
                    FullName = o.FullName,
                    Phone = o.Phone,
                    Address = o.Address,
                    TotalPrice = o.TotalPrice,
                    Status = o.Status,
                    LastModifiedAt = o.LastModifiedAt
                }).ToList(),
                request.PageNumber,
                request.PageSize,
                totalPages
            );
        }
    }
}
