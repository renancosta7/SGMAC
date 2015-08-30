<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendaPecas2.aspx.cs" Inherits="SlnArCond.VendaPecas2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 458px;
        }

        .auto-style2 {
            width: 916px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 920px">
        <tr>
            <td colspan="2" align="center">&nbsp;Venda de Peças</td>
        </tr>
        <tr>
            <td align="right" class="auto-style1">
                <asp:Label ID="lblTBuscar" runat="server" Text="Buscar :"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="txtBuscar" runat="server" Width="155px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" /></td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="center" class="auto-style2">
                <asp:GridView ID="gdvPecas" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                    ForeColor="Black" OnSelectedIndexChanged="gdvPecas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Cod_Pecas" HeaderText="Código da Peça" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                        <asp:BoundField DataField="Fabricante" HeaderText="Fabricante" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="Valor_Saida" HeaderText="Valor" />
                        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
                        <asp:CommandField SelectText="Adicionar" ShowSelectButton="True" />
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
    <div style="width: 920px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="Atualizar" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Repeater ID="rptProduto" runat="server" OnItemDataBound="rptProduto_ItemDataBound" OnItemCommand="rptProduto_ItemCommand">
                    <HeaderTemplate>
                        <table border="2">
                            <tr>
                                <th>Código <%--Peças--%>
                                </th>
                                <th>Descrição
                                </th>
                                <th>Fabricante
                                </th>
                                <th>Modelo
                                </th>
                                <th>Quantidade em Estoque
                                </th>
                                <th>Valor da Peça <%--de Saída--%>
                                </th>
                                <th>Quantidade
                                </th>
                                <th>Total
                                </th>
                                <th>+/-
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblCod_Pecas" runat="server" Text="" Style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDescricao" runat="server" Text="" Style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFabricante" runat="server" Text="" Style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblModelo" runat="server" Text="" Style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEstoque" runat="server" Text="0" Style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblValor_Saida" runat="server" Text="0,00" Style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuantidade" runat="server" Width="100px" Text="0" Style="text-align: center"
                                    Enabled="False" OnTextChanged="txtQuantidade_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblTotal" runat="server" Text="0,00" Style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMais" runat="server" OnCheckedChanged="chkMais_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="lblVolume" runat="server" Text="Volume : 0"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:Label ID="lblTotalGeral" runat="server" Text="Total : 0,00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CommandName="Cancelar" />
                            </td>
                            <td colspan="4">
                                <asp:Button ID="btnProsseguir" runat="server" Text="Prosseguir" CommandName="Prosseguir" />
                            </td>
                        </tr>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
