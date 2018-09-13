namespace LatestBlazor.APIs
{
    public struct BasicLatLon
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public BasicLatLon(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
}
