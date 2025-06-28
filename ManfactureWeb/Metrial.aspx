<%@ Page Title="Materials" Language="C#" MasterPageFile="~/Site.master" Async="true" AutoEventWireup="true" CodeBehind="Metrial.aspx.cs" Inherits="ManfactureWeb.Metrial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Materials</h1>
    <asp:GridView ID="gvMaterials" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MaterialId" HeaderText="Material ID" />
            <asp:BoundField DataField="MaterialName" HeaderText="Material Name" />
        </Columns>
    </asp:GridView>

    <h3>Add New Material</h3>
    <asp:TextBox ID="txtMaterialName" runat="server" Placeholder="Material Name"></asp:TextBox>
    <asp:Button ID="btnAddMaterial" runat="server" Text="Add" OnClick="btnAddMaterial_Click" />
</asp:Content>
