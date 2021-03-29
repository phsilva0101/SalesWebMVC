using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list =_sellerService.FindAll();
            return View(list);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // anotacion para determinar q é POST e nao GET
        [ValidateAntiForgeryToken] // prevenção de ataques CSRF, quando alguem aproveita a sessao de auth e envia dados maliciosos.
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

    }
}
