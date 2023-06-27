namespace App.Domain.Core.DtoModels.Orders
{
    public class OrderOutputDto
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int TotalPrice { get; set; }

        public bool IsPurchased { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
