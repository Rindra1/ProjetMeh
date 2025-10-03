using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using BEL;
using BLL;

namespace ProjetMeh
{
    public partial class demande : System.Web.UI.Page
    {
        private ActionBLL action;
        private Comptes compte;
        private Correspondants cor;
        private Services service;
        private Entites entites;
        private Directions dir;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    Remplir();
            }
            else
            {
                Remplir();
            }
            
        }

        private void Remplir()
        {
            char guillemet = '"';
            int identite = 0;
            int iddir = 0;
            int idservice = 0;
            int idcor = 0;


            action = new ActionBLL();
            compte = new Comptes();
            cor = new Correspondants();
            service = new Services();
            dir = new Directions();
            entites = new Entites();
            List<NouveauComptes> Liste = new List<NouveauComptes>();
            Liste = action.GetAllNouveau();

            try
            {

                string text = "";
                text += "<table id='tablepaging' style='max-width:400px'>";
                text += "<tr><td>Liste Des Demandes</td></tr>";
                foreach (var n in Liste)
                {
                    text += "<tr class='even'><td>";
                    text += "<div class='col-sm-12'>";
                    text += "<div class='panel panel-primary'>";
                    text += "<div class='panel panel-heading'>";
                    text += "<h3 class='panel-title'><a id='bt_" + n._IdNouveau + "' href='JavaScript:expandcollapse1(" + guillemet + n._IdNouveau + guillemet + "," + guillemet + n._EntiteN + guillemet + ");'>" + n._EntiteN + "</a></h3>";
                    text += "</div><div id='" + n._IdNouveau + "'><div class='panel panel-body'>";
                    text += "<label>Entite :</label><br>" + n._EntiteN + "<br/>";
                    text += "<label>Direction :</label><br/>";
                    text += n._DirectionN + "<br/>";
                    text += "<label>Service :</label><br/>";
                    text += n._ServiceN + "<br/>";
                    text += "<label>Nom et prénom:</label><br/>";
                    text += n._NomN.Trim().ToUpper() + " " + n._PrenomN.Trim().ToLower() + "<br/>";
                    text += "<label>E-mail :</label><br/>";
                    text += n._EmailN + "<br/>";
                    text += "<label>Téléphone :</label><br/>";
                    text += n._TelN + "<br/>";
                    text += "<a class='btn btn-success' href='demande.aspx?action=ajouter&id=" + n._IdNouveau + "&role=" + ddlentite.SelectedItem.Text + "'>Ajouter</a><br/>";
                    text += "</div></div></div></div>";
                    text += "</td></tr>";

                }
                text += "</table>";
                text += "<div id='pageNavposition' style='padding-top:0; text-align:center'></div>";
                text += "<script type='text/javascript'>var pager = new Pager('tablepaging', 10);";
                text += "pager.init();pager.showPageNav('pager', 'pageNavposition');pager.showPage(1);";
                text += "</script>";
                panel.InnerHtml = text;
                string id = Request.Params["id"];
                string actions = Request.Params["action"];
                string role = Request.Params["role"];
                List<Correspondants> Listecor = new List<Correspondants>();
                Listecor = action.GetCorrespondant();
                if (!string.IsNullOrEmpty(actions))
                {
                    switch (actions)
                    {
                        case "ajouter":

                            var n = Liste.First(f => f._IdNouveau == int.Parse(id));

                            cor.NomCor = n._NomN.Trim().ToUpper();
                            cor.PrenomCor = n._PrenomN.Trim().ToLower();
                            cor.TelCor = n._TelN.Trim();
                            cor.EmailCor = n._EmailN.Trim();

                            compte.Pseudo = n._PseudoN.Trim();
                            compte.Role = role.Trim().ToUpper();
                            compte.Code = n._CodeN.Trim();

                            entites.LibEntite = n._EntiteN.Trim().ToUpper();
                            dir.LibDir = n._DirectionN;
                            if (!string.IsNullOrEmpty(n._ServiceN))
                                service.LibService = n._ServiceN.Trim().ToUpper();
                            identite = action.GetEntite(entites);
                            dir.IdEntite = identite;
                            iddir = action.TestDir(dir);
                            if (!string.IsNullOrEmpty(service.LibService))
                            {
                                service.IdDir = iddir;
                                idservice = action.TestService(service);
                                cor.IdService = idservice;
                                idcor = action.TestCor(cor);
                                compte.IdCor = idcor;
                                int idcompte = action.AddLogin(compte);
                                if (idcompte > 0)
                                {
                                    try
                                    {
                                        NouveauComptes nv = new NouveauComptes();
                                        nv._IdNouveau = int.Parse(id);
                                        action.DeleteNouveau(nv);
                                        action.MessageMail("smtp.gmail.com", n._EmailN, "minerg101@gmail.com", "Demande de confirmation", "Votre demande a été acceptée", "Minerg118");
                                        action.DeleteNouveau(n);
                                        lblmsg.Text = "Compte ajouter avec succès";
                                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                                    }
                                    catch
                                    {

                                        lblmsg.Text = "Compte ajouter avec succès.<br/> Impossible d'envoyer un email de confirmation!";
                                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = "Echec de l'enregistrement";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                                }
                            }
                            else
                            {
                                cor.IdDir = iddir;
                                idcor = action.TestCor(cor);
                                compte.IdCor = idcor;
                                int idcompte = action.AddLogin(compte);
                                if (idcompte > 0)
                                {
                                    try
                                    {
                                        NouveauComptes nv = new NouveauComptes();
                                        nv._IdNouveau = int.Parse(id);
                                        action.MessageMail("smtp.gmail.com", n._EmailN, "minerg101@gmail.com", "Demande de confirmation", "Votre demande a été acceptée", "Minerg118");
                                        action.DeleteNouveau(n);
                                        lblmsg.Text = "Compte ajouter avec succès";
                                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                                    }
                                    catch
                                    {
                                        lblmsg.Text = "Compte ajouter avec succès.<br/> Impossible d'envoyer un email de confirmation!";
                                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);

                                    }
                                }
                                else
                                {
                                    lblmsg.Text = "Echec de l'enregistrement";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                                }
                            }
                            break;
                    }
                }
            }
            catch
            {

            }
            finally
            {
                action = null;
                compte = null;
                cor = null;
                service = null;
                dir = null;
                entites = null;
                Liste.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("demande.aspx");
        }
    }
}