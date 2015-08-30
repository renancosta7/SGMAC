using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class CadastroFornecedor : System.Web.UI.Page
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
                CadFornecedor.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                CadFornecedor.Visible = true;

            }
        }
       
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtRazaoSocial.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtRazaoSocial.Focus();
                return;
            }
            else if (txtCnpj.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtCnpj.Focus();
                return;
            }
            else if (txtTelefone.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtTelefone.Focus();
                return;
            }
            else if (txtEmail.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtEmail.Focus();
                return;
            }
            else if (txtTipoPeca.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtTipoPeca.Focus();
                return;
            }
            else if (txtEstado.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtEstado.Focus();
                return;
            }
            else if (txtUf.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtUf.Focus();
                return;
            }
            else if (txtLougradouro.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtLougradouro.Focus();
                return;
            }
            else if (txtComplemento.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtComplemento.Focus();
                return;
            }
            else if (txtBairro.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtBairro.Focus();
                return;
            }
            else if (txtCep.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtCep.Focus();
                return;
            }
            else if (ValidaCNPJ.IsCnpj(txtCnpj.Text))
            {
                Msg("Cadastrado Com Sucesso!");
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
                M.InsFornecedor(P);
                LimparContato();
            }
            else
            {
                Msg("O número é um CNPJ Inválido !");

            }

        }

        public void LimparContato()
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
        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");


        }
    }
}