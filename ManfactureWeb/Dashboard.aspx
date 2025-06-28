<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ManfactureWeb.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Dashboard Summary</h1>

    <div class="summary-box">
        <h3>Total Blankets</h3>
        <asp:Label ID="lblTotalBlankets" runat="server" Text="0"></asp:Label>
    </div>
    <div class="summary-box">
        <h3>Total Distributors</h3>
        <asp:Label ID="lblTotalDistributors" runat="server" Text="0"></asp:Label>
    </div>
</asp:Content>
