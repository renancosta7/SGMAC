<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Consultafonecedor.aspx.cs" Inherits="SlnArCond.Consultafonecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="ConFornecedor" runat="server" Visible="false">
        <table>
            <tr>
                <td align="left" 
                    style="font-family: 'Times New Roman', Times, serif; font-size: x-large">Digite o CNPJ para buscar o fornecedor
                </td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtBuscaCnpj" runat="server" Style="margin-left: 3px" Width="340px" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td> 
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
            Style="margin-left: 94px" Width="159px" />
                </td>
            </tr>
        </table>
        
        
       
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblRazaoSocial" runat="server" Text="Razão Social : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRazaoSocial" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCnpj" runat="server" Text="Cnpj : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCnpj" runat="server" Enabled="False" ClientIDMode="Static"></asp:TextBox>
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
                    <asp:Label ID="lblTipoPeca" runat="server" Text="Tipo da Peça : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTipoPeca" runat="server"></asp:TextBox>
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
                    <asp:TextBox ID="txtCep" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click"
                        Width="79px" />
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click"
                        Style="margin-left: 21px" Width="86px" />
                </td>
                <td>
                    <asp:Label ID="lblCodFornecedor" runat="server" Text="0" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
