using Microsoft.AspNetCore.Mvc;
using PizzaAppWebApp.Models;
using PizzaAppWebApp.Services;
using PizzaAppWebApp.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PizzaAppWebApp.Controllers
{
    public class CourierController : Controller
    {
        private ICourierService _courierService;
        public CourierController(ICourierService courierService)
        {
            _courierService = courierService;
        }
        public IActionResult Index()
        {
            List<CourierViewModel> vmList = _courierService.GetAll().Select(x => new CourierViewModel()
            {
                ID = x.ID,
                DateOfRecruitment = x.DateOfRecruitment,
                Name = x.Name,
                Mail = x.Mail,
                Phone = x.Phone
            }).ToList();

            ViewBag.Courier = vmList;

            return View();
        }

        public IActionResult Delete(int id)
        {
            _courierService.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var updateCourier = _courierService.GetById(id);

            CourierViewModel user = new CourierViewModel()
            {
                ID = updateCourier.ID,
                Name = updateCourier.Name,
                Mail = updateCourier.Mail,
                Phone = updateCourier.Phone,
                DateOfRecruitment = updateCourier.DateOfRecruitment
            };

            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(CourierViewModel model)
        {
            if (model.ID == 0)
            {
                //if (_courierService.GetById(model.Name) != null)
                //{
                //    TempData["mesaj"] = "Bu eleman ürünlerde var!";
                //    return RedirectToAction("Create");
                //}
                //else
                //{
                    CourierDTO user = new CourierDTO()
                    {
                        Name = model.Name,
                        Mail = model.Mail,
                        Phone = model.Phone,
                        DateOfRecruitment = model.DateOfRecruitment
                    };

                    _courierService.Create(user);

                    TempData["mesaj"] = "Başarıyla kaydedildi!";
                //}
            }
            else
            {
                CourierDTO user = new CourierDTO()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Mail = model.Mail,
                    Phone = model.Phone,
                    DateOfRecruitment = model.DateOfRecruitment
                };

                _courierService.Update(user);

                //TempData["mesaj"] = "Başarıyla güncellendi!";
            }

            return RedirectToAction("Index");
        }
    }
}
