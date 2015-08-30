using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class ConsultarEstoque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarGrid();
            List<pFuncionario> Lp = Session["Login"] as List<pFuncionario>;
            if (Lp == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Lp[0].Cargo == "Atendente")
            {
                ConEstoque.Visible = true;
                btnAlterar.Visible = false;
                btnExcluir.Visible = false;
            }
            else if (Lp[0].Cargo == "Gerente")
            {
                ConEstoque.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                ConEstoque.Visible = true;

            }

        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            Codigo();
            int Cod_Pecas = Convert.ToInt32(txtConsulta.Text);
            mPecas M = new mPecas();
            List<pPecas> Lc = M.SelPecas(Cod_Pecas);
            txtDescricao.Text = Lc[0].Descricao;
            txtFabricante.Text = Lc[0].Fabricante;
            txtModelo.Text = Lc[0].Modelo;
            txtValor_Entrada.Text = Lc[0].Valor_Entrada.ToString();
            txtValor_Saida.Text = Lc[0].Valor_Saida.ToString();
            txtQuantidade.Text = Lc[0].Quantidade.ToString();
            lblCodPecas.Text = Lc[0].Cod_Pecas.ToString();
            lblCodPecas.Text = Cod_Pecas.ToString();
        }

        public void Codigo()
        {
            lblCodPecas.Text = "0";
        }

        private void ListarGrid()
        {
            mPecas M = new mPecas();
            List<pPecas> Lc = M.SelPecas();
            gdvPecas.DataSource = Lc;
            gdvPecas.DataBind();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Msg(" Peça excluída com sucesso!");
            int Cod_Pecas = Convert.ToInt32(lblCodPecas.Text);
            mPecas M = new mPecas();
            M.ExcPecas(Cod_Pecas);
            LimparContatos();

        }

        private void LimparContatos()
        {
            txtDescricao.Text = string.Empty;
            txtFabricante.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtValor_Entrada.Text = string.Empty;
            txtValor_Saida.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtConsulta.Text = string.Empty;
            Codigo();
        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Msg("Peça alterada com sucesso!");
            int Cod_Pecas = Convert.ToInt32(txtConsulta.Text);
            pPecas P = new pPecas();
            P.Descricao = txtDescricao.Text;
            P.Fabricante = txtFabricante.Text;
            P.Modelo = txtModelo.Text;
            P.Valor_Entrada = Convert.ToDecimal(txtValor_Entrada.Text);
            P.Valor_Saida = Convert.ToDecimal(txtValor_Saida.Text);
            P.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            P.Cod_Pecas = Convert.ToInt32(lblCodPecas.Text);
            mPecas M = new mPecas();
            M.AtuPecas(P);
            ListarGrid();
            LimparContatos();
        }
    }
}