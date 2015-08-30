<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SlnArCond.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 946px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="height: 203px; width: 920px">
        <tr>
            <td>
                <h3 align="center">
                    Digite Matrícula e Senha</h3>
            </td>
        </tr>
        <tr>
            <td align="center" class="style1">
                Matrícula&nbsp; -&nbsp;
                <asp:TextBox ID="txtMatr" runat="server"></asp:TextBox>
                &nbsp;&nbsp; Senha -
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" class="style1">
                <asp:Button ID="btnLogar" runat="server" Text="Entrar" Height="26px" OnClick="btnLogar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
