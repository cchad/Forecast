namespace Forecast
{
    using System;

    public class DailyTemps
    {   
        public DateTime Date { get; set; }

        public string Day { get; set; }
        
        public string Min { get; set; }

        public string Max { get; set; }

        public string Night { get; set; }

        public string Eve { get; set; }

        public string Morn { get; set; }

        public string Color { get; set; }
    }
}