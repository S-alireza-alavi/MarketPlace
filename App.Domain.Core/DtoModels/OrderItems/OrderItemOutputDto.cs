namespace App.Domain.Core.DtoModels.OrderItems
{
    public class OrderItemOutputDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
