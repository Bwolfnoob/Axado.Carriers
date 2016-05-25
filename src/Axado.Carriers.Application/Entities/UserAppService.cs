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
    public class UserAppService : BaseAppService<User>, IUserAppService
    {
        private readonly IUserService service;

        public UserAppService(IUserService _service)
            : base(_service)
        {
            service = _service;
        }

        public UserViewModel Login(LoginViewModel usuario)
        {
            return Mapper.Map<UserViewModel>(service.LoginVerify(usuario.Name, usuario.Password));
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
