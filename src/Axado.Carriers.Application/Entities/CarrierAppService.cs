using AutoMapper;
using Axado.Carriers.Application.Interfaces;
using Axado.Carriers.Application.ViewModels;
using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Axado.Carriers.Application.Entities
{
    public class CarrierAppService : BaseAppService<Carrier>, ICarrierAppService
    {
        private readonly ICarrierService service;

        public CarrierAppService(ICarrierService _service)
            : base(_service)
        {
            service = _service;
        }

        public override Result<IEnumerable<SelectListItem>> GetSelectList()
        {
            try
            {
                return Result.Ok(service.GetAll().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            }
            catch (Exception e)
            {
                return Result.Fail<IEnumerable<SelectListItem>>(e.Message);
            }
        }
    }
}
