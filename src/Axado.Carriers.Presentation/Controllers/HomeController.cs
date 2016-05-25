using Axado.Carriers.Application.Interfaces;
using Axado.Carriers.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Axado.Carriers.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private ICarrierAppService service;

        public HomeController(ICarrierAppService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            var context = Request.HttpContext;

            ViewBag.LoggedUserName = ((ClaimsIdentity)User.Identity).Name;

            var result = service.GetAll<CarrierViewModel>();

            return View(result.Value.ToList());
        }

    

        public IActionResult Error()
        {
            return View();
        }
    }
}
