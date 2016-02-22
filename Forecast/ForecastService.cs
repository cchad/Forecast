namespace ForecastApp
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Net;

    using Newtonsoft.Json.Linq;

    #endregion

    public class ApiService
    {
        //private const string SunApiTemplate = "http://api.sunrise-sunset.org/json?lat=$LAT$.11594&lng=$LON$";

        private const string ForecastApiTemplate =
            "http://api.openweathermap.org/data/2.5/forecast/daily?q=$CITY$,us&mode=json&units=imperial&cnt=16&APPID=3f7a4b7a8e0ee394511f1dfbd1f4f31a ";

        private const string GoeNamesTemplate =
            "http://api.geonames.org/timezoneJSON?formatted=true&lat=$LAT$&lng=$LON$&username=cchadw";

        public ForecastDetails GetForecast(string city)
        {
            using (var client = new WebClient())
            {
                var url = ForecastApiTemplate.Replace("$CITY$", city);
                var result = GetJson(client, url);
                var forecast = new ForecastDetails
                                   {
                                       LocationName = result["city"]["name"].Value<string>(),
                                       DailyForecasts = new List<ForecastDetails.DailyTemps>()
                                   };
                var lat = result["city"]["coord"]["lat"].Value<string>();
                var lon = result["city"]["coord"]["lon"].Value<string>();
                var currentOffset = GetSunriseSunsetAndUtcOffset(ref forecast, lat, lon, client);
                GetDailyForecasts(forecast, result, currentOffset);

                return forecast;
            }
        }

        /// <summary>
        /// date time from weather service is UTC so we 
        /// need to adjust for local time zone -
        /// this service also provides sunrise and sunset so
        /// we're setting those here
        /// </summary>
        /// <param name="forecast"></param>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="client"></param>
        /// <returns>offset from UTC</returns>
        private int GetSunriseSunsetAndUtcOffset(ref ForecastDetails forecast, string lat, string lon, WebClient client)
        {
            var url = GoeNamesTemplate.Replace("$LAT$", lat).Replace("$LON$", lon);
            var result = GetJson(client, url);
            forecast.Sunrise = result["sunrise"].Value<DateTime>().ToShortTimeString();
            forecast.Sunset = result["sunset"].Value<DateTime>().ToShortTimeString();
            return result["gmtOffset"].Value<int>();
        }

        private static JObject GetJson(WebClient client, string url)
        {
            var result = client.DownloadString(url);
            return JObject.Parse(result);
        }

        private void GetDailyForecasts(ForecastDetails forecast, JObject o, int currentOffset)
        {
            for (var i = 0; i < 16; i++)
            {
                forecast.DailyForecasts.Add(
                    new ForecastDetails.DailyTemps
                        {
                            Date = DateTime.Today.AddDays(i).AddHours(currentOffset),
                            Morn = o["list"][i]["temp"]["morn"].Value<string>(),
                            Day = o["list"][i]["temp"]["day"].Value<string>(),
                            Eve = o["list"][i]["temp"]["eve"].Value<string>(),
                            Night = o["list"][i]["temp"]["night"].Value<string>(),
                            Min = o["list"][i]["temp"]["min"].Value<string>(),
                            Max = o["list"][i]["temp"]["max"].Value<string>()
                        });
            }
        }
    }
}