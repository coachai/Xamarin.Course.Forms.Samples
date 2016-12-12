using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Model
    {
        private DataService dataService;

        public Model(DataService dataService)
        {
            this.dataService = dataService;
        }

        public async Task<Weather> GetWeather()
        {
            //Currently we are always using Copenhagen as reference. In a real live scenario, we would use dependency injection to inject the native GPS service into
            //this class in order to get the proper latitude and longitude

            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "334697e46cd896224b89789b9786eb9b";
            string latitude = "55.676098";
            string longitude = "12.5683";

            string queryString = "http://api.openweathermap.org/data/2.5/weather?lat="
                + latitude + "&lon=" + longitude + "&units=metric&appid=" + key;

            var results = await dataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Place = (string)results["name"];
                weather.Altitude = "??"; //have not yet figured out how to retrieve the altitude


                //parsing date/time
                var timeUnixEpochString = (string)results["dt"];
                double timeUnixEpochDouble;
                var unixEpochParsedOk = Double.TryParse(timeUnixEpochString, out timeUnixEpochDouble);
                if (unixEpochParsedOk)
                {
                    DateTime localtime = UnixTimestampToDateTime(timeUnixEpochDouble);
                    weather.DateString = localtime.ToString("dddd, MMMM d");
                    weather.TimeString = localtime.ToString("HH:mm");
                }

                weather.Humidity = (string)results["main"]["humidity"];

                weather.TemperatureCelcius = (string)results["main"]["temp"];
                
                //parsing winddirection
                var windDirectionString = (string)results["wind"]["deg"];
                double windDirectionDouble;
                var windParsedOk = Double.TryParse(windDirectionString, out windDirectionDouble);
                if (windParsedOk)
                {
                    weather.WindDirection = windDirectionDouble;
                }
                return weather;
            }
            else
            {
                return null;
            }
        }

        public static DateTime UnixTimestampToDateTime(double unixTime)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            var utcDateTime = new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
            //Now add an hour to get danish time, as Unix time in UTC
            return utcDateTime.AddHours(1); //note that this should normally be done in a valueconverter, so that the model is not poluted with local data.
        }
    }
}