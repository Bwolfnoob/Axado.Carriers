using Axado.Carriers.Application.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Axado.Carriers.Application.Interfaces
{
    public interface IBaseAppService<TEntity> where TEntity : class
    {
        Result Add<TViewModel>(TViewModel obj);
        Result<IEnumerable<TViewModel>> GetAll<TViewModel>(int? skip = null, int? take = null, string sort = null, string search = null) where TViewModel : class;
        Result<TViewModel> GetById<TViewModel>(int id);
        Result<int> Count();
        Result Update<TViewModel>(TViewModel obj);
        Result Remove<TViewModel>(int id);
        Result<IEnumerable<SelectListItem>> GetSelectList();
    }
}
