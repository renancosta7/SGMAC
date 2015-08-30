<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultaFuncionario.aspx.cs" Inherits="SlnArCond.ConsultaFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="ConFuncionario" runat="server" Visible="false">
        <table>
            <tr>
                <td style="font-size: x-large; font-family: 'Times New Roman', Times, serif">
                    Digite o CPF para buscar o funcionário
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
                    <asp:Label ID="lblCodFunc" runat="server" Text="Código do Funcionário : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodFunc" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
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
                    <asp:Label ID="lblSenha" runat="server" Text="Senha : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCargo" runat="server" Text="Cargo : "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCargo" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Atendente</asp:ListItem>
                        <asp:ListItem>Gerente</asp:ListItem>
                        <asp:ListItem>Administrador</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click"
                        Width="77px" />
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click"
                        Style="margin-left: 27px" Width="82px" />
                </td>
                <td>
                    <asp:Label ID="lblMatr_Func" runat="server" Text="0" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
