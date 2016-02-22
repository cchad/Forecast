<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ForecastApp.Default"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>16 Day Forecast</h1>
        <p class="lead">
            <span style="margin-right: 5px;" >Enter City Name and State (&lt;city&gt;,&lt;state&gt;) or Zip Code</span>
            <asp:TextBox ID="city" runat="server" Width="132px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="forecastButton" runat="server" OnClick="GetForecast" Text="Get Forecast" Width="139px"/>
        </p>
    </div>
</asp:Content>