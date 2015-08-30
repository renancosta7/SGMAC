using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class ConsultaCliente : System.Web.UI.Page
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
                ConCliente.Visible = true;
            }
            else if (Lp[0].Cargo == "Gerente")
            {
                ConCliente.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                ConCliente.Visible = true;

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
            mCliente M = new mCliente();
            List<pCliente> Lc = M.SelCliente(Cpf);
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
                lblCodCliente.Text = Lc[0].Cod_Cliente.ToString();
            }

        }

        public void Codigo()
        {
            lblCodCliente.Text = "0";
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

            string Cpf = txtBuscaCpf.Text;
            mCliente M = new mCliente();
            M.ExcCliente(Cpf);
            LimparContatos();
            Msg("Excluido com sucesso!");

        }

        private void LimparContatos()
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
            txtBuscaCpf.Text = string.Empty;
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Msg("Cadastro alterado com sucesso!");
            string Cpf = txtBuscaCpf.Text;
            pCliente P = new pCliente();
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
            mCliente M = new mCliente();
            M.AtuCliente(P);
            LimparContatos();

        }
    }
}