namespace App.Domain.Core.DtoModels.Commisions
{
    public class AddCommissionInputDto
    {
        public int OrderId { get; set; }

        public int CommissionAmount { get; set; }
    }
}
