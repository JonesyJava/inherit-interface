using System.ComponentModel.DataAnnotations;
using vacay.Interface;

namespace vacay.Models
{
    public class Vacation : IPurchasable
    {
        public int Id { get; set; }
        [Required]
        public string Destination { get; set; }

        [Required]
        public double? Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}