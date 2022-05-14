namespace PizzaProje_WebApp.DTO
{
    public class OrderDetailDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public int DoughTypeID { get; set; }
        public string DoughTypeName { get; set; }
        public int Number { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
