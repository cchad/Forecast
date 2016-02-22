<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Results.aspx.cs" Inherits="ForecastApp.Results" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" id="forecast" runat="server" style="margin-top: 10px;">
        <div >
            <table runat="server">
                <tr runat="server">
                    <td style="font-weight: bold">City:</td>
                    <td runat="server">
                        <asp:Literal runat="server" id="Location"></asp:Literal>
                    </td>
                </tr>
                <tr runat="server">
                    <td style="font-weight: bold">Sunrise:</td>
                    <td runat="server">
                        <asp:Literal runat="server" id="LocationSunrise"></asp:Literal>
                    </td>
                </tr>
                <tr runat="server">
                    <td style="font-weight: bold">Sunset:</td>
                    <td runat="server">
                        <asp:Literal runat="server" id="LocationSunset"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <div >

            <asp:Repeater ID="Repeater1" runat="server" OnDataBinding="Repeater1OnDataBinding">
                <HeaderTemplate>

                    <div class="hd1">Date</div>
                    <div class="hd">Morning</div>
                    <div class="hd">Day</div>
                    <div class="hd">Evening</div>
                    <div class="hd">Night</div>
                    <div class="hd">Min</div>
                    <div class="hd">Max</div>

                </HeaderTemplate>
                <ItemTemplate>
                    <div data-color="Color">
                        <div runat="server" class="col1">
                            <%# Eval("Date", "{0:dddd, MMMM d, yyyy}") %>
                        </div>
                        <div runat="server" class="col">
                            <%# Eval("Morn") %>
                        </div>
                        <div runat="server" class="col">
                            <%# Eval("Day") %>
                        </div>
                        <div runat="server" class="col">
                            <%# Eval("Eve") %>
                        </div>
                        <div runat="server" class="col">
                            <%# Eval("Night") %>
                        </div>
                        <div runat="server" class="col">
                            <%# Eval("Min") %>
                        </div>
                        <div runat="server" class="col">
                            <%# Eval("max") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        <div style="clear: both; margin-left: 5px;">
            <a style="height: 40px; padding: 2px 2px 2px 2px; width: 60px;" class="btn-primary" href="Default.aspx"><<</a>
        </div>
    </div>
    <script src="Scripts/forecast.js"></script>
</asp:Content>