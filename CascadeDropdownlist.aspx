<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CascadeDropdownlist.aspx.cs" Inherits="GridViewWebApp.CascadeDropdownlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="ContinentLabel" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Continents"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ContinentsDropDownList" runat="server"  
                DataTextField="ContinentName" DataValueField="ContinentId" Font-Size="XX-Large" Width="379px" OnSelectedIndexChanged="ContinentsDropDownList_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>

            <br />
            <br />
            <br />

            <asp:Label ID="CountriesLabel" runat="server" DataTextField="CountryName" DataValueField="CountryId" Font-Bold="True" Font-Size="XX-Large" Text="Countries"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="CountriesDropDownList" DataTextField="CountryName" DataValueField="CountryId" AutoPostBack="true"
                runat="server" Font-Size="XX-Large" Width="302px" OnSelectedIndexChanged="CountriesDropDownList_SelectedIndexChanged" >
            </asp:DropDownList>

            <br />
            <br />
            <br />

            <asp:Label ID="CitiesLabel" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Cities"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="CitiesDropDownList" runat="server" DataTextField="CityName" DataValueField="CityId" Font-Size="XX-Large" Width="309px">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
