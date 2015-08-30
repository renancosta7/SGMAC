<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="VendaPecas.aspx.cs" Inherits="SlnArCond.VendaPecas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 920px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="Atualizar" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Repeater ID="rptProduto" runat="server" OnItemDataBound="rptProduto_ItemDataBound"
                    OnItemCommand="rptProduto_ItemCommand">
                    <HeaderTemplate>
                        <table border="2">
                            <tr>
                                <th>
                                    Código <%--Peças--%>
                                </th>
                                <th>
                                    Descrição
                                </th>
                                <th>
                                    Fabricante
                                </th>
                                <th>
                                    Modelo
                                </th>
                                <th>
                                   Quantidade em Estoque
                                </th>
                                <th>
                                    Valor da Peça <%--de Saída--%>
                                </th>
                                <th>
                                    Quantidade
                                </th>
                                <th>
                                    Total
                                </th>
                                <th>
                                    +/-
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
