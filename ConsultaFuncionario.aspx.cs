using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class ConsultaFuncionario : System.Web.UI.Page
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
                ConFuncionario.Visible = true;
            }
            else if (Lp[0].Cargo == "Gerente")
            {
                ConFuncionario.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                ConFuncionario.Visible = true;

            }

        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            Codigo();
            string Cpf = txtBuscaCpf.Text;
            mFuncionario M = new mFuncionario();
            List<pFuncionario> Lc = M.SelFuncionario(Cpf);
            if (Lc.Count == 0)
            {
                Msg("Cpf Inválido");
                return;
            }
            else
            {
                txtNome.Text = Lc[0].Nome;
                txtRg.Text = Lc[0].Rg;
                txtCpf.Text = Lc[0].Cpf;
                txtTelefone.Text = Lc[0].Telefone;
                txtEmail.Text = Lc[0].Email;
                txtDtNascimento.Text = Lc[0].DtNascimento.ToString("dd/MM/yyyy");
                txtEstado.Text = Lc[0].Estado;
                txtUf.Text = Lc[0].Uf;
                txtLougradouro.Text = Lc[0].Lougradouro;
                txtComplemento.Text = Lc[0].Complemento;
                txtBairro.Text = Lc[0].Bairro;
                txtCep.Text = Lc[0].Cep;
                txtSenha.Text = Lc[0].Senha;
                ddlCargo.Text = Lc[0].Cargo;
                txtCodFunc.Text = Lc[0].Matr_Func.ToString();
                lblMatr_Func.Text = Lc[0].Matr_Func.ToString();
            }

        }

        public void Codigo()
        {
            lblMatr_Func.Text = "0";
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Msg("Funcionário excluido com sucesso !");
            string Cpf = txtBuscaCpf.Text;
            mFuncionario M = new mFuncionario();
            M.ExcFuncionario(Cpf);
            LimparContatos();

        }

        private void LimparContatos()
        {
            txtCodFunc.Text = string.Empty;
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
            ddlCargo.Text = string.Empty;
            txtBuscaCpf.Text = string.Empty;
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Msg("Funcionario alterado com sucesso !");
            string Cpf = txtBuscaCpf.Text;
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
            M.AtuFuncionario(P);
            LimparContatos();
        }
    }
}