<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResumoVenda.aspx.cs" Inherits="SlnArCond.ResumoVenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2 {
            width: 953px;
        }

        .style3 {
            width: 150px;
        }

        .style4 {
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="3" align="center"
                style="font-family: 'Times New Roman', Times, serif; font-size: xx-large">Resumo
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" class="style2">
                <asp:GridView ID="GdvProdutos" runat="server" AutoGenerateColumns="False"
                    BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px"
                    CellPadding="4" CellSpacing="2" ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="Cod_Pecas" HeaderText="Id" />
                        <asp:BoundField HeaderText="Produto" DataField="Descricao" />
                        <asp:BoundField HeaderText="Quantidade" DataField="pQuantidade" />
                        <asp:BoundField DataField="Valor_Saida" HeaderText="Valor"
                            DataFormatString="{0:c}" />
                        <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:c}" />
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
    <table align="center" style="width: 452px">
        <tr>
            <td align="center" class="style4">
                <asp:Label ID="TotalCom" runat="server" Text="Total das Compras : "></asp:Label>
            </td>
            <td align="center" class="style3">
                <asp:Label ID="TotalC" runat="server" Text="0" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style4">
                <asp:Label ID="FormaPag" runat="server" Text="Forma de Pagamento : "></asp:Label>
            </td>
            <td align="center" class="style3">
                <asp:DropDownList ID="FormaP" runat="server">
                    <asp:ListItem Text="Dinheiro" />
                    <asp:ListItem Text="Cartao de Credito" />
                    <asp:ListItem Text="Cartao de Debito" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" class="style4">
                <asp:Label ID="DataHora" runat="server" Text="Data e Hora : "></asp:Label>
            </td>
            <td align="center" class="style3">
                <asp:Label ID="DataH" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style4">
                <asp:Label ID="lblCod_Cliente" runat="server" Text="Selecione o Cliente : "></asp:Label>
            </td>
            <td align="center" class="style3">
                <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList>
                 <%--<asp:TextBox ID="txtCod_Cliente" runat="server" Width="139px"></asp:TextBox>--%>
                <asp:Label ID="lblddl" runat="server" Text="0" ></asp:Label>
            </td>
            <tr>
                <td align="center" class="style4">
                    <asp:Label ID="lblCodPedido1" runat="server" Text="Codigo do Pedido : " Visible="false"></asp:Label>
                </td>
                <td align="center" class="style3">
                    <asp:Label ID="lblCodPedido" runat="server" Text="0" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="style4">
                    <asp:Button ID="BtnEditar" runat="server" Text="Editar Venda"
                        OnClick="BtnEditar_Click" Width="104px" />
                </td>
                <td class="style3" align="center">
                    <asp:Button ID="BtnProsseguir" runat="server" Text="Prosseguir"
                        OnClick="BtnProsseguir_Click" Width="96px" />
                </td>
            </tr>
    </table>
</asp:Content>
