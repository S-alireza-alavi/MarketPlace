namespace App.Domain.Core.DtoModels.OrderItems
{
    public class AddOrderItemInputDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }
}
