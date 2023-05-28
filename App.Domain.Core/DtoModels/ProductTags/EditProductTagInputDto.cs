namespace App.Domain.Core.DtoModels.ProductTags
{
    public class EditProductTagInputDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int TagId { get; set; }
    }
}
