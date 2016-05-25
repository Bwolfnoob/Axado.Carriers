using System;
using System.Linq;
using Axado.Carriers.Presentation.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Axado.Carriers.Application.Interfaces;
using Axado.Carriers.Application.ViewModels;
using Axado.Carriers.Application.Entities;
using System.Security.Claims;

namespace Axado.Carriers.Presentation.Controllers
{
    public class UserController : Controller
    {
        private IUserAppService service;

        public UserController(IUserAppService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            var context = Request.HttpContext;
            ViewBag.LoggedUserName = ((ClaimsIdentity)User.Identity).Name;

            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdate([FromForm] UserViewModel _user)
        {
            Result result;

            if (_user.Id > 0)
            {
                result = service.Update(_user);
            }
            else
            {
                result = service.Add(_user);
            }

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", result.Error);
                return View("_Form", _user);
            }
        }

        public IActionResult Add()
        {
            return View("_form", new UserViewModel());
        }

        public IActionResult Edit(int id)
        {
            return View("_form", service.GetById<UserViewModel>(id).Value);
        }

        public IActionResult Delete(int id)
        {
            var result = service.Remove<UserViewModel>(id);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new HttpException(HttpStatusCode.BadRequest, result.Error);
            }
        }

        public JsonResult Load(DTParameters param)
        {
            try
            {
                var registers = service.GetAll<UserViewModel>(param.Start,
                    param.Length,
                    param.SortOrder,
                    param.Search.Value).Value
                    .ToList();

                var returnResult = new
                {
                    recordsTotal = service.Count().Value,
                    recordsFiltered = service.Count().Value,
                    data = from c in registers
                           select new
                           {
                               c.Name,
                               c.Email,
                               btn = string.Format("<a class='btn btn-sm btn-primary' style='margin-right: 5px' href='/User/Edit/{0}' title='Editar'><i class='glyphicon glyphicon-pencil' style='margin-right: 5px'></i>Editar</a><a class='btn btn-sm btn-danger' href='/User/Delete/{0}' title='Remover'><i class='glyphicon glyphicon-trash' style='margin-right: 5px'></i>Remover</a>", c.Id)
                           }
                };

                return Json(returnResult);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }
    }
}
