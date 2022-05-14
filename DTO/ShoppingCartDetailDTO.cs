namespace PizzaAppWebApp.DTO
{
    public class ShoppingCartDetailDTO
    {
        public int ID { get; set; }
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public int Number { get; set; }
        public int ShoppingCartID { get; set; }
        public int DoughTypeID { get; set; }
        public string DoughTypeName { get; set; }
    }
}
