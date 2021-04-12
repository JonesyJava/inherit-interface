using vacay.Interface;

namespace vacay.Models
{
    public class Cruise : Vacation
    {
        public string Description { get; set; }
        public Cruise()
        {
            Category = "Cruise";
        }
    }
}