namespace WeatherApp
{
    public class Weather
    {
        public string Place { get; set; }
        public string Altitude { get; set; }
        public string DateString { get; set; }
        public string TimeString { get; set; }
        public string Humidity { get; set; }
        public string TemperatureCelcius { get; set; }
        public double  WindDirection { get; set; }
        public string UV { get; set; }

        public Weather()
        {
            //Because labels bind to these values, set them to an empty string to
            //ensure that the label appears on all platforms by default.
            this.Place = " ";
            this.Altitude = " ";
            this.DateString = " ";
            this.Humidity = " ";
            this.TimeString = " ";
            this.Humidity = " ";
            this.TemperatureCelcius = " ";
            this.WindDirection = 0;
            this.UV = " ";
        }
    }
}