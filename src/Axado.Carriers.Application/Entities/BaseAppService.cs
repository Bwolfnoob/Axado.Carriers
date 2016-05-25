using Axado.Carriers.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Axado.Carriers.Application.Extensions;
using Axado.Carriers.Domain.Interface.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Axado.Carriers.Application.Entities
{
    public class BaseAppService<TEntity> : IBaseAppService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> service;

        public BaseAppService(IBaseService<TEntity> _service)
        {
            service = _service;
        }

        public virtual Result Add<TViewModel>(TViewModel obj)
        {
            try
            {
                service.Add(Mapper.Map<TViewModel, TEntity>(obj));
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.InnerException == null ? e.Message : e.InnerException.Message);
            }
        }

        public virtual Result Update<TViewModel>(TViewModel obj)
        {
            try
            {
                var a = Mapper.Map<TViewModel, TEntity>(obj);
                service.Update(a);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual Result Remove<TViewModel>(int id)
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

        public virtual Result<IEnumerable<TViewModel>> GetAll<TViewModel>(int? skip = null, int? take = null, string sort = null, string search = null) where TViewModel : class
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

                return Result.Ok(Mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(query));
            }
            catch (Exception e)
            {
                return Result.Fail<IEnumerable<TViewModel>>(e.Message);
            }
        }

        public virtual Result<TViewModel> GetById<TViewModel>(int id)
        {
            try
            {
                return Result.Ok(Mapper.Map<TEntity, TViewModel>(service.GetById(id)));
            }
            catch (Exception)
            {
                return Result.Fail<TViewModel>("Registro não localizado, verifique se o mesmo não foi excluído");
            }
        }

        public virtual Result<IEnumerable<SelectListItem>> GetSelectList()
        {
            throw new NotImplementedException();
        }
    }
}
