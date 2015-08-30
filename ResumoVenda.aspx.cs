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
    public partial class ResumoVenda : System.Web.UI.Page
    {



        decimal Tot;
        int Cod_Pedido;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListarGdv();
            DataH.Text = Convert.ToString(DateTime.Now);
            Total();
            if (!IsPostBack)
            {
                ListaFornecedor();
            }
            //Ddl();
        }
        //public void Ddl()
        //{
        //    lblddl.Text = "0";
        //    lblddl.Text = ddlCliente.SelectedValue;
        //}
        public void ListaFornecedor()
        {
            mCliente M = new mCliente();
            List<pCliente> Lc = M.SelCliente();
            ddlCliente.DataTextField = "Nome";
            ddlCliente.DataValueField = "Cod_Cliente";
            ddlCliente.DataSource = Lc;
            ddlCliente.DataBind();

        }
        public void ListarGdv()
        {

            List<pCarrinho> Lp = Session["Carrinho"] as List<pCarrinho>;
            GdvProdutos.DataSource = Lp;
            GdvProdutos.DataBind();
        }
        public void Total()
        {
            List<pCarrinho> Lp = Session["Carrinho"] as List<pCarrinho>;

            for (int i = 0; i < Lp.Count; i++)
            {
                Tot = Tot + Lp[i].Total;

            }
            TotalC.Text = Convert.ToString(Tot);

        }
        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendaPecas.aspx");
        }
        protected void BtnProsseguir_Click(object sender, EventArgs e)
        {
            //if (txtCod_Cliente.Text == string.Empty)
            //{
            //    Msg("Campo obrigatório em branco!");
            //    txtCod_Cliente.Focus();
            //    return;
            //}
            //else
            //{
            InserirPedido();
            RetornaCod();
            BaixaEstoque();
            Session.Remove("Carrinho");
            //Msg("Venda feita com sucesso");
            //Response.Redirect("VendaPecas.aspx");
            string mensagem = "Venda feita com sucesso!";
            string url = "../../VendaPecas.aspx";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "'); location='" + url + "';", true);
            return;

        }


        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }
        public void BaixaEstoque()
        {
            Dao D = new Dao();
            List<pCarrinho> Lp = Session["Carrinho"] as List<pCarrinho>;
            for (int i = 0; i < Lp.Count; i++)
            {
                D.VendPecas(Lp[i].Cod_Pecas, Lp[i].pQuantidade);

            }
        }
        public void InserirPedido()
        {
            List<pFuncionario> LF = Session["Login"] as List<pFuncionario>;
            pPedido P = new pPedido();
            P.ValorTotal = Convert.ToDecimal(TotalC.Text);
            P.FormaPagamento = FormaP.Text;
            P.DataPagamento = Convert.ToDateTime(DataH.Text);
            int Cod = Convert.ToInt32(ddlCliente.SelectedValue);
            P.Cod_ClienteFK = Cod;
            P.Cod_Pedido = Convert.ToInt32(lblCodPedido.Text);
            P.Matr_FuncFK = LF[0].Matr_Func;
            mPedido M = new mPedido();
            M.InsPedido(P);
        }
        public void RetornaCod()
        {
            Dao D = new Dao();
            SqlConnection Cn = D.SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select MAX(Cod_Pedido) From tbPedido");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            Cod_Pedido = Convert.ToInt32(cmd.ExecuteScalar());
            lblCodPedido.Text = Convert.ToString(Cod_Pedido);
            Cn.Close();
            List<pCarrinho> Lp = Session["Carrinho"] as List<pCarrinho>;
            for (int i = 0; i < Lp.Count; i++)
            {
                D.InsItemPedido(Lp[i].Cod_Pecas, Lp[i].Descricao, Lp[i].Valor_Saida, Lp[i].pQuantidade, Lp[i].Total, Cod_Pedido);
                //D.InsItemPedido(Lp[i].Cod_Pecas, Lp[i].pQuantidade, Cod_Pedido);
            }
        }


    }
}


