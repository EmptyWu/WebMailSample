<%@ Page Language="C#" Title="發送信件Sample" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MailPage.aspx.cs" Inherits="WebMailSample.MailPage" %>
<asp:Content ID="BosyMail" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    收件者：<asp:TextBox ID="txtToMail" runat="server" Width="200px"></asp:TextBox><br />
    主旨：<asp:TextBox ID="txtSubject" runat="server" Width="200px"></asp:TextBox><br />
    信件內容：<asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox><br />
    <asp:Button ID="btnSendMail" runat="server" Text="發信" OnClick="btnSendMail_Click" />
    <asp:Button ID="btnReset" runat="server" Text="清除重填" OnClick="btnReset_Click" />
</asp:Content>