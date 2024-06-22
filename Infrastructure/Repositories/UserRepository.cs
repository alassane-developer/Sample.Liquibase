using Core.Contracts;
using Core.Entitties;
using Dapper;
using System.Data;

namespace Infrastructure.Repositories
{
    internal class UserRepository(IDbConnection Connection) : IUserRepository
    {
        private const string _table = "users";

        public async Task Add(User user)
        {
            var query = new QueryBuilder()
                .InsertInto(_table)
                .Values("@id", "@name", "@firstname", "@birthDate")
                .Build();
            await Connection.ExecuteAsync(query, new { user.Id, user.Name, user.FirstName, user.BirthDate });
        }

        public async Task Delete(Guid id)
        {
            var query = new QueryBuilder()
                .Delete()
                .From(_table)
                .Where("id = @id")
                .Build();
            await Connection.ExecuteAsync(query, new { id });
        }

        public async Task<User?> Get(string name)
        {
            var query = new QueryBuilder()
                .Select("*")
                .From(_table)
                .Where("name = @name")
                .Build();
            return await Connection.QueryFirstOrDefaultAsync<User>(query, new { name });
        }

        public async Task<User?> Get(Guid id)
        {
            var query = new QueryBuilder()
                .Select("*")
                .From(_table)
                .Where("id = @id")
                .Build();
            return await Connection.QueryFirstOrDefaultAsync<User>(query, new { id });
        }

        public async Task Update(User user)
        {
            var query = new QueryBuilder()
                .Update(_table)
                .Set("id = @id", "name = @name", "firstname = @firstname", "birthdate = @birthDate")
                .Where("id = @id")
                .Build();
            await Connection.ExecuteAsync(query, new { user.Id, user.Name, user.FirstName, user.BirthDate });
        }
    }
}
