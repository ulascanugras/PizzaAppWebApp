using System;

namespace PizzaAppWebApp.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string NameOfUser { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressID { get; set; }
        public int CourierID { get; set; }
        public string Address { get; set; }
        public string CourierName { get; set; }
    }
}
