using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreMvcApplicationFirstWeek.Models;
using NetCoreMvcApplicationFirstWeek.Repositories;
using NetCoreMvcApplicationFirstWeek.ViewModels;

namespace NetCoreMvcApplicationFirstWeek.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        List<SelectListItem> brands = new List<SelectListItem>()
        {
               new SelectListItem("Merco", "1"),
               new SelectListItem("Bmw", "2"),
               new SelectListItem("Audi", "3"),
        };

        public ProductController(IHostingEnvironment hostingEnvironment, IProductRepository productRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }


        public IActionResult Create()
        {
            ProductCreateViewModel product = new ProductCreateViewModel();
            product.Brands = brands;

            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel p)
        {


            if (p.File.Length > 0)
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, @"images");
                var imagePath = Path.Combine(filePath, p.File.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    p.File.CopyToAsync(stream);
                    p.Product.Image = p.File.FileName;
                }
            }

            p.Product.BrandId = Convert.ToInt32(p.Brand);
            _productRepository.Create(p.Product);

            return RedirectToAction("Index");
        }
    }
}