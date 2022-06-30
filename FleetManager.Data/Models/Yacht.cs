namespace FleetManager.Data.Models
{
    public class Yacht
    {
        public int YachtId { get; set; }
        public string Name { get; set; }
        public int YearBuilt { get; set; }
        public string Make { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}