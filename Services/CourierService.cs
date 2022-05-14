using PizzaAppWebApp.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PizzaAppWebApp.Services
{
    public class CourierService : ICourierService
    {
        HttpClient cli = new HttpClient();
        public bool Create(CourierDTO courierDTO)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            CourierDTO newdto = new()
            {
                Name = courierDTO.Name,
                DateOfRecruitment = courierDTO.DateOfRecruitment,
                Mail = courierDTO.Mail,
                Phone = courierDTO.Phone
            };

            string jsonStr = JsonConvert.SerializeObject(newdto); //Post

            var response = cli.PostAsync($"api/courier", new StringContent(jsonStr, Encoding.UTF8, "text/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.DeleteAsync($"api/courier/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public List<CourierDTO> GetAll()
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.GetAsync("api/courier").Result;

            List<CourierDTO> dtos = new List<CourierDTO>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                dtos = JsonConvert.DeserializeObject<List<CourierDTO>>(result);
            }

            return dtos;
        }

        public CourierDTO GetById(int id)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.GetAsync($"api/courier/{id}").Result;

            CourierDTO newdto = new();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                newdto = JsonConvert.DeserializeObject<CourierDTO>(result);
            }

            return newdto;
        }

        public bool Update(CourierDTO courierDTO)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            string jsonStr = JsonConvert.SerializeObject(courierDTO);

            var response = cli.PutAsync($"api/user", new StringContent(jsonStr, Encoding.UTF8, "text/json")).Result;

            CourierDTO newdto = new()
            {
                ID = courierDTO.ID,
                Name = courierDTO.Name,
                Mail = courierDTO.Mail,
                Phone = courierDTO.Phone,
                DateOfRecruitment = courierDTO.DateOfRecruitment
            };

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
