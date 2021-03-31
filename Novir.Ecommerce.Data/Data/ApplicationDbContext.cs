using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Novir.Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.Ecommerce.App.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
