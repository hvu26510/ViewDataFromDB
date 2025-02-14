using System.ComponentModel.DataAnnotations;

namespace ViewDataFromDB.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
