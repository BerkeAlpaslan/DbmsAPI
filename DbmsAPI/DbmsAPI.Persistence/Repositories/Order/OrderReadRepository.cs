using Dapper;
using DbmsAPI.Application.Repositories.Order;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
    {
        private readonly DbmsAPIDbContext _context;
        public OrderReadRepository(DbmsAPIDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Order>> GetOrderDetailsForCustomer(string id)
        {
            var query = @"
                        SELECT *
                        FROM ""Orders""
                        NATURAL JOIN ""ProductOrder""
                        NATURAL JOIN ""Products""
                        WHERE ""Orders"".""CustomerId"" = @CustomerId;";

            var parameters = new
            {
                CustomerId = Guid.Parse(id)
            };

            using (var connection = _context.Database.GetDbConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var result = (await connection.QueryAsync<Domain.Entities.Order>(query, parameters)).ToList();

                if (result == null)
                    throw new Exception("Orders not found");

                return result;
            }
        }
    }
}
