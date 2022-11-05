namespace SuperMarket_Management_System1.Models
{
    public class Avail_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company_Name { get; set; }
        public int Quantity { get; set; }
        public DateTime Last_Purchase_Date { get; set; }
        public int Price { get; set; }
    }
}
