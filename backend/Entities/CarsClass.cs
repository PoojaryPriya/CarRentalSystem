using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class CarsClass
    {
        [Key]
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsRentable { get; set; }
        public List<Image> Images { get; set; } = new ();
    }
}