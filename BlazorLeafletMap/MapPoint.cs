namespace BlazorLeafletMap
{
    public class MapPoint
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Radius { get; set; }
        public string? TooltipText { get; set; }
    }
}
