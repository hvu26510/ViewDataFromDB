using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ViewDataFromDB.Models
{
    public class Ve
    {
        [Key]
        public int MaVe { get; set; }

        [Required]
        public string LoaiVe { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaVe { get; set; }

        [ForeignKey("SuKien")]
        public int? MaSuKien { get; set; }

        public SuKien? SuKien { get; set; }
    }
}
