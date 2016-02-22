namespace ForecastApp
{
    #region imports

    using System;
    using System.Web.UI;

    #endregion

    public partial class Default : Page
    {
        protected void GetForecast(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(city.Text))
            {
                return;
            }
            Session["location"] = city.Text;
            Server.Transfer("Results.aspx");
        }
    }
}