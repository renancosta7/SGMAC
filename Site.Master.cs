using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlnArCond
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            List<pFuncionario> Lp = Session["Login"] as List<pFuncionario>;

            if (Session["Login"] != null && (Session["Login"] as List<pFuncionario>).Count > 0)
            {
                lblUsuario.Text = ("Olá, " + Lp[0].Nome);

            }
            else
            {

            }
            //if (Lp == null)
            //{
            //    return;
            //}
            //else
            //{
            //    lblUsuario.Text = ("Olá, " + Lp[0].Nome);
            //}
        }
       
        protected void btnDeslogar_Click(object sender, EventArgs e)
        {

            List<pFuncionario> Lp = Session["Login"] as List<pFuncionario>;
            Session.RemoveAll();
            Response.Redirect("Login.aspx");

        }
        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");
        }

    }
}
