using nppApplication.Models.Data;

namespace nppApplication.Models.DTO
{
    public partial class ReductionsDTO
    {
        public string Name { get; set; }

        public virtual ICollection<OrderDTOWithoutOrderLineAndUser> Orders { get; set; } = new List<OrderDTOWithoutOrderLineAndUser>();
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
