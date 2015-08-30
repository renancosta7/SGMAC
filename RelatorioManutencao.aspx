<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RelatorioManutencao.aspx.cs" Inherits="SlnArCond.RelatorioManutencao"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
        {
            width: 1016px;
        }
        .style6
        {
            width: 504px;
        }
        .style9
        {
            width: 765px;
        }
        .style10
        {
            width: 765px;
            height: 48px;
        }
        .style11
        {
            width: 765px;
            height: 53px;
        }
        .style12
        {
            width: 483px;
        }
        .style13
        {
            width: 483px;
            height: 43px;
        }
        .style14
        {
            width: 504px;
            height: 43px;
        }
        .style16
        {
            width: 233px;
        }
        .style17
        {
            width: 208px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Geral" runat="server" Visible="false">
        <table>
            <tr>
                <td align="center" style="font-size: x-large; font-family: 'Times New Roman', Times, serif"
                    class="style13" colspan="2">
                    Digite a data de entrada
                </td>
                <td align="center" style="font-size: x-large; font-family: 'Times New Roman', Times, serif"
                    class="style14">
                    Selecione o status da manutenção
                </td>
            </tr>
            <tr>
                <td align="center" style="font-family: 'Times New Roman', Times, serif; font-size: large"
                    class="style16">
                    Inicial
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="Black" Height="119px" Width="187px" OnSelectionChanged="Calendar1_SelectionChanged">
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
                <td align="center" style="font-family: 'Times New Roman', Times, serif; font-size: large"
                    class="style17">
                    Final
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999"
                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="Black" Height="47px" Width="177px" OnSelectionChanged="Calendar2_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <asp:TextBox ID="txtData1" runat="server" ClientIDMode="Static" Width="58px" Enabled="false"
                        Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtData2" runat="server" ClientIDMode="Static" Width="64px" Enabled="false"
                        Visible="false"></asp:TextBox>
                </td>
                <td align="center" class="style6">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem>Fila de espera</asp:ListItem>
                        <asp:ListItem>Em Manutencao</asp:ListItem>
                        <asp:ListItem>Concluido</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="style12" colspan="2">
                    <asp:Button ID="btnBuscarData" runat="server" Text="Buscar" OnClick="btnBuscarData_Click"
                        Width="103px" />
                </td>
                <td align="center" class="style6">
                    <asp:Button ID="btnBuscarStatus" runat="server" Text="Buscar" OnClick="btnBuscarStatus_Click"
                        Width="110px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr style="color: #000000; width: 909px;" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="RelManu" runat="server" Visible="false">
        <table style="width: 918px">
            <tr>
                <td style="color: #000000; font-size: xx-large" align="center" class="style11">
                    <asp:Label ID="lblTRel" runat="server" Text="Relatório de Manutenção"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="color: #000000; font-size: x-large" align="center" class="style10">
                    <asp:Label ID="lblHed" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    <br />
                    <asp:GridView ID="gdvManu" runat="server" AutoGenerateColumns="False" Width="911px"
                        ForeColor="Black" Font-Size="Large" Style="font-family: 'Times New Roman', Times, serif;
                        font-size: medium;">
                        <Columns>
                            <asp:BoundField DataField="Cod_Manutencao" HeaderText="Manutenção" />
                            <asp:BoundField DataField="Cliente.Nome" HeaderText="Cliente" />
                            <%--<asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                            <asp:BoundField DataField="NumSerie" HeaderText="N° Serie" />--%>
                            <asp:BoundField DataField="DataEntrada" HeaderText="Entrada" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="DataSaida" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Saída" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <%--<asp:BoundField DataField="Observacao" HeaderText="Observacao" />--%>
                            <asp:BoundField DataField="ValorMObra" HeaderText="Valor MO" DataFormatString="{0:c}" />
                            <asp:BoundField DataField="FormaPagamento" HeaderText="Pagamento" />
                            <asp:BoundField DataField="Matr_FuncFK" HeaderText="Funcionário" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table>
        <tr>
            <td colspan="2" align="center" class="style5">
                <asp:Button ID="btnPdf" runat="server" Text="Gerar Pdf" Width="103px" OnClick="btnPdf_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
