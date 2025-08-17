using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<(IEnumerable<Product> Products, int TotalCount)> GetProductsPaged(int pageNumber, int pageSize);
        Task AddProduct(Product product);
        Task<Product?> GetProductById(Guid id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
