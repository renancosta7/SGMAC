<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroFuncionario.aspx.cs" Inherits="SlnArCond.CadastroFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="CadFuncionario" runat="server" Visible="false">
        <table style="width: 359px">
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
                    <asp:TextBox ID="txtCpf" runat="server" ClientIDMode="Static"></asp:TextBox>
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
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCargo" runat="server" Text="Cargo : "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCargo" runat="server" Height="16px" Width="129px">
                        <asp:ListItem Enabled="False"></asp:ListItem>
                        <asp:ListItem>Atendente</asp:ListItem>
                        <asp:ListItem>Gerente</asp:ListItem>
                        <asp:ListItem>Administrador</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
