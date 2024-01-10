namespace WouShop.Database.Entities
{
    public class Media : BaseEntityModel
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;
    }
}
