using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BEL;
using BLL;

namespace ProjetMeh
{
    public partial class connexion : System.Web.UI.Page
    {
        private ActionBLL action ;
        private List<Comptes> ListeL;
        private Comptes L;
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void btconnexion_Click(object sender, EventArgs e)
        {            
                HttpCookie cookie;
                if (Authentification(Request.Form["txtpseudo"], Request.Form["txtmdp"]))
                {
                   
                    cookie = FormsAuthentication.GetAuthCookie(Request.Form["txtpseudo"], chk.Checked);
                    if (chk.Checked)
                    {
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);
                        string targeturl;
                        targeturl = FormsAuthentication.GetRedirectUrl(Request.Form["txtpseudo"], true);
                        Response.Redirect(targeturl);
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(Request.Form["txtpseudo"], false);
                    }
                }
                else if (FormsAuthentication.Authenticate(Request.Form["txtpseudo"], Request.Form["txtmdp"]))
                {
                    Session["role"] = "Administrateur";
                    Session["id"] = 1;
                    Session["pseudo"] = "Rindra";
                    FormsAuthentication.RedirectFromLoginPage(Request.Form["txtpseudo"], chk.Checked);
                }
                else
                {
                    string text1 = "";
                    text1 += "<div class='alert alert-danger fade in'>";
                    text1 += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
                    text1 += " <strong>Votre Pseudo ou votre Mot de passe est incorrecte</strong>" ;
                    text1 += "</div>";
                    lblerreur.InnerHtml = text1;
                }            
        }

        private bool Authentification(string pseudo, string mdp)
        {
            action = new ActionBLL();
            L = new Comptes();
            ListeL = new List<Comptes>();
            ListeL = action.GetLogins();
            List<Correspondants> Cor = new List<Correspondants>();
            List<Directions> Dir = new List<Directions>();
            List<Services> Ser = new List<Services>();
            Cor = action.GetCorrespondant();
            Dir = action.GetDirection();
            Ser = action.Getservice();
            var testlogin = ListeL.Exists(f => f.Pseudo == pseudo && f.Code == FormsAuthentication.HashPasswordForStoringInConfigFile(mdp, "MD5"));
            if (testlogin)
            {
                var login = ListeL.First(f => f.Pseudo == pseudo && f.Code == FormsAuthentication.HashPasswordForStoringInConfigFile(mdp, "MD5"));
                var TestCor = Cor.Exists(f =>f.IdCor==login.IdCor && f.IdDir != 0);
                if (TestCor)
                {
                    var IdCor = Cor.First(f => f.IdCor == login.IdCor && f.IdDir != 0);
                    Session["iddir"] = IdCor.IdCor;
                }
                else
                {
                    var IdCor = Cor.First(f => f.IdCor == login.IdCor && f.IdService != 0);
                    var IdSer = Ser.First(f => f.IdService == IdCor.IdService);
                    var IdDir = Dir.First(f => f.IdDir == IdSer.IdDir);
                    var IdCor1 = Cor.First(f => f.IdDir == IdDir.IdDir);
                    Session["iddir"] = IdCor1.IdCor;
                }                    
                Session["pseudo"] = pseudo;
                Session["role"] = login.Role;
                Session["id"] = login.IdCor;
                Session["idlogin"] = login.IdLogin;
                return true;
            }
            else
                return false;
        }

        protected void lnknouveau_Click(object sender, EventArgs e)
        {
            Response.Redirect("nouveau.aspx");
        }
    }
}