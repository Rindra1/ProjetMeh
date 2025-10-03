using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;
using BLL;
using BEL;
using System.Web.Services;

namespace ProjetMeh
{
    public partial class update : System.Web.UI.Page
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
                    if (!string.IsNullOrEmpty(Request.Params["id"]) && (Session["role"].ToString().Trim().ToUpper() == "SUPERVISEUR"
                        || Session["role"].ToString().Trim().ToUpper() == "SUPER UTILISATEUR"
                        || Session["role"].ToString().Trim().ToUpper() == "ADMINISTRATEUR"))
                    {
                        Remplir();
                    }
                    else
                    {
                        Response.Redirect("accueil.aspx");
                    }

                }
                else
                {
                    Response.Redirect("connexion.aspx");
                }

            }
        }

        protected void bt_update_Click(object sender, EventArgs e)
        {
            try
            {
                Etapes etap = new Etapes();

                string txtetape = Request.Form["txtetape"];
                string txtid = Request.Form["id"];
                string txturgence = Request.Form["ddlurgence"];
                string txtobs = Request.Form["txtobs"];
                string txtcontrainte = Request.Form["txtcontrainte"];
                string txtsolution = Request.Form["txtsolution"];
                string txtetat = Request.Form["txtetat"];
                string txtdebut = Request.Form["txtdebut"];
                string txtfin = Request.Form["txtfin"];
                string txtsituation = Request.Form["txtsituation"];



                string[] etape = txtetape.Split(',');
                string[] id = txtid.Split(',');
                string[] contrainte = txtcontrainte.Split(',');

                string[] situation = txtsituation.Split(',');
                string[] urgence = txturgence.Split(',');
                string[] obs = txtobs.Split(',');
                string[] solution = txtsolution.Split(',');
                string[] debut = txtdebut.Split(',');
                string[] fin = txtfin.Split(',');
                string[] etat = txtetat.Split(',');


                for (int i = 0; i < debut.Length; i++)
                {
                    etap.IdEtape = Convert.ToInt32(id[i]);
                    etap.LibEtape = etape[i];
                    etap.Contrainte = contrainte[i];
                    /*
                    if (debut[i] == "")
                    {
                        etap.Debut = "31-12-2016";
                    }
                    else
                    {
                        etap.Debut = debut[i];
                    }

                    if (fin[i] == "")
                    {
                        etap.Fin = "31-12-2016";
                    }
                    else
                    {
                        etap.Fin = fin[i];
                    }
                    */
                    etap.Debut = debut[i];
                    
                    etap.Etat = etat[i];
                    
                    etap.Fin = fin[i];
                    etap.Obs = obs[i];
                    etap.Situation = situation[i];
                    etap.Solution = solution[i];
                    etap.Urgence = urgence[i];

                     int test = action.UpdateAvancement(etap);

                     lblmsg.Text = "Etapes Modifier avec succès!" + etap.Fin + "<br/>" + test;
                     ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
            
                }
            }
            catch (Exception ex)
            {
                Response.Write("Erreur :" + ex.Message + "<br/>" + ex.StackTrace);
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

                cnx.Close();
                entite.InnerHtml = text;
            }
            catch 
            {
                Response.Write("Veuillez selectionner projet dans accueil");
            }
        }

        [WebMethod]
        public static List<Projets> GetProjet(string id)
        {
            int idp = Convert.ToInt32(id);
            ActionBLL action = new ActionBLL();
            List<Projets> Liste = new List<Projets>();
            Liste = action.GetProjet();
            var result = Liste.First(f => f.IdProjet == idp);
            Liste.Clear();
            Liste.Add(new Projets
            {
                Numero = result.Numero,
                Promoteur = result.Promoteur,
                Source = result.Source,
                Titre = result.Titre,
                Type = result.Type,
                Capacite = result.Capacite
            });
            return Liste;
        }

        [WebMethod]
        public static List<Etapes> GetEtat(string id)
        {
            int idp = Convert.ToInt32(id);
            ActionBLL action = new ActionBLL();
            List<Etapes> Liste = new List<Etapes>();
            List<Etapes> Liste1 = new List<Etapes>();

            Liste = action.GetAvancement();
            foreach (var result in Liste)
            {
                if (result.IdProjet == idp)
                {
                    Liste1.Add(new Etapes
                    {
                        IdEtape = result.IdEtape,
                        LibEtape = result.LibEtape,
                        Situation = result.Situation,
                        Urgence = result.Urgence,
                        Obs = result.Obs,
                        Contrainte = result.Contrainte,
                        Solution = result.Solution,
                        Etat = result.Etat,
                        Debut = result.Debut,
                        Fin = result.Fin
                    });
                }
            }
            return Liste1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("accueil.aspx");
        }
    }
}