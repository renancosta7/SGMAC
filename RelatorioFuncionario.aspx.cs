using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class RelatorioFuncionario : System.Web.UI.Page
    {

        DateTime Data1;
        DateTime Data2;
        int Codigo;
        int Cod_Venda;
        string Dinheiro = "Dinheiro";
        string Debito = "Cartao de Debito";
        string Credito = "Cartao de Credito";
        decimal Din;
        decimal Deb;
        decimal Cre;
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
                Geral.Visible = true;

            }

            if (!IsPostBack)
            {
                ListaFuncionario();
            }
        }
        public void ListaFuncionario()
        {
            mFuncionario M = new mFuncionario();
            List<pFuncionario> Lc = M.SelFun();
            ddlFuncionario.DataTextField = "Nome";
            ddlFuncionario.DataValueField = "Matr_Func";
            ddlFuncionario.DataSource = Lc;
            ddlFuncionario.DataBind();
        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtData1.Text == string.Empty)
            {
                Msg("Selecione a data!");
                return;
            }
            else if (txtData2.Text == string.Empty)
            {
                Msg("Selecione a data!");
                return;
            }
            else
            {
                Data1 = Convert.ToDateTime(txtData1.Text);
                Data2 = Convert.ToDateTime(txtData2.Text);
                lblInicial.Text = Data1.ToString("dd/MM/yyyy");
                lblFinal.Text = Data2.ToString("dd/MM/yyyy");
                mPedido M = new mPedido();
                pFuncionario K = new pFuncionario();
                int Cod = Convert.ToInt32(ddlFuncionario.SelectedValue);
                K.Matr_Func = Cod;
                List<pDataPedido> L1 = M.RelatorioVendaFunc(Dinheiro, Data1, Data2, Cod);
                List<pDataPedido> L2 = M.RelatorioVendaFunc(Debito, Data1, Data2, Cod);
                List<pDataPedido> L3 = M.RelatorioVendaFunc(Credito, Data1, Data2, Cod);
                gdvListaPecas1.DataSource = L1;
                gdvListaPecas1.DataBind();
                gdvListaPecas2.DataSource = L2;
                gdvListaPecas2.DataBind();
                gdvListaPecas3.DataSource = L3;
                gdvListaPecas3.DataBind();
                Codigo = Codigo + gdvListaPecas1.Rows.Count;
                Codigo = Codigo + gdvListaPecas2.Rows.Count;
                Codigo = Codigo + gdvListaPecas3.Rows.Count;
                lblVendas.Text = Convert.ToString(Codigo);
                for (int i = 0; i < L1.Count; i++)
                {
                    Din = Din + L1[i].ValorTotal;

                }
                for (int i = 0; i < L2.Count; i++)
                {
                    Deb = Deb + L2[i].ValorTotal;

                }
                for (int i = 0; i < L3.Count; i++)
                {
                    Cre = Cre + L3[i].ValorTotal;

                }
                lblDinheiro.Text = Din.ToString("C");
                lblDebito.Text = Deb.ToString("C");
                lblCredito.Text = Cre.ToString("C");
                lblTotalVenda.Text = (Din + Deb + Cre).ToString("C");

                RelVenda.Visible = true;

            }
        }

        protected void gdvListaPecas1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gdvListaPecas2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gdvListaPecas3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            Msg("PDF gerado com sucesso!");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Relatorio.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            RelVenda.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfPage page = new pdfPage();
            pdfWriter.PageEvent = page;
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }



        public override void VerifyRenderingInServerForm(Control control)
        {


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtData1.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtData2.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
        }

    }
}

