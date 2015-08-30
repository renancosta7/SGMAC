<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroPecas.aspx.cs" Inherits="SlnArCond.CadastroPecas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="CadPecas" runat="server" Visible=false>
    
<table>
            <tr>
                <td>
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição : "></asp:Label>
                </td>
                <td style="width: 406px">
                    <asp:TextBox ID="txtDescricao" runat="server" Height="47px" Width="287px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFabricante" runat="server" Text="Fabricante : "></asp:Label>
                </td>
                <td style="width: 406px">
                    <asp:TextBox ID="txtFabricante" runat="server" Width="269px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo : "></asp:Label>
                </td>
                <td style="width: 406px">
                    <asp:TextBox ID="txtModelo" runat="server" Width="188px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblValor_Entrada" runat="server" Text="Valor Entrada : "></asp:Label>
                </td>
                <td style="width: 406px">
                    <asp:TextBox ID="txtValor_Entrada" runat="server" Width="97px" onKeyPress="return(MascaraMoeda(this,'.',',',event))"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblValor_Saida" runat="server" Text="Valor Saída : "></asp:Label>
                </td>
                <td style="width: 406px">
                    <asp:TextBox ID="txtValor_Saida" runat="server" Width="93px" onKeyPress="return(MascaraMoeda(this,'.',',',event))"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade : "></asp:Label>
                </td>
                <td style="width: 406px">
                    <asp:TextBox ID="txtQuantidade" runat="server" Width="62px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFornecedor" runat="server" Text="Código Fornecedor : "></asp:Label>
                </td>
                <td style="width: 406px">
                    <asp:DropDownList ID="ddlFornecedor" runat="server"></asp:DropDownList>
                    <%--<asp:TextBox ID="txtFornecedor" runat="server" Width="62px"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gdvFornecedor" runat="server" Width="500px" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                        GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="Cod_Fornecedor" HeaderText="ID" />
                            <asp:BoundField DataField="Razao_Social" HeaderText="Razão Social" />
                            <asp:BoundField DataField="Tipo_Peca" HeaderText="Tipo de Peça" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="Gray" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        </asp:Panel>
</asp:Content>
