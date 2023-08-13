using System.ComponentModel.DataAnnotations;

namespace WebTestAPI.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(255)]
        public string TenLoai { get; set; }
    }
}
