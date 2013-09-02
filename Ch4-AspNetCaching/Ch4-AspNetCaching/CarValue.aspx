<%@ Page Title="Car Value Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarValue.aspx.cs" Inherits="Ch4_AspNetCaching.CarValue" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Car Value</title>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Make: <asp:DropDownList ID="makeDropDown" runat="server" /></p>
    <p>Year: <asp:DropDownList ID="yearDropDown" runat="server" /></p>
    <p>Condition: <asp:DropDownList ID="conditionDropDown" runat="server" /></p>

    <asp:Button ID="getValueButton" Text="Get Value" runat="server" />
    <p>
        <strong>Value:</strong>
        <asp:Literal ID="valueLiteral" runat="server">
            Select Make, Year, Condition, and click "Get Value"
        </asp:Literal>
    </p>
    <p>Cache:</p>
    <asp:BulletedList ID="cachedItemsList" runat="server" />
</asp:Content>
