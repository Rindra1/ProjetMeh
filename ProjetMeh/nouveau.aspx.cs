using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using BEL;

namespace ProjetMeh
{
    public partial class nouveau : System.Web.UI.Page
    {
        private NouveauComptes nouve;
        private ActionBLL action;
        private Comptes compte;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_ok_Click(object sender, EventArgs e)
        {
            nouve = new NouveauComptes();
            action = new ActionBLL();
            compte = new Comptes();
            List<Comptes> Listecompte = new List<Comptes>();
            try
            {
                Listecompte = action.GetLogins();
                var testcompte = Listecompte.Exists(t => t.Pseudo.Trim() == txtpseudo.Text.Trim());
                if (testcompte)
                {
                    Response.Write("pseudo déja pris");
                }
                else
                {
                    nouve._CodeN = FormsAuthentication.HashPasswordForStoringInConfigFile(txtmdp.Text.Trim(), "MD5");
                    nouve._DirectionN = txtfonction.Text.Trim();
                    nouve._EmailN = txtmail.Text.Trim();
                    nouve._EntiteN = ddlentite.SelectedItem.Text.Trim();
                    nouve._NomN = txtnom.Text.Trim();
                    nouve._PrenomN = txtprenom.Text.Trim();
                    nouve._PseudoN = txtpseudo.Text.Trim();
                    nouve._ServiceN = txtservice.Text.Trim();
                    nouve._TelN = txttel.Text.Trim();
                    int resultat = action.AddNouveau(nouve);
                    if (resultat > 0)
                    {

                        try
                        {
                            action.MessageMail("gmail", "minerg101@gmail.com", "minerg101@gmail.com", "Demande de confirmation", "quelqu'un souhaite rejoindre le site", "Minerg118");
                        }
                        catch
                        {

                        }
                        lblmsg.Text = "Votre Compte à été enregistrer!<br/>vous allez recevoir un message de confirmation!";
                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog('" + true + "');", true);
                    }
                    else
                    {
                        lblmsg.Text = "Un erreur est survenue, veuillez reessayer ulterieurement!";
                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog('" + true + "');", true);
                    }
                }
            }
            catch
            {
                lblmsg.Text = "Une erreur a été rencontré";
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog('" + true + "');", true);

            }
            finally
            {
                nouve = null;
                action = null;
                compte = null;
                Listecompte.Clear();
            }
        }

        protected void bt_annuler_Click(object sender, EventArgs e)
        {
            Server.Transfer("connexion.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("connexion.aspx");
        }
    }
}