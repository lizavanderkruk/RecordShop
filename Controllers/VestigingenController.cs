using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecordShop.Models;
using RecordShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Controllers
{
    public class VestigingenController : Controller
    {
        private readonly ILogger<VestigingenController> logger;
        private readonly IVestigingenRepository vestigingenRepository;

        public VestigingenController(ILogger<VestigingenController> logger, IVestigingenRepository vestigingenRepository)
        {
            this.logger = logger;
            this.vestigingenRepository = vestigingenRepository;
        }

        public IActionResult Vestigingen(int productID)
        {
            var vestigingen = vestigingenRepository.GetAllVestigingen(productID);
            return View(vestigingen); 
        }

        public IActionResult UpdateVoorraad(int vestigingID, int productID)
        {
            var vestigingen = vestigingenRepository.GetOneVestiging(vestigingID, productID);
            return View(vestigingen);
        }

        [HttpPost]
        public IActionResult UpdateVoorraad(VestigingenModel vestigingenModel)
        {
            vestigingenRepository.UpdateVoorraadvestiging(vestigingenModel);
            return RedirectToAction("Vestigingen", new { productID = vestigingenModel.ProductID });
        }
    }
}
