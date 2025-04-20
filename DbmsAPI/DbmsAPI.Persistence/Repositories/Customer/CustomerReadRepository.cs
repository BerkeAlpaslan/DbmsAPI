using Dapper;
using DbmsAPI.Application.Repositories.Customer;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
    {
        private readonly DbmsAPIDbContext _context;
        public CustomerReadRepository(DbmsAPIDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Customer> LoginCustomer (string username, string password)
        {
            string query = @"SELECT * FROM ""Customers"" WHERE ""Username"" = @Username AND ""Password"" = @Password";

            var parameters = new
            {
                Username = username,
                Password = password
            };

            using (var connection = _context.Database.GetDbConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    await connection.OpenAsync();

                var result = await connection.QueryFirstOrDefaultAsync<Domain.Entities.Customer>(query, parameters);

                if (result == null)
                    throw new Exception("Customer not found");

                return result;
            }
        }
    }
}
