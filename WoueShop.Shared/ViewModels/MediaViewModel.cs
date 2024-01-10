using System.ComponentModel.DataAnnotations;

namespace WoueShop.Shared.ViewModels
{
    public class MediaViewModel
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        [MaxLength(150)]
        public string ContentType { get; set; } = string.Empty;
    }
}
