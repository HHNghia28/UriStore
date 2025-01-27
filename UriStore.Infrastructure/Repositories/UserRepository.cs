using Dapper;
using UriStore.Application.DTO;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using UriStore.Domain;
using UriStore.Domain.Entities;
using UriStore.Infrastructure.Context;
using UriStore.Domain.Shares;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext _context, ISqlConnectionFactory _sqlConnectionFactory)
        : Repository<User>(_context), IUserRepository
    {
        public async Task<bool> ChangePassword(Guid userId, string newHashPassword)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return false;

            user.PasswordHash = newHashPassword;

            return true;
        }

        public async Task<bool> ConfirmEmail(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return false;

            user.IsEmailConfirmed = true;

            return true;
        }

        public async Task<bool> IsVerifyCode(Guid userId, string code)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return false;

            var confirm = await _context.EmailConfirmationTokens
                .FirstOrDefaultAsync(e => e.UserId == userId && e.Token.Equals(code) && e.ExpirationDate >= DateUtility.GetCurrentDateTime());

            return confirm != null;
        }

        public async Task<string> GenerateCodeConfirmEmail(Guid userId)
        {
            string code = Util.Generate6DigitCode();

            await _context.EmailConfirmationTokens.AddAsync(new EmailConfirmationToken
            {
                Id = Guid.NewGuid(),
                ExpirationDate = DateUtility.GetCurrentDateTime().AddMinutes(5),
                Token = code,
                UserId = userId
            });

            return code;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<bool> UpdateUser(User u)
        {
            var user = await _context.Users.FindAsync(u.Id);

            if (user == null) return false;

            user.FullName = u.FullName;
            user.Phone = u.Phone;
            user.Address = u.Address;
            user.Email = u.Email;
            user.RoleId = u.RoleId;

            return true;
        }

        public async Task<bool> SaveRefreshToken(Guid userId, string refreshToken, DateTime ExpirationDate)
        {
            await _context.RefreshTokens.AddAsync(new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = refreshToken,
                ExpirationDate = ExpirationDate,
                UserId = userId
            });

            return true;
        }

        public async Task<User> GetUserByRefreshToken(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .Include(t => t.User)
                .ThenInclude(t => t.Role)
                .FirstOrDefaultAsync(t => t.Token.ToLower().Equals(refreshToken.ToLower()) 
                && t.ExpirationDate >= DateUtility.GetCurrentDateTime());

            return token?.User;
        }

        public async Task<bool> ChangeIsDeletedUser(Guid userId, bool isDeleted)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return false;

            user.IsDeleted = isDeleted;

            return true;
        }

        public async Task<PagedResponse<List<UserListResponse>>> GetUsers(PagedRequest request)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                const string sqlUsers = @"
                    SELECT 
                        ""Users"".""Id"",
                        ""Users"".""FullName"",
                        ""Users"".""Email"",
                        ""Roles"".""Name"" AS ""Role""
                    FROM ""Users""
                    INNER JOIN ""Roles"" ON ""Users"".""RoleId"" = ""Roles"".""Id""
                    WHERE ""Users"".""IsDeleted"" = false
                    ORDER BY ""Users"".""FullName""
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var offset = (request.PageNumber - 1) * request.PageSize;
                var users = await connection.QueryAsync<UserListResponse>(sqlUsers, new { Offset = offset, PageSize = request.PageSize });

                const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Users""
                    INNER JOIN ""Roles"" ON ""Users"".""RoleId"" = ""Roles"".""Id""";

                var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

                var response = new PagedResponse<List<UserListResponse>>(
                    users.AsList(),
                    request.PageNumber,
                    request.PageSize,
                    (int)Math.Ceiling((double)totalRecords / request.PageSize)
                );

                return response;
            }
        }

        public async Task<UserResponse> GetUser(Guid id)
        {
            using (var connection = _sqlConnectionFactory.GetOpenConnection())
            {
                const string sqlUsers = @"
                    SELECT 
                        ""Users"".""Id"",
                        ""Users"".""FullName"",
                        ""Users"".""Email"",
                        ""Users"".""Phone"",
                        ""Users"".""Address"",
                        ""Users"".""IsEmailConfirmed"",
                        ""Users"".""IsDeleted"",
                        ""Users"".""RoleId"",
                        ""Roles"".""Name"" AS ""Role""
                    FROM ""Users""
                    INNER JOIN ""Roles"" ON ""Users"".""RoleId"" = ""Roles"".""Id""
                    WHERE ""Users"".""Id"" = @Id";

                var user = await connection.QueryFirstOrDefaultAsync<UserResponse>(sqlUsers, new { Id = id });

                if (user == null)
                {
                    throw new NotFoundException("User not found");
                }

                return user;
            }
        }
    }
}
