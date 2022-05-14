using PizzaAppWebApp.DTO;
using PizzaAppWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PizzaAppWebApp.Services
{
    public class UserService : IUserService
    {
        HttpClient cli = new HttpClient();

        public bool Create(UserDTO userDTO)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            UserDTO newdto = new()
            {
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                Mail = userDTO.Mail,
                Phone = userDTO.Phone,
                Name = userDTO.Name
            };

            string jsonStr = JsonConvert.SerializeObject(newdto); //Post

            var response = cli.PostAsync($"api/user", new StringContent(jsonStr, Encoding.UTF8, "text/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;            
            }

            return false;
        }

        public bool Delete(int id)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.DeleteAsync($"api/user/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public List<UserDTO> GetAll()
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.GetAsync("api/user").Result;

            List<UserDTO> dtos = new List<UserDTO>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                dtos = JsonConvert.DeserializeObject<List<UserDTO>>(result);
            }

            return dtos;
        }

        public UserDTO GetById(int id)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            var response = cli.GetAsync($"api/user/{id}").Result;

            UserDTO newdto = new();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                newdto = JsonConvert.DeserializeObject<UserDTO>(result);
            }

            return newdto;
        }

        public bool Update(UserDTO userDTO)
        {
            cli.BaseAddress = new Uri(Constants.APIUrl);

            string jsonStr = JsonConvert.SerializeObject(userDTO);

            var response = cli.PutAsync($"api/user", new StringContent(jsonStr, Encoding.UTF8, "text/json")).Result;

            UserDTO newdto = new()
            {
                ID = userDTO.ID,
                Name = userDTO.Name,
                Mail = userDTO.Mail,
                Phone = userDTO.Phone,
                UserName = userDTO.UserName,
                Password = userDTO.Password
            };

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
