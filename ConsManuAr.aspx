<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsManuAr.aspx.cs" Inherits="SlnArCond.ConsManuAr" LCID="1046" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="ConManuAr" runat="server" Visible=false>
<table style="height: 88px; width: 352px;" align="center">
        <tr>
            <td class="style2" 
                style="width: 254px; font-size: xx-large; font-family: 'Times New Roman', Times, serif;" 
                align="center">
                <asp:Label ID="lblDigCpf" runat="server" Text="Digite o Cpf"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" style="width: 254px" align="center">
                &nbsp;<asp:TextBox ID="txtBuscaCpf" runat="server" Width="158px" 
                    ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" style="width: 254px" align="center">
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar"
                    Width="86px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCpf" runat="server" Text="Cpf inválido clique aqui para " Visible="False"></asp:Label>
                <asp:HyperLink ID="hpCadCliente" runat="server" NavigateUrl="~/CadastroCliente.aspx"
                    Target="_parent" Visible="False">Cadastrar Cliente</asp:HyperLink>
            </td>
        </tr>
    </table>
    <hr style="height: -15px" />
    <asp:GridView ID="gdvManu" runat="server" AutoGenerateColumns="False" Height="16px" OnSelectedIndexChanged="gdvManu_SelectedIndexChanged"
        Width="895px" Font-Size="Smaller" style="font-size: small">
        <Columns>
            <asp:BoundField DataField="Cod_Manutencao" HeaderText="Id Manu" />
            <asp:BoundField DataField="Cod_ClienteFK" HeaderText="Id Cliente" />
            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="NumSerie" HeaderText="N° Série" />
            <asp:BoundField DataField="DataEntrada" HeaderText="Data Entrada" 
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="DataSaida" HeaderText="Data Saída" 
                DataFormatString="{0:dd/MM/yyyy}" NullDisplayText="00/00/0000" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="Observacao" HeaderText="Observação" />
            <asp:BoundField DataField="ValorMObra" HeaderText="Valor Mão de Obra" 
                ApplyFormatInEditMode="True" />
            <asp:BoundField DataField="FormaPagamento" HeaderText="Forma Pagamento" />
            <asp:BoundField DataField="Matr_FuncFK" HeaderText="Funcionário" />
            <asp:CommandField ShowSelectButton="True" SelectText="Selecionar" />
        </Columns>
    </asp:GridView>
    <hr />
    <table style="height: 388px; width: 710px">
        <tr>
            <td style="width: 332px">
                <asp:Label ID="lblCodCliente" runat="server" Text="Código do Cliente : "></asp:Label>
            </td>
            <td style="width: 397px">
                <asp:TextBox ID="txtCodCliente" runat="server" Style="margin-left: 0px" 
                    Enabled="False" ></asp:TextBox>
                <asp:Label ID="lblCod" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 332px">
                <asp:Label ID="lblModelo" runat="server" Text="Modelo : "></asp:Label>
            </td>
            <td style="width: 397px">
                <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 332px">
                <asp:Label ID="lblMarca" runat="server" Text="Marca : "></asp:Label>
            </td>
            <td style="width: 397px">
                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 332px">
                <asp:Label ID="lblNumSerie" runat="server" Text="Número de Série : "></asp:Label>
            </td>
            <td style="width: 397px">
                <asp:TextBox ID="txtNumSerie" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 368px">
                <asp:Label ID="lblDataEntrada" runat="server" Text="Data de Entrada : "></asp:Label>
            </td>
            <td style="width: 364px">
                <asp:TextBox ID="txtDataEntrada" runat="server" Enabled="False" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 368px">
                <asp:Label ID="lblDataSaida" runat="server" Text="Data Saída : "></asp:Label>
            </td>
            <td style="width: 364px">
                <asp:TextBox ID="txtDataSaida" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 332px">
                <asp:Label ID="lblStatus" runat="server" Text="Status : "></asp:Label>
            </td>
            <td style="width: 397px">
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Fila de espera</asp:ListItem>
                    <asp:ListItem>Em Manutencao</asp:ListItem>
                    <asp:ListItem>Concluido</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 332px">
                <asp:Label ID="lblObs" runat="server" Text="Observação : "></asp:Label>
            </td>
            <td style="width: 397px">
                <asp:TextBox ID="txtObs" runat="server" Height="97px" Width="376px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 332px">
                <asp:Label ID="lblValorMObra" runat="server" Text="Valor da Mão de Obra : "></asp:Label>
            </td>
            <td style="width: 397px">
                <asp:TextBox ID="txtValorMObra" runat="server"  onKeyPress="return(MascaraMoeda(this,'.',',',event))" ></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width: 332px">
                <asp:Label ID="lblFormaPagamento" runat="server" Text="Forma de Pagamento : "></asp:Label>
            </td>
                <td> 
                    <asp:DropDownList ID="ddlFormaPagamento" runat="server">
                        <asp:ListItem Text="Dinheiro" />
                        <asp:ListItem Text="Cartao de Credito" />
                        <asp:ListItem Text="Cartao de Debito" />
                    </asp:DropDownList>
                </td>
            </tr>
        <tr>
            <td style="width: 332px; height: 37px;">
                <asp:Label ID="lblMatrFunc" runat="server" Text="Matrícula Funcionário Responsável : "></asp:Label>
            </td>
            <td style="width: 397px; height: 37px;">
                <asp:TextBox ID="txtMatrFunc" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 332px">
                &nbsp;</td>
                <td style="width: 397px; height: 37px;">
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" 
                        onclick="btnEditar_Click" Width="77px" />
                    <asp:Button ID="btnExluir" runat="server" Text="Excluir" 
                        onclick="btnExluir_Click" style="margin-left: 24px" Width="73px" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
