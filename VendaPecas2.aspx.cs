using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class VendaPecas2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string Descricao = txtBuscar.Text;
            mPecas P = new mPecas();
            List<pPecas> Lc = P.SelItens(Descricao);
            gdvPecas.DataSource = Lc;
            gdvPecas.DataBind();
        }

        protected void gdvPecas_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<pPecas> LP = new List<pPecas>();
            pPecas P = new pPecas();
            P.Cod_Pecas = Convert.ToInt32(gdvPecas.SelectedRow.Cells[0].Text);
            P.Descricao = gdvPecas.SelectedRow.Cells[1].Text;
            P.Fabricante = gdvPecas.SelectedRow.Cells[2].Text;
            P.Modelo = gdvPecas.SelectedRow.Cells[3].Text;
            P.Valor_Saida = Convert.ToDecimal(gdvPecas.SelectedRow.Cells[4].Text);
            P.Quantidade = Convert.ToInt32(gdvPecas.SelectedRow.Cells[5].Text);
            LP.Add(P);
            rptProduto.DataSource = LP;
            rptProduto.DataBind();

        }
        protected void rptProduto_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                pPecas P = (pPecas)e.Item.DataItem;
                Label lblCod_Pecas = (Label)e.Item.FindControl("lblCod_Pecas");
                lblCod_Pecas.Text = P.Cod_Pecas.ToString();
                Label lblDescricao = (Label)e.Item.FindControl("lblDescricao");
                lblDescricao.Text = P.Descricao.ToString();
                Label lblFabricante = (Label)e.Item.FindControl("lblFabricante");
                lblFabricante.Text = P.Fabricante.ToString();
                Label lblModelo = (Label)e.Item.FindControl("lblModelo");
                lblModelo.Text = P.Modelo.ToString();
                Label lblEstoque = (Label)e.Item.FindControl("lblEstoque");
                lblEstoque.Text = P.Quantidade.ToString();
                Label lblValor_Saida = (Label)e.Item.FindControl("lblValor_Saida");
                lblValor_Saida.Text = P.Valor_Saida.ToString("#,##0.00");
            }
        }
        protected void chkMais_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Chk = (CheckBox)sender;
            RepeaterItem Rpt = (RepeaterItem)Chk.Parent;
            TextBox txtQuantidade = (TextBox)Rpt.FindControl("txtQuantidade");
            txtQuantidade.Enabled = Chk.Checked;
            txtQuantidade.Text = (Chk.Checked ? "1" : "0");
            Label lblValor_Saida = (Label)Rpt.FindControl("lblValor_Saida");
            Label lblTotal = (Label)Rpt.FindControl("lblTotal");
            lblTotal.Text = (Chk.Checked ? lblValor_Saida.Text : "0,00");
            AtuTotais();


        }

        protected void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

            TextBox txtQuantidade = (TextBox)sender;
            RepeaterItem Rpt = (RepeaterItem)txtQuantidade.Parent;
            Label lblValor_Saida = (Label)Rpt.FindControl("lblValor_Saida");
            Label lblTotal = (Label)Rpt.FindControl("lblTotal");
            Label lblEstoque = (Label)Rpt.FindControl("lblEstoque");
            lblTotal.Text = (Convert.ToDecimal(txtQuantidade.Text) * Convert.ToDecimal(lblValor_Saida.Text)).ToString("#,##0.00");
            AtuTotais();

            
        }

        public void AtuTotais()
        {
            decimal Vol = 0;
            decimal Tot = 0;
            List<pCarrinho> Lp = new List<pCarrinho>();

            for (int i = 0; i < rptProduto.Items.Count; i++)
            {
                RepeaterItem Rpt = (RepeaterItem)rptProduto.Items[i];
                CheckBox Chk = (CheckBox)Rpt.FindControl("ChkMais");
                TextBox TxtQuantidade = (TextBox)Rpt.FindControl("TxtQuantidade");
                Label lblEstoque = (Label)Rpt.FindControl("lblEstoque");
                Label lblTotal = (Label)Rpt.FindControl("lblTotal");
                int Q = 0;
                int E = 0;

                Q = Convert.ToInt32(TxtQuantidade.Text);
                E = Convert.ToInt32(lblEstoque.Text);
                if (Q > E)
                {

                    Chk.Checked = false;
                    TxtQuantidade.Text = "0";
                    //TxtQuantidade.Text = string.Empty;
                    lblTotal.Text = "0,00";
                    TxtQuantidade.Enabled = false;
                    string mensagem = "Estoque Insuficiente!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);

                }
                else
                {

                }
                if (Chk.Checked)
                {

                    pCarrinho P = new pCarrinho();
                    Vol += Convert.ToDecimal(TxtQuantidade.Text);
                    //Label lblTotal = (Label)Rpt.FindControl("lblTotal");
                    Tot += Convert.ToDecimal(lblTotal.Text);
                    Label lblCod_Pecas = (Label)Rpt.FindControl("lblCod_Pecas");
                    P.Cod_Pecas = Convert.ToInt32(lblCod_Pecas.Text);
                    Label lblDescricao = (Label)Rpt.FindControl("lblDescricao");
                    P.Descricao = lblDescricao.Text.ToString();
                    P.pQuantidade = Convert.ToInt32(TxtQuantidade.Text);
                    Label lblValor_Saida = (Label)Rpt.FindControl("lblValor_Saida");
                    P.Valor_Saida = Convert.ToDecimal(lblValor_Saida.Text);
                    P.Quantidade = Convert.ToInt32(lblEstoque.Text);
                    Lp.Add(P);
                    #region backup
                    //Label lblValor_Entrada = (Label)Rpt.FindControl("lblValor_Entrada");
                    //P.Valor_Entrada = Convert.ToDecimal(lblValor_Entrada.Text);
                    //P.PUnit = Convert.ToDecimal(lblValor.Text);
                    #endregion
                }
            }
            Session["Carrinho"] = Lp;
            //RepeaterItem RptF = (RepeaterItem)rptProduto.Controls[rptProduto.Controls.Count - 1];
            //Label lblVolume = (Label)RptF.FindControl("lblVolume");
            //lblVolume.Text = Vol.ToString();
            ((rptProduto.Controls[rptProduto.Controls.Count - 1] as RepeaterItem).FindControl("lblVolume") as Label).Text = "Volume :  " + Vol.ToString();
            ((rptProduto.Controls[rptProduto.Controls.Count - 1] as RepeaterItem).FindControl("lblTotalGeral") as Label).Text = "Total : R$" + Tot.ToString("#,##0.00");
        }
        protected void rptProduto_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                //case "Cancelar":
                //    ListarRpt();
                //    break;
                case "Prosseguir":
                    if (Session["Carrinho"] != null && (Session["Carrinho"] as List<pCarrinho>).Count > 0)
                    {
                        Response.Redirect("ResumoVenda.aspx");
                    }
                    else
                    {
                    }
                    break;
            }

        }
        public void EditarCarrinho()
        {
            List<pCarrinho> Lp = Session["Carrinho"] as List<pCarrinho>;
            for (int i = 0; i < Lp.Count; i++)
            {
                for (int a = 0; a < rptProduto.Items.Count; a++)
                {
                    RepeaterItem Rpt = (RepeaterItem)rptProduto.Items[i];
                    string lblCod_Pecas = (Rpt.FindControl("lblCod_Pecas") as Label).Text;
                    if (Lp[i].Cod_Pecas.ToString() == lblCod_Pecas)
                    {
                        (Rpt.FindControl("ChkMais") as CheckBox).Checked = true;
                        TextBox txtQuantidade = (TextBox)Rpt.FindControl("txtQuantidade");
                        txtQuantidade.Enabled = true;
                        txtQuantidade.Text = Lp[i].pQuantidade.ToString();
                        (Rpt.FindControl("lblTotal") as Label).Text = Lp[i].Total.ToString();
                    }
                }
            }
            AtuTotais();
        }
        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }
    }
}