using backend.Entities;

namespace backend.DTOs
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string Brandname { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; } = new ();
        public decimal DailyPrice { get; set; }
        public bool IsRentable { get; set; }
    }
}