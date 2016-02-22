namespace Forecast
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    public class ForecastDetails
    {
        public string LocationName { get; set; }

        public string Sunset { get; set; }

        public string Sunrise { get; set; }

        public List<Temps> DailyForecasts { get; set; }

        public List<Temps> GetDailyForecasts(string selectedCity)
        {
            return DailyForecasts;
        }
   
    }
}