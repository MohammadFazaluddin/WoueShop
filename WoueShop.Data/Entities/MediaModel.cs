using System.ComponentModel.DataAnnotations;

namespace WouShop.Database.Entities
{
    public class MediaModel : BaseEntityModel
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        [MaxLength(150)]
        public string ContentType { get; set; } = string.Empty;
    }
}
