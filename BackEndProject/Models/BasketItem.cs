namespace BackEndProject.Models
{
    public class BasketItem
    {
        public int Id { get; set; }

        public string BasketId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}