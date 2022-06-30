namespace BlazorLeafletMap
{
    public class MapOptions
    {
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public int ZoomLevel { get; private set; }

        public MapOptions WithLatitude(decimal latitude)
        {
            Latitude = latitude;
            return this;
        }

        public MapOptions WithLongitude(decimal longitude)
        {
            Longitude = longitude;
            return this;
        }

        public MapOptions WithZoomLevel(int zoomLevel)
        {
            ZoomLevel = zoomLevel;
            return this;
        }
    }
}
