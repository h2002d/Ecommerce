using AutoMapper;
using Novir.Ecommerce.Core.Models;
using Novir.Ecommerce.Data.Entities;
using Novir.Ecommerce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.Ecommerce.Core.Services.Jobs
{
    public class ProductService : CommonService<ProductEntity, ProductDto>, IProductService
    {
        public ProductService(IMapper mapper, IProductRepository commonRepository) : base(mapper, commonRepository)
        {
        }
    }
}
