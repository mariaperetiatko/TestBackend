using System.ComponentModel.DataAnnotations;

namespace TestBackend.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.1, double.MaxValue)]
        public double Cost { get; set; }
        [Range(0.1, double.MaxValue)]
        public double CaloricValue { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
    }
}
