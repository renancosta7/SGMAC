using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

namespace SlnArCond
{
    public partial class CadastroManu : System.Web.UI.Page
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
                CadManutencao.Visible = true;
            }
            else if (Lp[0].Cargo == "Gerente")
            {
                CadManutencao.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                CadManutencao.Visible = true;

            }

        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //string Cpf;
            int Cod = 0;
            Dao D = new Dao();
            SqlConnection Cn = D.SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Cliente from tbCliente Where Cpf=@Cpf");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cpf", txtBuscaCpf.Text);
            Cod = Convert.ToInt32(cmd.ExecuteScalar());
            Cn.Close();
            if (Cod <= 0)
            {
                lblCpf.Visible = true;
                hpCadCliente.Visible = true;
            }
            else
            {
                Form.Visible = true;
                txtCodCliente.Text = Convert.ToString(Cod);
                
            }

        }
     
        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            if (txtCodCliente.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtCodCliente.Focus();
                return;
            }
            else if (txtModelo.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtModelo.Focus();
                return;
            }
            else if (txtMarca.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtMarca.Focus();
                return;
            }
            else if (txtNumSerie.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtNumSerie.Focus();
                return;
            }
            else if (txtObs.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtObs.Focus();
                return;
            }
            else if (txtDataSaida.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtDataSaida.Focus();
                return;
            }
            else if (txtValorMObra.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtValorMObra.Focus();
                return;
            }
            else if (txtMatrFunc.Text == string.Empty)
            {
                Msg("Campo obrigatório em branco!");
                txtMatrFunc.Focus();
                return;
            }
            else
            {
                Msg("Manutenção cadastrada com sucesso!");
                pManuAr P = new pManuAr();
                P.Cod_ClienteFK = Convert.ToInt32(txtCodCliente.Text);
                P.Modelo = txtModelo.Text;
                P.Marca = txtMarca.Text;
                P.NumSerie = txtNumSerie.Text;
                P.DataEntrada = DateTime.Today;
                P.DataSaida = Convert.ToDateTime(txtDataSaida.Text);
                P.Status = ddlStatus.Text;
                P.Observacao = txtObs.Text;
                P.ValorMObra = Convert.ToDecimal(txtValorMObra.Text);
                P.FormaPagamento = ddlFormaPagamento.Text;
                P.Matr_FuncFK = Convert.ToInt32(txtMatrFunc.Text);
                mManuAr M = new mManuAr();
                M.InsManu(P);
                LimparContatos();
            }
        }


        public void LimparContatos()
        {
            txtCodCliente.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtNumSerie.Text = string.Empty;
            txtDataSaida.Text = string.Empty;
            txtObs.Text = string.Empty;
            txtValorMObra.Text = string.Empty;
            ddlFormaPagamento.Text = string.Empty;
            txtMatrFunc.Text = string.Empty;
        }


    }
}
