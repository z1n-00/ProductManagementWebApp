using Dapper;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts(int pageNumber, int pageSize)
        {
            var query = @"SELECT Id, Name, Price, CreatedDate
                        FROM Products
                        ORDER BY CreatedDate DESC
                        OFFSET @Offset ROWS
                        FETCH NEXT @PageSize ROWS ONLY;";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Product>(query, new
            {
                Offset = (pageNumber - 1) * pageSize,
                PageSize = pageSize
            });
        }

        public async Task<int> GetTotalCount()
        {
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Products;");
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = "SELECT * FROM Products ORDER BY CreatedDate DESC";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Product>(query);
        }

        public async Task<int> AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            product.CreatedDate = DateTime.Now;
            product.CreatedBy = "Admin";
            var query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, product);
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }

        public async Task<int> UpdateProduct(Product product)
        {
            product.ModifiedDate = DateTime.Now;
            product.ModifiedBy = "Admin";
            var query = "UPDATE Products SET Name=@Name, Price=@Price WHERE Id=@Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, product);
        }

        public async Task<int> DeleteProduct(Guid id)
        {
            var query = "DELETE FROM Products WHERE Id=@Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
