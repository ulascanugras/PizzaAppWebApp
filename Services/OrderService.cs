using PizzaAppWebApp.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PizzaAppWebApp.Services
{
    public class OrderService : IOrderService
    {
        HttpClient cli = new HttpClient();
        public bool Create(OrderDTO orderDTO)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            OrderDTO newdto = new()
            {
                AddressID = orderDTO.AddressID,
                CourierID = orderDTO.CourierID,
                CourierName = orderDTO.CourierName,
                Address = orderDTO.Address,
                OrderDate = orderDTO.OrderDate,
                ID = orderDTO.ID,
                UserID = orderDTO.UserID,
                NameOfUser = orderDTO.NameOfUser
            };

            string jsonStr = JsonConvert.SerializeObject(newdto); //Post

            var response = cli.PostAsync($"api/order", new StringContent(jsonStr, Encoding.UTF8, "text/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.DeleteAsync($"api/order/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public List<OrderDTO> GetAll()
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.GetAsync("api/order").Result;

            List<OrderDTO> dtos = new List<OrderDTO>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                dtos = JsonConvert.DeserializeObject<List<OrderDTO>>(result);
            }

            return dtos;
        }

        public OrderDTO GetById(int id)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.GetAsync($"api/order/{id}").Result;

            OrderDTO newdto = new();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                newdto = JsonConvert.DeserializeObject<OrderDTO>(result);
            }

            return newdto;
        }

        public List<OrderDTO> GetByUserId(int userId)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.GetAsync($"api/order/{userId}").Result;

            List<OrderDTO> dtos = new List<OrderDTO>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                dtos = JsonConvert.DeserializeObject<List<OrderDTO>>(result);
            }

            return dtos;
        }

        public bool Update(OrderDTO orderDTO)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            string jsonStr = JsonConvert.SerializeObject(orderDTO);

            var response = cli.PutAsync($"api/order", new StringContent(jsonStr, Encoding.UTF8, "text/json")).Result;

            OrderDTO newdto = new()
            {
                AddressID = orderDTO.AddressID,
                CourierID = orderDTO.CourierID,
                CourierName = orderDTO.CourierName,
                Address = orderDTO.Address,
                OrderDate = orderDTO.OrderDate,
                ID = orderDTO.ID,
                UserID = orderDTO.UserID,
                NameOfUser = orderDTO.NameOfUser
            };

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
