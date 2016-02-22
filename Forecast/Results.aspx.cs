namespace ForecastApp
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    #endregion

    public partial class Results : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["location"] != null)
            {
                var apiService = new ApiService();
                var location = Session["location"].ToString();
                var fcast = apiService.GetForecast(location);
                Location.Text = fcast.LocationName;
                LocationSunset.Text = fcast.Sunset;
                LocationSunrise.Text = fcast.Sunrise;
                Repeater1.DataSource = fcast.DailyForecasts;
                Repeater1.DataBind();
                forecast.Visible = true;
            }
        }

        protected void Repeater1OnDataBinding(object sender, EventArgs e)
        {
            Repeater1.DataSource = ((List<ForecastDetails.DailyTemps>)Repeater1.DataSource).OrderBy(o => o.Date);
        }
    }
}