using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novir.Ecommerce.App.ViewModels;
using Novir.Ecommerce.Core.Models;
using Novir.Ecommerce.Core.Services.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.Ecommerce.App.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _jobService;
        readonly IMapper _mapper;
        public ProductController(IMapper mapper, IProductService jobService)
        {
            _jobService = jobService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int id)
        {
            var model = _mapper.Map<ProductViewModel>(await _jobService.GetById(id));
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (product.Id == 0)
                await _jobService.Add(_mapper.Map<ProductDto>(product));
            else
            if (product.Id == 0)
                await _jobService.Update(_mapper.Map<ProductDto>(product));
            return RedirectToAction("Index", new { id = product.Id });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = _mapper.Map<ProductViewModel>(await _jobService.GetById(id));
            return View("Create", model);
        }
    }
}
