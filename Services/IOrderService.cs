using PizzaAppWebApp.DTO;
using System.Collections.Generic;

namespace PizzaAppWebApp.Services
{
    public interface IOrderService
    {
        List<OrderDTO> GetAll();
        List<OrderDTO> GetByUserId(int userId);
        OrderDTO GetById(int id);
        bool Delete(int id);
        bool Update(OrderDTO orderDTO);
        bool Create(OrderDTO orderDTO);
    }
}
