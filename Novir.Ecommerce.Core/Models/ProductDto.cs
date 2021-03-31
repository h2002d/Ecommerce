using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.Ecommerce.Core.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
    }
}
