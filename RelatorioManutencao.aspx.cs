using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace SlnArCond
{
    public partial class RelatorioManutencao : System.Web.UI.Page
    {
        DateTime Data1;
        DateTime Data2;
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

        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }


        protected void btnBuscarData_Click(object sender, EventArgs e)
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
                mManuAr M = new mManuAr();
                List<pDataManu> LC = M.RelatorioManutencaoData(Data1, Data2);
                gdvManu.DataSource = LC;
                gdvManu.DataBind();
                //Codigo = Codigo + gdvListaPecas.Rows.Count;
                //txtTotalVenda.Text = Convert.ToString(Codigo);
                //for (int i = 0; i < LC.Count; i++)
                //{
                //    Valor = Valor + LC[i].ValorTotal;

                //}
                //txtTotalValor.Text = Convert.ToString(Valor);
                RelManu.Visible = true;
                lblHed.Text = ("Inicial - " + Data1.ToString("dd/MM/yyyy") + " Final - " + Data2.ToString("dd/MM/yyyy"));
            }
        }

        protected void btnBuscarStatus_Click(object sender, EventArgs e)
        {
            mManuAr M = new mManuAr();
            List<pDataManu> LC = M.RelatorioManutencaoStatus(ddlStatus.Text);
            gdvManu.DataSource = LC;
            gdvManu.DataBind();
            lblHed.Text = ("Status da manutenção : " + ddlStatus.Text);
            RelManu.Visible = true;
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            Msg("PDF gerado com sucesso!");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Relatorio.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            RelManu.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 100f, 0f);
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