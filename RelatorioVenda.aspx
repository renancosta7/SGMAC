<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RelatorioVenda.aspx.cs" Inherits="SlnArCond.RelatorioVenda1" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 394px;
            height: 33px;
        }
        .style2
        {
            width: 923px;
        }
        .style4
        {
            width: 268px;
            height: 33px;
        }
        .style5
        {
            width: 249px;
            height: 33px;
        }
        .style6
        {
            height: 47px;
        }
        .style8
        {
            height: 51px;
        }
        .style10
        {
            height: 42px;
        }
        .style11
        {
            height: 31px;
        }
        .style12
        {
            height: 55px;
        }
        .style13
        {
            width: 915px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Geral" runat="server" Visible="false">
        <table>
            <tr>
                <td colspan="3" align="center" style="font-family: 'Times New Roman', Times, serif;
                    font-size: xx-large">
                    Digite a data Inicial e Final
                </td>
            </tr>
            <tr>
                <td align="center">
                    Inicial
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                        Width="200px" onselectionchanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td align="center">
                    Final&nbsp;
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                        Width="200px" onselectionchanged="Calendar2_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                <%--</td>--%>
                <%--<td colspan="3" align="center" style="font-family: 'Times New Roman', Times, serif;
                    font-size: large">--%>
                <asp:TextBox ID="txtData1" Visible=false runat="server" ClientIDMode="Static"></asp:TextBox>
                <asp:TextBox ID="txtData2" Visible=false runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                        Width="83px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr style="width: 913px" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="RelVenda" runat="server" Visible="false">
            <table>
                <tr>
                    <td colspan="3" style="font-size: xx-large; font-family: 'Times New Roman', Times, serif;
                        color: #000000" align="center">
                        <asp:Label ID="lblHed" runat="server" Text="Relatório de Venda"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-family: 'Times New Roman', Times, serif;
                        font-size: x-large" class="style6" style="color: #000000;">
                        <asp:Label ID="lblTInicial" runat="server" Text="Inicial - "></asp:Label>
                        <asp:Label ID="lblInicial" runat="server" Text=" "></asp:Label>
                        <asp:Label ID="lblTFinal" runat="server" Text="Final - "></asp:Label>
                        <asp:Label ID="lblFinal" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-size: x-large; color: #000000;" class="style12">
                        <asp:Label ID="lblTDinheiro" runat="server" Text="Forma de pagamento : Dinheiro"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="gdvListaPecas1" runat="server" AutoGenerateColumns="False" Width="707px"
                            OnSelectedIndexChanged="gdvListaPecas1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Cod_Pedido" HeaderText="Código do Pedido" />
                                <asp:BoundField DataField="ValorTotal" HeaderText="Valor da Compra" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="FormaPagamento" HeaderText="Forma de Pagamento" />
                                <asp:BoundField DataField="DataPagamento" HeaderText="Data da Venda" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Cliente.Nome" HeaderText="Cliente" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-size: x-large; color: #000000;" class="style8">
                        <asp:Label ID="lblTDebito" runat="server" Text="Forma de pagamento : Cartão de débito "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="gdvListaPecas2" runat="server" AutoGenerateColumns="False" Width="707px"
                            OnSelectedIndexChanged="gdvListaPecas2_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Cod_Pedido" HeaderText="Código do Pedido" />
                                <asp:BoundField DataField="ValorTotal" HeaderText="Valor da Compra" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="FormaPagamento" HeaderText="Forma de Pagamento" />
                                <asp:BoundField DataField="DataPagamento" HeaderText="Data da Venda" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Cliente.Nome" HeaderText="Cliente" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-size: x-large; color: #000000;" class="style10">
                        <asp:Label ID="lblTCredito" runat="server" Text="Forma de pagamento : Cartão de crédito "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="gdvListaPecas3" runat="server" AutoGenerateColumns="False" Width="707px"
                            OnSelectedIndexChanged="gdvListaPecas3_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Cod_Pedido" HeaderText="Código do Pedido" />
                                <asp:BoundField DataField="ValorTotal" HeaderText="Valor da Compra" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="FormaPagamento" HeaderText="Forma de Pagamento" />
                                <asp:BoundField DataField="DataPagamento" HeaderText="Data da Venda" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Cliente.Nome" HeaderText="Cliente" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style4" style="color: #000000;">
                        <asp:Label ID="lblTTDinheiro" runat="server" Text="Dinheiro : "></asp:Label>
                        <asp:Label ID="lblDinheiro" runat="server" Text=" "></asp:Label>
                    </td>
                    <td align="center" class="style5" style="color: #000000;">
                        <asp:Label ID="lblTTDebito" runat="server" Text="Cartão de Débito : "></asp:Label>
                        <asp:Label ID="lblDebito" runat="server" Text=" "></asp:Label>
                    </td>
                    <td align="center" class="style1" style="color: #000000;">
                        <asp:Label ID="lblTTCredito" runat="server" Text="Cartão de Crédito : "></asp:Label>
                        <asp:Label ID="lblCredito" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" class="style11" style="color: #000000;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTTotalVenda" runat="server" Text="Valor Total de Vendas : "></asp:Label>
                        <asp:Label ID="lblTotalVenda" runat="server" Text=" "></asp:Label>
                    </td>
                    <td class="style11" style="color: #000000;">
                        <asp:Label ID="lblTVendas" runat="server" Text="Total de Vendas : "></asp:Label>
                        <asp:Label ID="lblVendas" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table>
            <tr>
                <td align="center" class="style13">
                    <asp:Button ID="btnPdf" runat="server" Text="Gerar Pdf" OnClick="btnPdf_Click" Width="93px" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="Pecas" runat="server" Visible="false">
            <table>
                <tr>
                    <td>
                        <hr style="color: #000000" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-family: 'Times New Roman', Times, serif;
                        font-size: xx-large">
                        Digite o código do pedido
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-family: 'Times New Roman', Times, serif;
                        font-size: large">
                        <asp:Label ID="lblTCodVenda" runat="server" Text="Código - "></asp:Label>
                        <asp:TextBox ID="txtCodVenda" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnCod" runat="server" Text="Buscar" Width="83px" OnClick="btnCod_Click" />
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="3" align="center" style="font-size: x-large; color: #000000;" class="style9">
                        Peças da vendidas
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="3" align="center" class="style2">
                        <asp:GridView ID="gdvVenda" runat="server" AutoGenerateColumns="False" Style="margin-top: 0px"
                            Width="774px">
                            <Columns>
                                <asp:BoundField DataField="Cod_Pecas" HeaderText="Código da Peça" />
                                <asp:BoundField HeaderText="Descrição" DataField="Descricao" />
                                <asp:BoundField HeaderText="Valor da Unidade" DataField="Valor_Saida" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="pQuantidade" HeaderText="Quantidade de Peças" />
                                <asp:BoundField HeaderText="Valor Total" DataField="Total" DataFormatString="{0:c}" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
