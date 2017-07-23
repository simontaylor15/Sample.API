using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Models
{
    public class ProductModelWithoutProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
    }
}
