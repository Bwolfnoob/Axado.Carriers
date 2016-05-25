using Axado.Carriers.Application.Entities;
using Axado.Carriers.Application.ViewModels;
using Axado.Carriers.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Axado.Carriers.Application.Interfaces
{
    public interface IRateAppService : IDisposable
    {
        Result Add(RateViewModel obj);
        Result<IEnumerable<RateViewModel>> GetAll(int? skip = null, int? take = null, string sort = null, string search = null);
        Result<RateViewModel> GetById(int id);
        Result<int> Count();
        Result Remove(int id);
        Result<IEnumerable<SelectListItem>> GetSelectList();
    }
}
