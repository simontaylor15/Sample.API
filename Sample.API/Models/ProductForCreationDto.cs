using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Models
{
    public class ProductForCreationDto
    { 
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Colour { get; set; }
    }
}
