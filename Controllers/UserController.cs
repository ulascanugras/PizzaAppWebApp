using Microsoft.AspNetCore.Mvc;
using PizzaAppWebApp.DTO;
using PizzaAppWebApp.Models;
using PizzaAppWebApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace PizzaAppWebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<UserViewModel> vmList = _userService.GetAll().Select(x => new UserViewModel()
            {
                ID = x.ID,
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Mail = x.Mail,
                Phone = x.Phone
            }).ToList();

            ViewBag.Users = vmList;

            return View();
        }
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);

            return RedirectToAction("Index");
        }
        


        //public IActionResult Create()
        //{
        //    return View();
        //}
        //public IActionResult Update(int id)
        //{
        //    var updateUser = _userRepository.GetById(id);

        //    UserDto user = new UserDto()
        //    {
        //        ID = updateUser.ID,
        //        UserName = updateUser.UserName,
        //        Password = updateUser.Password,
        //        Name = updateUser.Name,
        //        Surname = updateUser.Surname,
        //        Email = updateUser.Email,
        //        Phone = updateUser.Phone
        //    };

        //    return View(user);
        //}

        //public IActionResult Save(UserDto model)
        //{
        //    if (model.ID == 0)
        //    {
        //        if (_userRepository.GetByName(model.Name) != null)
        //        {
        //            TempData["mesaj"] = "Bu eleman ürünlerde var!";
        //            return RedirectToAction("Create");
        //        }
        //        else
        //        {
        //            UserDto user = new UserDto()
        //            {
        //                ID = model.ID,
        //                UserName = model.UserName,
        //                Password = model.Password,
        //                Name = model.Name,
        //                Surname = model.Surname,
        //                Email = model.Email,
        //                Phone = model.Phone
        //            };

        //            _userRepository.InsertUser(user);

        //            TempData["mesaj"] = "Başarıyla kaydedildi!";
        //        }
        //    }
        //    else
        //    {
        //        UserDto user = new UserDto()
        //        {
        //            ID = model.ID,
        //            UserName = model.UserName,
        //            Password = model.Password,
        //            Name = model.Name,
        //            Surname = model.Surname,
        //            Email = model.Email,
        //            Phone = model.Phone
        //        };

        //        _userRepository.UpdateUser(user);


        //        TempData["mesaj"] = "Başarıyla güncellendi!";
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
