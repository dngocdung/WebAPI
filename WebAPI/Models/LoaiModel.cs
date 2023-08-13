using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(255)]
        public string TenLoai { get; set; }
    }
}
