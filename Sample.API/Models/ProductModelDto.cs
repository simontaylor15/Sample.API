using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Models
{
    public class ProductModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public int NumberOfProducts
        {
            get
            {
                return Products.Count;
            }
        }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
