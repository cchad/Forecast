namespace ForecastApp
{
    #region imports

    using System;
    using System.Collections.Generic;

    #endregion

    public class ForecastDetails
    {
        public string LocationName { get; set; }

        public string Sunset { get; set; }

        public string Sunrise { get; set; }

        public List<DailyTemps> DailyForecasts { get; set; }

        public List<DailyTemps> GetDailyForecasts(string selectedCity)
        {
            return DailyForecasts;
        }

        public class DailyTemps
        {
            public DateTime Date { get; set; }

            public string Day { get; set; }

            public string Min { get; set; }

            public string Max { get; set; }

            public string Night { get; set; }

            public string Eve { get; set; }

            public string Morn { get; set; }
        }
    }
}