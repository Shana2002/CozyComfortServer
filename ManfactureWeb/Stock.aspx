<%@ Page Title="Stock" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="ManfactureWeb.Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Blanket Stock</h1>
    <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="BlanketId" HeaderText="ID" />
            <asp:BoundField DataField="BlanketName" HeaderText="Blanket" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity in Stock" />
        </Columns>
    </asp:GridView>

    <h3>Add to Stock</h3>
    <asp:DropDownList ID="ddlBlanket" runat="server" />
    <asp:TextBox ID="txtStockQty" runat="server" Placeholder="Quantity" />
    <asp:Button ID="btnAddStock" runat="server" Text="Add to Stock" OnClick="btnAddStock_Click" />
</asp:Content>
