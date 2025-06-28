<%@ Page Title="Distributors" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Distributor.aspx.cs" Inherits="ManfactureWeb.Distributor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Distributor Quotations</h1>
    <asp:GridView ID="gvQuotations" runat="server" AutoGenerateColumns="False" OnRowEditing="gvQuotations_RowEditing" OnRowUpdating="gvQuotations_RowUpdating" OnRowCancelingEdit="gvQuotations_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="DistributorId" HeaderText="Distributor ID" ReadOnly="True" />
            <asp:BoundField DataField="DistributorName" HeaderText="Name" />
            <asp:BoundField DataField="QuotationAmount" HeaderText="Quotation" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
