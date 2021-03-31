using Microsoft.EntityFrameworkCore;
using Novir.Ecommerce.App.Data.Data;
using Novir.Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.Ecommerce.Data.Repositories
{
    public class ProductRepository : CommonRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
