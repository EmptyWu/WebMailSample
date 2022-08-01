<%@ Page Language="C#" AutoEventWireup="true" Title="檔案上傳範例" MasterPageFile="~/Site.Master" CodeBehind="uploadFile.aspx.cs" Inherits="WebMailSample.uploadFile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <asp:FileUpload ID="file" runat="server"  />
    <hr />

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
    會AutoPostBack 下拉選單<br />
    <asp:DropDownList ID="drp1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drp1_SelectedIndexChanged">
    </asp:DropDownList><br />
    <asp:DropDownList ID="drp2" runat="server"></asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
