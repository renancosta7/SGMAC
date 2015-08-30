using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class Consultafonecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Codigo();
            List<pFuncionario> Lp = Session["Login"] as List<pFuncionario>;
            if (Lp == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Lp[0].Cargo == "Atendente")
            {
                ConFornecedor.Visible = true;
            }
            else if (Lp[0].Cargo == "Gerente")
            {
                ConFornecedor.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                ConFornecedor.Visible = true;

            }

        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Codigo();
            string Cnpj = txtBuscaCnpj.Text;
            mFornecedor M = new mFornecedor();
            List<pFornecedor> Lc = M.SelFornecedor(Cnpj);
            if (Lc.Count == 0) { Msg("Fornecedor Inexistente !"); return; } else { 
            txtRazaoSocial.Text = Lc[0].Razao_Social;
            txtCnpj.Text = Lc[0].Cnpj;
            txtTelefone.Text = Lc[0].Telefone;
            txtEmail.Text = Lc[0].Email;
            txtTipoPeca.Text = Lc[0].Tipo_Peca;
            txtEstado.Text = Lc[0].Estado;
            txtUf.Text = Lc[0].Uf;
            txtLougradouro.Text = Lc[0].Lougradouro;
            txtComplemento.Text = Lc[0].Complemento;
            txtBairro.Text = Lc[0].Bairro;
            txtCep.Text = Lc[0].Cep;
            lblCodFornecedor.Text = Lc[0].Cod_Fornecedor.ToString();

            }
        }

        public void Codigo()
        {
            lblCodFornecedor.Text = "0";
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Msg("Excluido com sucesso!");
            string Cnpj = txtBuscaCnpj.Text;
            mFornecedor M = new mFornecedor();
            M.ExcFornecedor(Cnpj);
            LimparContatos();
            Codigo();
        }

        private void LimparContatos()
        {
            txtRazaoSocial.Text = string.Empty;
            txtCnpj.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTipoPeca.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtUf.Text = string.Empty;
            txtLougradouro.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtBuscaCnpj.Text = string.Empty;
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Msg("Alterado com sucesso!");
            string Cnpj = txtBuscaCnpj.Text;
            pFornecedor P = new pFornecedor();
            P.Razao_Social = txtRazaoSocial.Text;
            P.Cnpj = txtCnpj.Text;
            P.Telefone = txtTelefone.Text;
            P.Email = txtEmail.Text;
            P.Tipo_Peca = txtTipoPeca.Text;
            P.Estado = txtEstado.Text;
            P.Uf = txtUf.Text;
            P.Lougradouro = txtLougradouro.Text;
            P.Complemento = txtComplemento.Text;
            P.Bairro = txtBairro.Text;
            P.Cep = txtCep.Text;
            mFornecedor M = new mFornecedor();
            M.AtuFornecedor(P);
            LimparContatos();
            

        }
    }
}