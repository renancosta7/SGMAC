<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultarEstoque.aspx.cs" Inherits="SlnArCond.ConsultarEstoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 315px;
        }
        .style4
        {
            width: 125px;
        }
        .style5
        {
            width: 121px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="ConEstoque" runat="server" Visible="false">
        <table style="width: 917px">
            <tr>
                <td colspan="2" style="font-size: x-large; font-family: 'Times New Roman', Times, serif">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Digite o código da peça</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblConsulta" runat="server" Text="Consulta : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtConsulta" runat="server" Height="21px" Width="130px"></asp:TextBox>
                    <asp:Button ID="btnConsulta" runat="server" Text="Buscar" Style="margin-left: 25px"
                        Width="111px" OnClick="btnConsulta_Click" Font-Bold="False" Font-Strikeout="False" />
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDescricao" runat="server" Height="21px" Width="287px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblFabricante" runat="server" Text="Fabricante : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtFabricante" runat="server" Width="269px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtModelo" runat="server" Width="188px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblValor_Entrada" runat="server" Text="Valor Entrada : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtValor_Entrada" runat="server" Width="97px" onKeyPress="return(MascaraMoeda(this,'.',',',event))"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblValor_Saida" runat="server" Text="Valor Saída : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtValor_Saida" runat="server" Width="93px" onKeyPress="return(MascaraMoeda(this,'.',',',event))"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtQuantidade" runat="server" Width="62px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click"
                        Width="87px" />
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click"
                        Style="margin-left: 26px" Width="85px" />
                    <asp:Label ID="lblCodPecas" runat="server" Text="0" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gdvPecas" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                        ForeColor="Black">
                        <Columns>
                            <asp:BoundField DataField="Cod_Pecas" HeaderText="Cod_Pecas" />
                            <asp:BoundField DataField="Descricao" HeaderText="Descricao" />
                            <asp:BoundField DataField="Fabricante" HeaderText="Fabricante" />
                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                            <asp:BoundField DataField="Valor_Entrada" HeaderText="Valor_Entrada" />
                            <asp:BoundField DataField="Valor_Saida" HeaderText="Valor_Saida" />
                            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
