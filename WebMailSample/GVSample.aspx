<%@ Page Title="GridView加上分頁" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GVSample.aspx.cs" Inherits="WebMailSample.GVSample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gv_PageIndexChanging" >
        <Columns>
            <asp:BoundField DataField="item_id" HeaderText="編號" />
            <asp:BoundField DataField="item_name" HeaderText="名稱" />
            <asp:BoundField DataField="item_Qty" HeaderText="item_Qty" />
        </Columns>
    </asp:GridView>
        
</asp:Content>
