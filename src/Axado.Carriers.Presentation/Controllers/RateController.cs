using Axado.Carriers.Application.Entities;
using Axado.Carriers.Application.Interfaces;
using Axado.Carriers.Application.ViewModels;
using Axado.Carriers.Presentation.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace Axado.Rates.Presentation.Controllers
{
    public class RateController : Controller
    {
        private IRateAppService service;
        private ICarrierAppService carrierService;

        public RateController(IRateAppService _service, ICarrierAppService _carrierService)
        {
            service = _service;
            carrierService = _carrierService;
        }
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;

            IList<Claim> claims = identity.Claims.ToList();

            ViewBag.LoggedUserName = identity.Name;
            ViewBag.LoggedUserId = claims[1].Value;


            var result = carrierService.GetAll<CarrierViewModel>();

            if (result.IsSuccess)
            {
                return View(result.Value);
            }
            else
            {
                return View(new List<CarrierViewModel>());
            }
        }

        [HttpPost]
        public IActionResult Rating([FromForm] RateViewModel Rate)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IList<Claim> claims = identity.Claims.ToList();

            Rate.IdUser = int.Parse(claims[1].Value.ToString());

            Result result = service.Add(Rate);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new HttpException(HttpStatusCode.BadRequest, result.Error);
            }
        }

    }
}
