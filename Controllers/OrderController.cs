using Microsoft.AspNetCore.Mvc;
using PizzaAppWebApp.DTO;
using PizzaAppWebApp.Models;
using PizzaAppWebApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace PizzaAppWebApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            List<OrderViewModel> vmList = _orderService.GetAll().Select(x => new OrderViewModel()
            {
                ID = x.ID,
                Address = x.Address,
                AddressID = x.AddressID,
                CourierID = x.CourierID,
                CourierName = x.CourierName,
                NameOfUser = x.NameOfUser,
                OrderDate = x.OrderDate,
                UserID = x.UserID

            }).ToList();

            ViewBag.Courier = vmList;

            return View();
        }

        public IActionResult OrderOfUser(int userId)
        {
            List<OrderViewModel> vmList = _orderService.GetByUserId(userId).Select(x => new OrderViewModel()
            {
                ID = x.ID,
                Address = x.Address,
                AddressID = x.AddressID,
                CourierID = x.CourierID,
                CourierName = x.CourierName,
                NameOfUser = x.NameOfUser,
                OrderDate = x.OrderDate,
                UserID = x.UserID

            }).ToList();

            ViewBag.Courier = vmList;

            return View();
        }

        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var updateOrder = _orderService.GetById(id);

            OrderViewModel order = new OrderViewModel()
            {
                ID = updateOrder.ID,
                Address = updateOrder.Address,
                AddressID = updateOrder.AddressID,
                CourierID = updateOrder.CourierID,
                CourierName = updateOrder.CourierName,
                NameOfUser = updateOrder.NameOfUser,
                OrderDate = updateOrder.OrderDate,
                UserID = updateOrder.UserID
            };

            return View(order);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(OrderViewModel model)
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
                OrderDTO order = new OrderDTO()
                {
                    Address = model.Address,
                    AddressID = model.AddressID,
                    CourierID = model.CourierID,
                    CourierName = model.CourierName,
                    NameOfUser = model.NameOfUser,
                    OrderDate = model.OrderDate,
                    UserID = model.UserID
                };

                _orderService.Create(order);

                TempData["mesaj"] = "Başarıyla kaydedildi!";
                //}
            }
            else
            {
                OrderDTO order = new OrderDTO()
                {
                    ID = model.ID,
                    Address = model.Address,
                    AddressID = model.AddressID,
                    CourierID = model.CourierID,
                    CourierName = model.CourierName,
                    NameOfUser = model.NameOfUser,
                    OrderDate = model.OrderDate,
                    UserID = model.UserID
                };

                _orderService.Update(order);

                //TempData["mesaj"] = "Başarıyla güncellendi!";
            }

            return RedirectToAction("Index");
        }
    }
}
