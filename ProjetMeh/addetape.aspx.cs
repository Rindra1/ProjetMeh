using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using BLL;
using BEL;
using System.Web.Services;
using System.Web.Configuration;

namespace ProjetMeh
{
    public partial class addetape : System.Web.UI.Page
    {
        private SqlConnection cnx = new SqlConnection(WebConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;
        private ActionBLL action = new ActionBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pseudo"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Params["id"]))
                        Remplir();
                    else
                        Server.Transfer("accueil.aspx");
                }
                else
                {
                    Server.Transfer("connexion.aspx");
                }

            }
        }

        private void Remplir()
        {
            try
            {
                string text = "";
                string id = Request.Params["id"];
                string sql = "select c.nomcor,c.prenomcor,c.emailcor,c.telcor" +
                    ",s.libservice,d.libdir,e.libentite from Correspondants c " +
                    " LEFT OUTER JOIN Services s on s.idservice=c.idservice " +
                    " LEFT OUTER JOIN Directions d on d.iddir=s.iddir OR d.iddir=c.iddir " +
                    " left outer join Entites e on e.identite=d.identite Left outer join " +
                    " Projets p on p.idcor=c.idcor where p.idprojet='" + int.Parse(id) + "'";
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        text += "<label style='color:blue'>Entite:</label><br/>" + read["libentite"].ToString().Trim().ToUpper() + "<br/>";
                        text += "<label style='color:blue'>Direction :</label><br/>" + read["libdir"].ToString().Trim() + "<br/>";
                        text += "<label style='color:blue'>Service :</label><br/>" + read["libservice"].ToString().Trim().ToLower() + "<br/>";

                        text += "<label style='color:blue'>Agent résponsable:</label><br/>" + read["nomcor"].ToString().Trim().ToUpper() + " " + read["prenomcor"].ToString().Trim().ToLower() + "<br/>";
                        text += "<label style='color:blue'>Téléphone :</label><br/>" + read["telcor"].ToString().Trim() + "<br/>";
                        text += "<label style='color:blue'>E-mail:</label><br/>" + read["emailcor"].ToString().Trim().ToLower() + "<br/>";

                    }
                }
                read.Close();
                cnx.Close();
                entite.InnerHtml = text;
            }
            catch 
            {
                Response.Redirect("accueil.aspx");
            }
        }

        [WebMethod]
        public static List<Projets> GetProjet(string id)
        {
            int idp = Convert.ToInt32(id);
            ActionBLL action = new ActionBLL();
            List<Projets> Liste = new List<Projets>();
            List<Projets> Liste1 = new List<Projets>();
            Liste = action.GetProjet();
            var result = Liste.First(f => f.IdProjet == idp);
            //Liste.Clear();
            Liste1.Add(new Projets
            {
                Numero = result.Numero,
                Promoteur = result.Promoteur,
                Source = result.Source,
                Titre = result.Titre,
                Type = result.Type,
                Capacite = result.Capacite
            });
            return Liste1;
        }
        protected void bt_add_Click(object sender, EventArgs e)
        {
            try
            {
                string idprojet = Request.Params["id"];
                Etapes etapes = new Etapes();
                string txtdebut = Request.Form["txtdebut"];
                string txtfin = Request.Form["txtfin"];
                string txtetape = Request.Form["txtetapes"];
                string txtsituation = Request.Form["txtsituation"];
                string txtcontrainte = Request.Form["txtcontrainte"];
                string txtsolution = Request.Form["txtsolution"];
                string txtobs = Request.Form["txtobs"];
                string ddletat = Request.Form["ddletat"];
                string ddlurgence = Request.Form["ddlurgence"];

                string[] etape = txtetape.Split(',');
                string[] debut = txtdebut.Split(',');
                string[] fin = txtfin.Split(',');

                string[] situation = txtsituation.Split(',');
                string[] contrainte = txtcontrainte.Split(',');
                string[] solution = txtsolution.Split(',');

                string[] obs = txtobs.Split(',');
                string[] etat = ddletat.Split(',');
                string[] urgence = ddlurgence.Split(',');

                for (int i = 0; i < etape.Length; i++)
                {
                    if (etape[i] != "")
                    {
                        etapes.IdProjet = int.Parse(idprojet);
                        etapes.Contrainte = contrainte[i];
                        etapes.Debut = debut[i];
                        etapes.Etat = etat[i];
                        etapes.Fin = fin[i];
                        etapes.LibEtape = etape[i];
                        etapes.Obs = obs[i];
                        etapes.Solution = solution[i];
                        etapes.Urgence = urgence[i];
                        etapes.Situation = situation[i];


                        action.AddAvancement(etapes);
                    }
                }
                lblmsg.Text = "Etapes ajouter avec succès!";
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
            }
            catch (Exception ex)
            {
                string text1 = "";
                text1 += "<div class='alert alert-danger fade in'>";
                text1 += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
                text1 += " <strong>L'erreur suivante a été rencontré :" + ex.Message + "<br/>Veuillez consulter votre administrateur</strong>";
                text1 += "</div>";
                lblerreur.InnerHtml = text1;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("accueil.aspx");
        }
    }
}