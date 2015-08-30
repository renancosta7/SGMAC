<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroManu.aspx.cs" Inherits="SlnArCond.CadastroManu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 920px;
        }
        .style4
        {
            width: 647px;
        }
        .style5
        {
            height: 37px;
            width: 647px;
        }
        .style6
        {
            width: 881px;
        }
        .style7
        {
            height: 37px;
            width: 1364px;
        }
        .style8
        {
            width: 1364px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="CadManutencao" runat="server">
        <asp:Panel ID="inicio" runat="server">
            <table style="height: 173px">
                <tr>
                    <td align="center" style="font-size: xx-large; font-family: 'Times New Roman', Times, serif">
                       Digite o cpf do cliente
                    </td>
                </tr>
                <tr>
                    <td class="style1" align="center">
                        <asp:TextBox ID="txtBuscaCpf" runat="server" Width="268px" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1" align="center">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="86px" OnClick="btnBuscar_Click" />
                        <asp:Label ID="lblCod" runat="server" Text="0" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1" align="center">
                        <asp:Label ID="lblCpf" runat="server" Text="Cpf inválido clique aqui para " Visible="False"></asp:Label>
                        <asp:HyperLink ID="hpCadCliente" runat="server" Visible="False" NavigateUrl="~/CadastroCliente.aspx"
                            Target="_parent">Cadastrar Cliente</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Form" runat="server" Visible="false">
            <table style="height: 330px; width: 594px">
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblCodCliente" runat="server" Text="Código do Cliente : " ></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtCodCliente" runat="server" Style="margin-left: 0px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblModelo" runat="server" Text="Modelo : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblMarca" runat="server" Text="Marca : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblNumSerie" runat="server" Text="Número de Série : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtNumSerie" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblStatus" runat="server" Text="Status : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem>Fila de espera</asp:ListItem>
                            <asp:ListItem>Em Manutenção</asp:ListItem>
                            <asp:ListItem>Concluído</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblObs" runat="server" Text="Observação : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtObs" runat="server" Height="77px" Width="221px" 
                            EnableTheming="True" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblDataSaida" runat="server" Text="Data Prévia de Saída : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtDataSaida" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblValorMObra" runat="server" Text="Valor da Mão de Obra : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtValorMObra" runat="server" onKeyPress="return(MascaraMoeda(this,'.',',',event))"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr><td class="style8">
                        <asp:Label ID="lblFormaPagamento" runat="server" Text="Forma de Pagamento : "></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:DropDownList ID="ddlFormaPagamento" runat="server">
                            <asp:ListItem Text="Dinheiro" />
                            <asp:ListItem Text="Cartao de Credito" />
                            <asp:ListItem Text="Cartao de Debito" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="lblMatrFunc" runat="server" Text="Matrícula Funcionário Responsável : "></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtMatrFunc" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
