using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;
using System.Text;

namespace ProjetMeh
{
    public partial class addprojet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pan.Controls.Add(new Literal { Text = RemplirTableau() });            
        }

        public string RemplirTableau()
        {
            AccueilBLL acc = new AccueilBLL();                
            string page = Request.Params["page"];
            
            string texte=acc.Remplir1(page, Session["id"].ToString(), Session["role"].ToString().ToUpper().Trim(),Session["iddir"].ToString());
            string[] split = texte.Split('*');
            string text = Convert.ToString(split[0]);
            string text1 = Convert.ToString(split[1]);
            string action = Request.Params["action"];
            string id = Request.Params["id"];
            switch (action)
            {
                case "supprimer":
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog1('" + true + "');", true);
                    break;

            }
            return text;
        }

        public string Remplir()
        {
            AccueilBLL acc = new AccueilBLL();
            Projets pr = new Projets();
            Correspondants cor = new Correspondants();
            Directions dir = new Directions();
            Services ser = new Services();
            Entites ent = new Entites();
            Etapes eta = new Etapes();
            District dis = new District();
            Region reg = new Region();

            try
            {
                string page = Request.Params["page"];
                string test = "";


                dis.LibDistrict = rchdistrict.Text;
                reg.LibRegion = rchregion.Text;

                pr.Capacite = rchcapacite.Text;
                pr.Numero = rchnum.Text;
                pr.Promoteur = rchpromoteur.Text;
                pr.Source = rchsource.Text;
                pr.Titre = rchtitre.Text;
                pr.Type = rchtype.Text;

                cor.EmailCor = rchmail.Text;
                cor.NomCor = rchnom.Text;
                cor.PrenomCor = rchprenom.Text;
                cor.TelCor = rchtel.Text;

                dir.LibDir = rchdir.Text;
                ser.LibService = rchser.Text;
                ent.LibEntite = rchentite.Text;

                eta.Contrainte = rchcontrainte.Text;
                eta.Debut = Request.Form["rcdebut"];
                eta.Etat = rchetat.Text.Trim();
                eta.Fin = Request.Form["rcfin"];
                eta.LibEtape = rchetape.Text;
                eta.Obs = rchobs.Text;
                eta.Solution = rchsolution.Text;
                eta.Urgence = rchurgence.Text;

                string texte = acc.Remplir(test, dir, ser, ent, pr, eta, reg, dis, cor, Session["id"].ToString(), Session["role"].ToString().ToUpper().Trim(), Session["iddir"].ToString());
                string[] split = texte.Split('*');
                string text = Convert.ToString(split[0]);
                string text1 = Convert.ToString(split[1]);
                string action = Request.Params["action"];
                string id = Request.Params["id"];
                switch (action)
                {
                    case "supprimer":
                        ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog1('" + true + "');", true);
                        break;

                }
                return text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                acc = null;
                pr = null;
                cor = null;
                dir = null;
                ser = null;
                ent = null;
                eta = null;
                dis = null;
                reg = null;

            }
        }

        
        protected void btajouter_Click(object sender, EventArgs e)
        {
            Correspondants cor = new Correspondants();
            Services ser = new Services();
            Directions dir = new Directions();
            Projets pr = new Projets();
            Etapes etapes = new Etapes();
            Region regions = new Region();
            District districts = new District();
            ActionBLL action = new ActionBLL();
            try
            {
                int numero = 0;
                int idcor = 0;
                int iddir = 0;
                int idservice = 0;
                int idprojet = 0;

                dir.LibDir = txtdirection.Text.Trim().ToUpper();
                dir.IdEntite = Convert.ToInt32(ddlentite.SelectedValue);
                iddir = action.TestDir(dir);

                cor.NomCor = txtnom.Text.Trim().ToUpper();
                cor.PrenomCor = txtprenom.Text.Trim().ToLower();
                cor.TelCor = txttel.Text.Trim();
                cor.EmailCor = txtmail.Text.Trim().ToLower();

                if (txtservice.Text != "")
                {

                    ser.IdDir = iddir;
                    ser.LibService = txtservice.Text.Trim().ToUpper();
                    idservice = action.TestService(ser);

                    cor.IdService = idservice;
                    cor.IdCor = 0;
                    idcor = action.TestCor(cor);
                }
                else
                {
                    cor.IdDir = iddir;
                    cor.IdService = 0;
                    idcor = action.TestCor(cor);
                }

                List<Projets> ListeProjet = new List<Projets>();
                ListeProjet = action.GetProjet();
                var num = ListeProjet.Count;

                numero = num + 1;
                if (Session["id"] != null)
                {
                    pr.IdEnr = int.Parse(Session["id"].ToString());
                }
                else
                {
                    Response.Redirect("connexion.aspx");
                }
                pr.Numero = numero + "-" + ddlentite.SelectedItem.Text.Trim();
                pr.IdCor = idcor;
                pr.Capacite = txtcapacite.Text.Trim();
                pr.Promoteur = txtpromoteur.Text.Trim().ToUpper();
                pr.Source = txtsource.Text.Trim().ToUpper();
                pr.Titre = txttitre.Text.Trim().ToUpper();
                pr.Type = txttype.Text.Trim().ToUpper();

                idprojet = action.AddProjet(pr);

                string region = Request.Form["txtregion"];
                string district = Request.Form["txtdistrict"];

                string[] reg = region.Split(',');
                string[] dis = district.Split(',');

                foreach (var re in reg)
                {
                    regions.IdProjet = idprojet;
                    regions.LibRegion = re;
                    action.AddRegion(regions);

                }

                foreach (var di in dis)
                {
                    districts.IdProjet = idprojet;
                    districts.LibDistrict = di;
                    action.AddDistrict(districts);
                }
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

                    if (debut[i] == "")
                    {
                        etapes.Debut = "31-12-2016";
                    }
                    else
                    {
                        etapes.Debut = debut[i];
                    }

                    if (fin[i] == "")
                    {
                        etapes.Fin = "31-12-2016";
                    }
                    else
                    {
                        etapes.Fin = fin[i];
                    }
                    etapes.IdProjet = idprojet;
                    etapes.Contrainte = contrainte[i];
                    etapes.Etat = etat[i];
                    etapes.LibEtape = etape[i];
                    etapes.Obs = obs[i];
                    etapes.Solution = solution[i];
                    etapes.Urgence = urgence[i];
                    etapes.Situation = situation[i];

                    action.AddAvancement(etapes);
                }
                lblmsg.Text = "Projets ajouter avec succés!";
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
            finally
            {
                cor = null;
                ser = null;
                dir = null;
                pr = null;
                etapes = null;
                regions = null;
                districts = null;
                action = null;            
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("addprojet.aspx");
        }

        protected void rechercher_Click(object sender, EventArgs e)
        {
            resultatrecherche.Controls.Add(new Literal{ Text = Remplir()});
            pan.Controls.Clear();
            panelp.Visible = true;
            paneladd.Visible = false;
            pan.Visible = false;
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Projets projet = new Projets();
            ActionBLL action = new ActionBLL();
            Etapes etape = new Etapes();
            List<Etapes> liste = new List<Etapes>();
            List<Projets> ListeProjet = new List<Projets>();
            ListeProjet = action.GetProjet();
            string id=Request.Params["id"];
            
                liste = action.GetAvancement();
                var pr = ListeProjet.First(f => f.IdProjet == int.Parse(id));
                projet.IdEnr = int.Parse(Session["id"].ToString());
                projet.IdProjet = int.Parse(id);
                var suppr = liste.FindAll(f => f.IdProjet == int.Parse(id));
                

                int ida = action.DeleteProjet(projet);
                if (ida > 0)
                {
                    Response.Redirect("addprojet.aspx");
                }
                else
                {
                }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("addprojet.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            panelp.Controls.Clear();
            panelp.Visible = false;
            paneladd.Visible = false;
            pan.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            resultatrecherche.Controls.Add(new Literal { Text = Remplir() });
            pan.Controls.Clear();        
        
            panelp.Visible = true;
            paneladd.Visible = false;
            pan.Visible = false;
        }
        

        protected void bt_add_Click(object sender, EventArgs e)
        {
            resultatrecherche.Controls.Clear();
            pan.Controls.Clear(); 
        
            panelp.Visible = false;
            paneladd.Visible = true;
            pan.Visible = false;
        }
    }
}