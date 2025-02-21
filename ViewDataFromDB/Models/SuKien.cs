using System.ComponentModel.DataAnnotations;

namespace ViewDataFromDB.Models
{
    public class SuKien
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Ten { get; set; }

        [Required]
        public DateTime NgayToChuc { get; set; }

        [Required]
        public string DiaDiem { get; set; }

        public ICollection<Ve> Ves { get; set; }
    }
}
