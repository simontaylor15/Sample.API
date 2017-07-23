using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Models;

namespace Sample.API
{
    public class ProductsDataStore
    {
        public static ProductsDataStore Current { get; } = new ProductsDataStore();

        public List<ProductModelDto> ProductModels { get; set; }

        private ProductsDataStore()
        {
            ProductModels = new List<ProductModelDto>()
            {
                new ProductModelDto()
                {
                    Id = 1,
                    Name = "Classic Vest",
                    CatalogDescription = "",
                    Products = new List<ProductDto>()
                    {
                        new ProductDto()
                        {
                            Id = 864,
                            Name = "Classic Vest, S",
                            ProductNumber = "VE-C304-S",
                            Colour = "Blue"
                        },
                        new ProductDto()
                        {
                            Id = 865,
                            Name = "Classic Vest, M",
                            ProductNumber = "VE-C304-S",
                            Colour = "Blue"
                        },
                        new ProductDto()
                        {
                            Id = 866,
                            Name = "Classic Vest, L",
                            ProductNumber = "VE-C304-S",
                            Colour = "Blue"
                        }
                    }
                },
                new ProductModelDto()
                {
                    Id = 2,
                    Name = "Cycling Cap",
                    CatalogDescription = "",
                    Products = new List<ProductDto>()
                    {
                        new ProductDto()
                        {
                        Id = 712,
                        Name = "AWC Logo Cap",
                        ProductNumber = "CA-1098",
                        Colour = "Multi"
                        },
                    }
                },
                new ProductModelDto()
                {
                    Id = 3,
                    Name = "Full-Finger Gloves",
                    CatalogDescription = "",
                    Products = new List<ProductDto>()
                    {
                        new ProductDto()
                        {
                            Id = 861,
                            Name = "Full-Finger Gloves, S",
                            ProductNumber = "GL-F110-S",
                            Colour = "Black"
                        },
                       new ProductDto()
                        {
                            Id = 862,
                            Name = "Full-Finger Gloves, M",
                            ProductNumber = "GL-F110-M",
                            Colour = "Black"
                        },
                        new ProductDto()
                        {
                            Id = 863,
                            Name = "Full-Finger Gloves, L",
                            ProductNumber = "GL-F110-L",
                            Colour = "Black"
                        },
                    }
                }  
            };
        }
    }
}