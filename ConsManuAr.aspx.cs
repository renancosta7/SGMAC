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
    public partial class ConsManuAr : System.Web.UI.Page
    {
        //string teste;
        int Codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<pFuncionario> Lp = Session["Login"] as List<pFuncionario>;
            if (Lp == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Lp[0].Cargo == "Atendente")
            {
                ConManuAr.Visible = true;
            }
            else if (Lp[0].Cargo == "Gerente")
            {
                ConManuAr.Visible = true;

            }
            else if (Lp[0].Cargo == "Administrador")
            {
                ConManuAr.Visible = true;

            }
     
        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscaCpf();

        }

        public void BuscaCpf()
        {
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
                mManuAr M = new mManuAr();
                List<pManuAr> Lc = M.SelManu(Cod);
                gdvManu.DataSource = Lc;
                gdvManu.DataBind();
            }
        }

        protected void gdvManu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            lblCod.Text = gdvManu.SelectedRow.Cells[0].Text;
            txtCodCliente.Text = gdvManu.SelectedRow.Cells[1].Text;
            txtModelo.Text = gdvManu.SelectedRow.Cells[2].Text;
            txtMarca.Text = gdvManu.SelectedRow.Cells[3].Text;
            txtNumSerie.Text = gdvManu.SelectedRow.Cells[4].Text;
            txtDataEntrada.Text = gdvManu.SelectedRow.Cells[5].Text;
            txtDataSaida.Text = gdvManu.SelectedRow.Cells[6].Text;
            ddlStatus.Text = gdvManu.SelectedRow.Cells[7].Text;
            txtObs.Text = gdvManu.SelectedRow.Cells[8].Text;
            txtValorMObra.Text = gdvManu.SelectedRow.Cells[9].Text;
            ddlFormaPagamento.Text = gdvManu.SelectedRow.Cells[10].Text;
            txtMatrFunc.Text = gdvManu.SelectedRow.Cells[11].Text;
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Msg("Alterado com sucesso !");
            Codigo = Convert.ToInt32(lblCod.Text);
            pManuAr P = new pManuAr();
            P.Cod_Manutencao = Convert.ToInt32(lblCod.Text);
            P.Cod_ClienteFK = Convert.ToInt32(txtCodCliente.Text);
            P.Modelo = txtModelo.Text;
            P.Marca = txtMarca.Text;
            P.NumSerie = txtNumSerie.Text;
            P.DataEntrada = Convert.ToDateTime(txtDataEntrada.Text);
            P.DataSaida = Convert.ToDateTime(txtDataSaida.Text);
            P.Status = ddlStatus.Text;
            P.Observacao = txtObs.Text;
            P.ValorMObra = Convert.ToDecimal(txtValorMObra.Text);
            P.FormaPagamento = ddlFormaPagamento.Text;
            P.Matr_FuncFK = Convert.ToInt32(txtMatrFunc.Text);
            mManuAr M = new mManuAr();
            M.AtuManu(P);
            LimparContatos();
            
        }

        protected void btnExluir_Click(object sender, EventArgs e)
        {
            Msg("Exclusão efetuada com sucesso!");
            Codigo = Convert.ToInt32(lblCod.Text);
            mManuAr M = new mManuAr();
            M.ExcManuAr(Codigo);
            LimparContatos();
            
        }



        private void LimparContatos()
        {

            lblCod.Text = string.Empty;
            txtCodCliente.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtNumSerie.Text = string.Empty;
            txtDataEntrada.Text = string.Empty;
            txtDataSaida.Text = string.Empty;
            ddlStatus.Text = string.Empty;
            txtObs.Text = string.Empty;
            txtValorMObra.Text = string.Empty;
            ddlFormaPagamento.Text = string.Empty;
            txtMatrFunc.Text = string.Empty;

        }

        //private void txtValorMObra_Leave(object sender, EventArgs e)
        //{
        //    txtValorMObra.Text = Convert.ToDecimal(txtValorMObra.Text).ToString("C");
        //}



    }
}



