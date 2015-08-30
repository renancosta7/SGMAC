<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultaCliente.aspx.cs" Inherits="SlnArCond.ConsultaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="ConCliente" runat="server" Visible="false">
        <table>
            <tr>
                <td align="left" style="font-family: 'Times New Roman', Times, serif; font-size: x-large">
                    Digite o CPF para buscar o cliente
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtBuscaCpf" runat="server" Style="margin-left: 3px" Width="340px"
                        ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                        Style="margin-left: 94px" Width="175px" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblNome" runat="server" Text="Nome : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRg" runat="server" Text="Rg : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRg" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCpf" runat="server" Text="CPF : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCpf" runat="server" Enabled="False" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTelefone" runat="server" Text="Telefone : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefone" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDtNascimento" runat="server" Text="Data de Nascimento : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDtNascimento" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEstado" runat="server" Text="Estado : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUf" runat="server" Text="UF : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUf" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLougradouro" runat="server" Text="Lougradouro : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLougradouro" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblComplemento" runat="server" Text="Complemento : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtComplemento" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBairro" runat="server" Text="Bairro : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCep" runat="server" Text="Cep : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCep" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click"
                        Width="82px" />
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click"
                        Style="margin-left: 20px" Width="79px" />
                </td>
                <td>
                    <asp:Label ID="lblCodCliente" runat="server" Text="0" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
