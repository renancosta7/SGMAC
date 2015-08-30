using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class CadastroPecas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<pFuncionario> Lp = Session["Login"] as List<pFuncionario>;
            if (Lp == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Lp[0].Cargo == "Atendente")
            {
                Msg("Você não tem autorização");
            }
            else if (Lp[0].Cargo == "Gerente")
            {
                CadPecas.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                CadPecas.Visible = true;

            }
            ListarGrid();
            ListaFornecedor();
        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

        public void ListaFornecedor()
        {
            mFornecedor M = new mFornecedor();
            List<pFornecedor> Lc = M.SelFornecedor();
            ddlFornecedor.DataTextField = "Razao_Social";
            ddlFornecedor.DataValueField = "Cod_Fornecedor";
            ddlFornecedor.DataSource = Lc;
            ddlFornecedor.DataBind();
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtDescricao.Focus();
                return;
            }
            else if (txtFabricante.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtFabricante.Focus();
                return;
            }
            else if (txtModelo.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtModelo.Focus();
                return;
            }
            else if (txtValor_Entrada.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtValor_Entrada.Focus();
                return;
            }
            else if (txtValor_Saida.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtValor_Saida.Focus();
                return;
            }
            else if (txtQuantidade.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtQuantidade.Focus();
                return;
            }
            else
            {
                Msg("Peça cadastrada com sucesso!");
                pPecas P = new pPecas();
                P.Descricao = txtDescricao.Text;
                P.Fabricante = txtFabricante.Text;
                P.Modelo = txtModelo.Text;
                P.Valor_Entrada = Convert.ToDecimal(txtValor_Entrada.Text);
                P.Valor_Saida = Convert.ToDecimal(txtValor_Saida.Text);
                P.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                P.Cod_FornecedorFK = Convert.ToInt32(ddlFornecedor.Text);
                mPecas M = new mPecas();
                M.InsPecas(P);
                LimparContato();
            }
        }

        public void LimparContato() 
        {
            txtDescricao.Text = string.Empty;
            txtFabricante.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtValor_Entrada.Text = string.Empty;
            txtValor_Saida.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            //txtFornecedor.Text = string.Empty;
        }
        private void ListarGrid()
        {
            mFornecedor M = new mFornecedor();
            List<pFornecedor> Lc = M.SelFornecedor();
            gdvFornecedor.DataSource = Lc;
            gdvFornecedor.DataBind();


        }

    }
}