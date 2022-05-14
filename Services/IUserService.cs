using PizzaAppWebApp.DTO;
using System.Collections.Generic;

namespace PizzaAppWebApp.Services
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO GetById(int id);
        bool Delete(int id);
        bool Update(UserDTO userDTO);
        bool Create(UserDTO userDTO);
    }
}
