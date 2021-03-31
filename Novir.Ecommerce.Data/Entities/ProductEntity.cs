using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.Ecommerce.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
    }
}
