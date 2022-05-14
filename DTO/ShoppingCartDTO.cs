using System;

namespace PizzaAppWebApp.DTO
{
    public class ShoppingCartDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string NameOfUser { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
