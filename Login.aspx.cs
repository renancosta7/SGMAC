using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace SlnArCond
{
    public partial class Login : System.Web.UI.Page
    {
        int Matricula;
        string Senha;
        string Nivel;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {

            if (txtMatr.Text == string.Empty || txtSenha.Text == string.Empty)
            {
                Msg("Matrícula ou Senha em branco !");
                return;
            }
            else
            {
                Matricula = Convert.ToInt32(txtMatr.Text);
                Senha = txtSenha.Text;
                mLogin M = new mLogin();
                List<pFuncionario> Lc = M.Login(Matricula, Senha);
                Session["Login"] = Lc;
                if (Session["Login"] != null && (Session["Login"] as List<pFuncionario>).Count > 0)
                {
                    Nivel = Lc[0].Cargo;
                    Response.Redirect("MenuPrincipal.aspx");

                }
                else
                {
                    Msg("Matrícula ou Senha Inválida!");
                    txtSenha.Text = string.Empty;
                    txtMatr.Text = string.Empty;
                }

            }
        }

        private void Msg(string Aviso)
        {
            Response.Write("<script>alert('" + Aviso + "');</script>");


        }
    }
}