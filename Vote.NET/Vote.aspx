<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vote.aspx.cs" Inherits="Vote.NET.Vote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="新闻人物投票系统"></asp:Label>
            
        </div>
        <table class="auto-style1">
            <tr>
                <td>
            <asp:Label ID="Label2" runat="server" Text="注意："></asp:Label>
            <asp:Label ID="lblState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbtlVote" runat="server" AutoPostBack="True" CausesValidation="True" RepeatColumns="2">
                        <asp:ListItem>张玉杰</asp:ListItem>
                        <asp:ListItem>李明达</asp:ListItem>
                        <asp:ListItem>王瑜兰</asp:ListItem>
                        <asp:ListItem>赵志奇</asp:ListItem>
                        <asp:ListItem>马伟明</asp:ListItem>
                        <asp:ListItem>程超</asp:ListItem>
                        <asp:ListItem>刘平真</asp:ListItem>
                        <asp:ListItem>张群英</asp:ListItem>
                        <asp:ListItem>王子文</asp:ListItem>
                        <asp:ListItem>杨波</asp:ListItem>
                    </asp:RadioButtonList> 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnVote" runat="server" OnClick="btnVote_Click" Text="投票" />
                    <asp:Button ID="btnView" runat="server" Text="查看" OnClick="btnView_Click1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblView" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
