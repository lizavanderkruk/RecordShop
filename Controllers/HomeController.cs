using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecordShop.Models;
using RecordShop.Repositories;

namespace RecordShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IProductenRepository _productenRepository; 

        public HomeController(ILogger<HomeController> logger, IProductenRepository productenRepository)
        {
            _logger = logger;
            _productenRepository = productenRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            var producten = _productenRepository.GetAllProducts();
            return View(producten);
        }

        public IActionResult Add()
        {
            return View(new ProductenModel());
        }

        [HttpPost]
        public IActionResult Add(ProductenModel productModel)
        {
            _productenRepository.AddNieuwProduct(productModel);
            return RedirectToAction("Products");
        }

        public IActionResult Update(int productID)
        {
            return View(_productenRepository.GetOneProduct(productID));
        }

        [HttpPost]
        public IActionResult Update(ProductenModel productModel)
        {
            _productenRepository.UpdateProduct(productModel);
            return RedirectToAction("Products");
        }

        public IActionResult Delete(int productID)
        {
            _productenRepository.DeleteProduct(productID);
            return RedirectToAction("Products");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
