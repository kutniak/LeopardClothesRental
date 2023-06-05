using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace TrialLoginAndRegistrationWeb.Models
{
    public class Clothes
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Clothes_ID { get; set; }
        public string Name { get; set; }
        public string Categories { get; set; }
        public string SubCategories { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public byte[] Foto { get; set; } //+++
        public string FotoBase64 { get { return Foto != null ? "data:image;base64," + Convert.ToBase64String(Foto) : null; } }
        
    }
}
