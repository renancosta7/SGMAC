using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SlnArCond
{
    public partial class RelatorioFinanceiro : System.Web.UI.Page
    {
        DateTime DataM;
        DateTime DataV;
        decimal Dinheiro = 0;
        decimal Credito = 0;
        decimal Debito = 0;
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
                RelFinanceiro.Visible = true;

            }

        }
        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtData.Text == string.Empty)
            {
                Msg("Selecione a data!");
                return;
            }
            else
            {

                mRelatorio M = new mRelatorio();
                DataM = Convert.ToDateTime(txtData.Text);
                List<pManuAr> LC = M.RelatorioFinanceiroManu(DataM);
                gdvManu.DataSource = LC;
                gdvManu.DataBind();
                DataV = Convert.ToDateTime(txtData.Text);
                List<pPedido> LP = M.RelatorioFinanceiroVenda(DataV);
                gdvVenda.DataSource = LP;
                gdvVenda.DataBind();
                GerarPdf.Visible = true;
                btnexportar.Visible = true;
                if (LC.Count == 0 && LP.Count == 0)
                {
                    Msg("Não existe dados para o dia - " + txtData.Text);
                    GerarPdf.Visible = false;
                    btnexportar.Visible = false;
                    return;
                }
                else
                {
                    for (int i = 0; i < LC.Count; i++)
                    {
                        if (LC[i].FormaPagamento == "Dinheiro")
                        {
                            Dinheiro = Dinheiro + LC[i].ValorMObra;
                        }
                        else if (LC[i].FormaPagamento == "Cartao de Credito")
                        {
                            Credito = Credito + LC[i].ValorMObra;
                        }
                        else if (LC[i].FormaPagamento == "Cartao de Credito")
                        {
                            Debito = Debito + LC[i].ValorMObra;
                        }

                    }
                    for (int i = 0; i < LP.Count; i++)
                    {
                        if (LP[i].FormaPagamento == "Dinheiro")
                        {
                            Dinheiro = Dinheiro + LP[i].ValorTotal;
                        }
                        else if (LP[i].FormaPagamento == "Cartao de Credito")
                        {
                            Credito = Credito + LP[i].ValorTotal;
                        }
                        else if (LP[i].FormaPagamento == "Cartao de Debito")
                        {
                            Debito = Debito + LP[i].ValorTotal;
                        }


                    }
                    lblRela.Text = "Relatório do dia - " + DataM.ToString("dd/MM/yyyy");
                    lblDinheiro.Text = Dinheiro.ToString("C");
                    lblDebito.Text = Debito.ToString("C");
                    lblCredito.Text = Credito.ToString("C");
                    lblTotal.Text = (Dinheiro + Debito + Credito).ToString("C");
                }
            }
        }

        protected void btnexportar_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Relatorio Financeiro.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GerarPdf.RenderControl(hw);
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
            txtData.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");

        }




    }
}