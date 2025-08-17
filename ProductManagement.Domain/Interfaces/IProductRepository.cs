using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<int> AddProduct(Product product);
        Task<Product?> GetProductById(Guid id);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(Guid id);
        Task<int> GetTotalCount();
        Task<IEnumerable<Product>> GetProducts(int pageNumber, int pageSize);
    }
}
