using AutoMapper;
using Axado.Carriers.Application.Extensions;
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
    public class RateAppService : IRateAppService
    {
        private readonly IRateService service;
        private IUserService userService;
        private ICarrierService carrierService;

        public RateAppService(IRateService _service, IUserService _userService, ICarrierService _carrierService)
        {
            service = _service;
            userService = _userService;
            carrierService = _carrierService;
        }

        public virtual Result Add(RateViewModel obj)
        {
            try
            {
                var rate = service.GetByUserCarrier(obj.IdUser, obj.IdCarrier);

                if (rate != null)
                {
                    rate.Point = obj.Point;
                    service.Update(rate);
                }
                else
                {
                    rate = new Rate(obj.Point, userService.GetById(obj.IdUser), carrierService.GetById(obj.IdCarrier));
                    service.Add(rate);
                }

                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual Result Remove(int id)
        {
            try
            {
                service.Remove(service.GetById(id));
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public void Dispose()
        {
            service.Dispose();
        }

        public virtual Result<int> Count()
        {
            try
            {
                return Result.Ok(service.GetAll().Count());
            }
            catch (Exception e)
            {
                return Result.Fail<int>(e.Message);
            }
        }

        public virtual Result<IEnumerable<RateViewModel>> GetAll(int? skip = null, int? take = null, string sort = null, string search = null)
        {
            try
            {
                var query = service.GetAll();

                string property, orderBy;

                if (!string.IsNullOrEmpty(sort))
                {
                    property = sort.SplitSpace(0);
                    orderBy = sort.SplitSpace(1);

                    if (string.IsNullOrEmpty(orderBy))
                    {
                        query = query.OrderBy(i => i.GetPropertyFromString(property));
                    }
                    else
                    {
                        query = query.OrderByDescending(i => i.GetPropertyFromString(property));
                    }
                }

                if (skip.HasValue)
                {
                    query = query.Skip(skip.Value);
                }

                if (take.HasValue)
                {
                    query = query.Take(take.Value);
                }

                return Result.Ok(Mapper.Map<IEnumerable<Rate>, IEnumerable<RateViewModel>>(query));
            }
            catch (Exception e)
            {
                return Result.Fail<IEnumerable<RateViewModel>>(e.Message);
            }
        }

        public virtual Result<RateViewModel> GetById(int id)
        {
            try
            {
                return Result.Ok(Mapper.Map<Rate, RateViewModel>(service.GetById(id)));
            }
            catch (Exception)
            {
                return Result.Fail<RateViewModel>("Registro não localizado, verifique se o mesmo não foi excluído");
            }
        }

        public Result<IEnumerable<SelectListItem>> GetSelectList()
        {
            throw new NotImplementedException();
        }
    }
}
