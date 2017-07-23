using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Entities;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Sample.API.Services
{
    public class ProductInfoRepository : IProductInfoRepository
    {
        private ProductInfoContext _context;

        public bool ProductModelExists(int modelId)
        {
            return _context.ProductModels.Any(pm => pm.ProductModelId == modelId);
        }

        public ProductInfoRepository(ProductInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductModel> GetProductModels()
        {
            return _context.ProductModels.ToList();
        }

        public ProductModel GetProductModel(int modelId, bool includeProducts)
        {
            if (includeProducts)
            {
                return _context.ProductModels.Include(pm => pm.Products).Where(pm => pm.ProductModelId == modelId).FirstOrDefault();
            }
            else
            {
                return _context.ProductModels.Where(pm => pm.ProductModelId == modelId).FirstOrDefault();
            }
        }

        public IEnumerable<Product> GetProductsForModel(int modelId)
        {
            return _context.Products.Where(p => p.ProductModelId == modelId).ToList();
        }

        public Product GetProductForModel(int modelId, int productId)
        {
            return _context.Products.Where(p => p.ProductId == productId && p.ProductModelId == modelId).FirstOrDefault();
        }
    }
}
