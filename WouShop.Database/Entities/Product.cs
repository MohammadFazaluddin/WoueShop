namespace WouShop.Database.Entities
{
    public class Product : BaseEntityModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int DiscountPercent { get; set; }

        public bool IsOurChoice { get; set; }

    }
}
