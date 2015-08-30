using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class CadastroFuncionario : System.Web.UI.Page
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
                Msg("Você não tem autorização");
            }
            else if (Lp[0].Cargo == "Administrador")
            {
                CadFuncionario.Visible = true;
            }

        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtNome.Focus();
                return;
            }
            else if (txtRg.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtRg.Focus();
                return;
            }
            else if (txtCpf.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtCpf.Focus();
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
            else if (txtDtNascimento.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtDtNascimento.Focus();
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
            else if (txtSenha.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtSenha.Focus();
                return;
            }
            else
            {
                Msg("Funcionario cadastrado com sucesso!");
                pFuncionario P = new pFuncionario();
                P.Nome = txtNome.Text;
                P.Rg = txtRg.Text;
                P.Cpf = txtCpf.Text;
                P.Telefone = txtTelefone.Text;
                P.Email = txtEmail.Text;
                P.DtNascimento = Convert.ToDateTime(txtDtNascimento.Text);
                P.Estado = txtEstado.Text;
                P.Uf = txtUf.Text;
                P.Lougradouro = txtLougradouro.Text;
                P.Complemento = txtComplemento.Text;
                P.Bairro = txtBairro.Text;
                P.Cep = txtCep.Text;
                P.Senha = txtSenha.Text;
                P.Cargo = ddlCargo.Text;
                mFuncionario M = new mFuncionario();
                M.InsFuncionario(P);
                LimparContatos();
            }
        }
        public void LimparContatos()
        {
            txtNome.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDtNascimento.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtUf.Text = string.Empty;
            txtLougradouro.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }
    }
}