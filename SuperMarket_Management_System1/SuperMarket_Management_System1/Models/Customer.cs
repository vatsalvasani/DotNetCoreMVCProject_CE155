namespace SuperMarket_Management_System1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Customer_Name { get; set; }
        public string Type { get; set; }
        public int Last_Purchase { get; set; }
        public int Total_Purchase { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
