using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.Ecommerce.App.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }

    }
}
