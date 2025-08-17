using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<(IEnumerable<Product> Products, int TotalCount)> GetProductsPaged(int pageNumber, int pageSize)
        {
            var products = await _productRepo.GetProducts(pageNumber, pageSize);
            var totalCount = await _productRepo.GetTotalCount();
            return (products, totalCount);
        }

        public Task AddProduct(Product product) => _productRepo.AddProduct(product);
        public Task<Product?> GetProductById(Guid id) => _productRepo.GetProductById(id);
        public Task UpdateProduct(Product product) => _productRepo.UpdateProduct(product);
        public Task DeleteProduct(Guid id) => _productRepo.DeleteProduct(id);
    }
}
