using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;
using System.Web.Security;
using System.Text;

namespace ProjetMeh
{
    public partial class comptes : System.Web.UI.Page
    {
        private ActionBLL action;
        private StringBuilder build;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Comptes> Liste = new List<Comptes>();
            if (!IsPostBack)
            {
                if (Session["idlogin"] != null)
                {
                    try
                    {
                        action = new ActionBLL();
                        Liste = action.GetLogins();
                        var test = Liste.First(f => f.IdLogin == int.Parse(Session["idlogin"].ToString()));
                        txtpseudo.Text = test.Pseudo;
                    }
                    finally
                    {
                        Liste.Clear();
                        action = null;
                    }
                }
            }
        }

        protected void bt_ok_Click(object sender, EventArgs e)
        {
            build = new StringBuilder();
            action = new ActionBLL();
            Comptes com = new Comptes();
            List<Comptes> Liste = new List<Comptes>();
            try
            {
                com.IdLogin = int.Parse(Session["idlogin"].ToString());
                com.Pseudo = txtpseudo.Text;
                com.Code = FormsAuthentication.HashPasswordForStoringInConfigFile(txtmdp.Text,"MD5");
                Liste = action.GetLogins();
                var test = Liste.Exists(f => f.Pseudo.Trim().ToUpper() == com.Pseudo.Trim().ToUpper()
                    && f.IdLogin != int.Parse(Session["idlogin"].ToString()));
                if (test)
                {
                    build.Append("<div class='alert alert-danger fade in'>");
                    build.Append("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");
                    build.Append("<strong>Le Pseudo est déja utiliser par une autre personne  </strong>");
                    build.Append("</div>");
                    panel.Controls.Add(new Literal { Text = build.ToString() });    
                }
                else
                {
                    int resultat = action.UpdateLogin1(com);
                    if (resultat > 0)
                    {
                        lblmsg.Text = "Votre pseudo et mdp a été modifier";
                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog('" + true + "')", true);
                    }
                    else
                    {
                        build.Append("<div class='alert alert-danger fade in'>");
                        build.Append("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");
                        build.Append("<strong>Une erreur est survenue. Veuillez consulter votre administrateur</strong>");
                        build.Append("</div>");
                        panel.Controls.Add(new Literal { Text = build.ToString() });
                    }
                }

            }
            catch
            {
                build.Append("<div class='alert alert-danger fade in'>");
                build.Append("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");
                build.Append("<strong>Une erreur est survenue. Veuillez consulter votre administrateur</strong>");
                build.Append("</div>");
                panel.Controls.Add(new Literal { Text = build.ToString() });
            }
            finally
            {
                action = null;
                Liste.Clear();
                com = null;
                build.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("accueil.aspx");
        }
    }
}