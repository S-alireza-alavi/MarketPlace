namespace App.Domain.Core.DtoModels.Commisions
{
    public class EditCommissionInputDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int CommissionAmount { get; set; }
    }
}
