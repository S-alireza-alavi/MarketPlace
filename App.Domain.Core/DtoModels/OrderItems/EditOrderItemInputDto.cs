namespace App.Domain.Core.DtoModels.OrderItems
{
    public class EditOrderItemInputDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }
}
