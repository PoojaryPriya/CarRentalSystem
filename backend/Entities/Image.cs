using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public int CarDId { get; set; }
        public CarsClass CarsClass{ get; set; }
    }
}