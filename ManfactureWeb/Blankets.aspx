<%@ Page Title="Blankets" Language="C#" MasterPageFile="~/Site.master" Async="true" AutoEventWireup="true" CodeBehind="Blankets.aspx.cs" Inherits="ManfactureWeb.Blankets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Blankets</h1>
    <asp:GridView ID="gvBlankets" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="BlanketId"
        OnRowEditing="gvBlankets_RowEditing"
        OnRowUpdating="gvBlankets_RowUpdating"
        OnRowCancelingEdit="gvBlankets_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="BlanketId" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="BlanketName" HeaderText="Name" />
            <asp:BoundField DataField="Material.MaterialId" HeaderText="Material ID" />
            <asp:BoundField DataField="ProductionCapacity" HeaderText="Capacity" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>

    <h3>Add New Blanket</h3>
    <asp:TextBox ID="txtBlanketName" runat="server" Placeholder="Name"></asp:TextBox>
    <asp:TextBox ID="txtMaterialId" runat="server" Placeholder="Material ID"></asp:TextBox>
    <asp:TextBox ID="txtCapacity" runat="server" Placeholder="Capacity"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" Placeholder="Price"></asp:TextBox>
    <asp:Button ID="btnAddBlanket" runat="server" Text="Add" OnClick="btnAddBlanket_Click" />
</asp:Content>
