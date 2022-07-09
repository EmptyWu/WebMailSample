<%@ Page Language="C#" Title="ListBoxSample" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ListBoxSample.aspx.cs" Inherits="WebMailSample.ListBoxSample" %>
<asp:Content ID="ListBox" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ListBox範例</h2>
    <hr />
    控制ListBox單選(Single)或複選(Multiple)
    <asp:RadioButtonList ID="rbMode" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbMode_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Value="Single" Text="單選" Selected></asp:ListItem>
        <asp:ListItem Value="Multiple" Text="複選"></asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:ListBox ID="lb" runat="server" Rows="10" Visible="False"></asp:ListBox>
    <asp:Button ID="btnGet" runat="server" Text="取得ListBoxv選取值" OnClick="btnGet_Click" />
    <asp:Button ID="btnAll" runat="server" Text="取得ListBoxn所有值" OnClick="btnAll_Click" />
    <br />
    <asp:TextBox ID="txt" runat="server" Height="98px" TextMode="MultiLine" Width="547px"></asp:TextBox>
    <hr />
    說明：
    <ol>
        <li> 複選可以使用Ctrl or Shift 進行多筆選取</li>
        <li> SelectionMode ： 控制ListBox 單選(Single)或複選(Multiple)，預設是單選 </li>
    </ol>
</asp:Content>