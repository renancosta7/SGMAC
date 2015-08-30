<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RelatorioFinanceiro.aspx.cs" Inherits="SlnArCond.RelatorioFinanceiro"
    EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style12
        {
            height: 42px;
        }
        .style13
        {
            height: 39px;
        }
        .style14
        {
            height: 36px;
        }
        .style16
        {
            width: 1152px;
        }
        .style17
        {
            width: 395px;
            height: 53px;
            color: #000000;
        }
        .style20
        {
            width: 382px;
            height: 53px;
            color: #000000;
        }
        .style21
        {
            width: 560px;
            height: 53px;
            color: #000000;
        }
        .style22
        {
            height: 35px;
        }
        .style23
        {
            height: 47px;
        }
        .style24
        {
            height: 44px;
        }
        .style25
        {
            height: 56px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="RelFinanceiro" runat="server" Visible="false">
        <table style="width: 919px; margin-right: 3px">
            <tr>
                <td colspan="4" style="font-size: xx-large; font-family: 'Times New Roman', Times, serif;
                    color: #000000;" align="center" class="style14">
                    Selecione a data
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center" style="font-size: large; font-family: 'Times New Roman', Times, serif;
                    color: #000000;" class="style13">
                    <%--Data ---%>
                    <asp:TextBox ID="txtData" runat="server" Width="95px" ClientIDMode="Static" Visible="false"></asp:TextBox>
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="Black" Height="180px" OnSelectionChanged="Calendar1_SelectionChanged"
                        Width="200px">
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
            </tr>
            <tr>
                <td colspan="4" align="center" class="style12">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                        Width="85px" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="GerarPdf" runat="server" Visible="false">
            <table>
                <tr>
                    <td colspan="3" align="center" style="font-size: xx-large; color: #000000" class="style25">
                        <asp:Label ID="lblRela" runat="server" Text=""></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-size: x-large; color: #000000" class="style24">
                        <asp:Label ID="lblTVenda" runat="server" Text="Relatório das Vendas"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="gdvVenda" runat="server" AutoGenerateColumns="False" Width="437px"
                            Style="color: #000000">
                            <Columns>
                                <asp:BoundField DataField="Cod_Pedido" HeaderText="Código da Venda" />
                                <asp:BoundField DataField="ValorTotal" HeaderText="Valor" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="FormaPagamento" HeaderText="Forma de Pagamento" />
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="font-size: x-large" class="style23">
                        <asp:Label ID="lblTManuAr" runat="server" Text="Relatório das Manutenções" Style="color: #000000"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="gdvManu" runat="server" AutoGenerateColumns="False" Width="486px"
                            Style="color: #000000">
                            <Columns>
                                <asp:BoundField DataField="Cod_Manutencao" HeaderText="Código da Manutenção" />
                                <asp:BoundField DataField="ValorMObra" HeaderText="Valor" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="FormaPagamento" HeaderText="Forma de Pagamento" />
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style20">
                        Dinheiro :
                        <asp:Label ID="lblDinheiro" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="center" class="style21">
                        Cartao de Debito :
                        <asp:Label ID="lblDebito" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="center" class="style17">
                        Cartao de Credito :
                        <asp:Label ID="lblCredito" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" class="style22" style="color: #000000">
                        Total :
                        <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table>
            <tr>
                <td align="center" class="style16">
                    <asp:Button ID="btnexportar" runat="server" Text="Gerar PDF" Visible="false" OnClick="btnexportar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
