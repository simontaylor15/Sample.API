using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Sample.API.Models;
using Sample.API.Entities;

namespace Sample.API.Services
{
    public class ProductsDataStore : IProductInfoRepository
    {
        //private static ProductsDataStore ProductStore { get; } = new ProductsDataStore();

        private List<ProductModel> _productModels = null;

        private List<ProductModel> ProductModels
        {
            get
            {
                if (_productModels == null)
                    InitialiseProductModels();
                return _productModels;
            }
        }

        public bool ProductModelExists(int modelId)
        {
            return ProductModels.Any(pm => pm.ProductModelId == modelId);
        }

        public IEnumerable<ProductModel> GetProductModels()
        {
            return ProductModels.ToList();
        }

        public ProductModel GetProductModel(int modelId, bool includeProducts)
        {
            return ProductModels.Where(pm => pm.ProductModelId == modelId).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsForModel(int modelId)
        {
            return GetProductModel(modelId, true).Products;
        }

        public Product GetProductForModel(int modelId, int productId)
        {
            return GetProductsForModel(modelId).Where(p => p.ProductId == productId).FirstOrDefault();
        }

        private void InitialiseProductModels()
        {
            _productModels = new List<ProductModel>()
            {
                new ProductModel()
                {
                    ProductModelId = 1,
                    Name = "Classic Vest",
                    CatalogDescription = "",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ProductId= 864,
                            Name = "Classic Vest, S",
                            ProductNumber = "VE-C304-S",
                            Color = "Blue",
                            ProductModelId = 1
                        },
                        new Product()
                        {
                            ProductId = 865,
                            Name = "Classic Vest, M",
                            ProductNumber = "VE-C304-S",
                            Color = "Blue",
                            ProductModelId = 1
                        },
                        new Product()
                        {
                            ProductId = 866,
                            Name = "Classic Vest, L",
                            ProductNumber = "VE-C304-S",
                            Color = "Blue",
                            ProductModelId = 1
                        }
                    }
                },
                new ProductModel()
                {
                    ProductModelId = 2,
                    Name = "Cycling Cap",
                    CatalogDescription = "",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ProductId = 712,
                            Name = "AWC Logo Cap",
                            ProductNumber = "CA-1098",
                            Color = "Multi",
                            ProductModelId = 2
                         },
                    }
                },
                new ProductModel()
                {
                    ProductModelId = 3,
                    Name = "Full-Finger Gloves",
                    CatalogDescription = "",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ProductId = 861,
                            Name = "Full-Finger Gloves, S",
                            ProductNumber = "GL-F110-S",
                            Color = "Black",
                            ProductModelId = 3
                        },
                        new Product()
                        {
                            ProductId = 862,
                            Name = "Full-Finger Gloves, M",
                            ProductNumber = "GL-F110-M",
                            Color = "Black",
                            ProductModelId = 3
                        },
                        new Product()
                        {
                            ProductId = 863,
                            Name = "Full-Finger Gloves, L",
                            ProductNumber = "GL-F110-L",
                            Color = "Black",
                            ProductModelId = 3
                        },
                    }
                }
            };
        }
    }
}