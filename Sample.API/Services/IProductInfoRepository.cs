using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Entities;

namespace Sample.API.Services
{
    public interface IProductInfoRepository
    {
        bool ProductModelExists(int modelId);
        IEnumerable<ProductModel> GetProductModels();
        ProductModel GetProductModel(int modelId, bool includeProducts);
        IEnumerable<Product> GetProductsForModel(int modelId);
        Product GetProductForModel(int modelId, int productId);
        void AddProductForModel(int modelId, Product product);
        bool Save();
    }
}
