namespace vacay.Models
{
    public class Trip : Vacation
    {
        public string Description { get; set; }
        public Trip()
        {
            Category = "Trip";
        }
    }
}