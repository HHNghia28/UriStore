using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.Interfaces;
using UriStore.Infrastructure.Services;

namespace UriStore.Infrastructure.Repositories
{
    public class Repository<T>(MongoDBService mongoDBService, string collectionName) : IRepository<T>
    {
        private readonly IMongoCollection<T> _collection = mongoDBService.GetCollection<T>(collectionName);

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync<Tkey>(Tkey id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }

        public async Task<T> GetByIdAsync<TKey>(TKey id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", entity.GetType().GetProperty("Id")?.GetValue(entity, null));
            var updateResult = await _collection.ReplaceOneAsync(filter, entity);

            if (updateResult.MatchedCount == 0)
            {
                throw new InvalidOperationException("Entity not found for update.");
            }
        }
    }

}
