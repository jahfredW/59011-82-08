namespace nppApplication.Models.Data
{
    public  partial class Reduction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
