using PizzaAppWebApp.DTO;
using System.Collections.Generic;

namespace PizzaAppWebApp.Services
{
    public interface ICourierService
    {
        List<CourierDTO> GetAll();
        CourierDTO GetById(int id);
        bool Delete(int id);
        bool Update(CourierDTO courierDTO);
        bool Create(CourierDTO courierDTO);
    }
}
