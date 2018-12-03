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

        ProductRepository productRepository = new ProductRepository();
        private readonly IHostingEnvironment _hostingEnvironment;

        List<SelectListItem> brands = new List<SelectListItem>()
        {
               new SelectListItem("1", "Merco"),
               new SelectListItem("2", "Bmw"),
               new SelectListItem("3", "Audi"),
        };
        public ProductController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var products = productRepository.GetAll();
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
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    p.File.CopyToAsync(stream);
                    p.Product.Image = p.File.FileName;
                }
            }

            productRepository.Create(p.Product);

            return RedirectToAction("Index");
        }
    }
}