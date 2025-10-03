using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BEL;
using DAL;
using BLL;

namespace BLL
{
    public class AccueilBLL
    {
        private ActionBLL action=new ActionBLL();
        private Projets pr = new Projets();

        public string Remplir(string page, Directions dr,Services sr,Entites ett, Projets pr,Etapes etp,Region re,District dis,Correspondants co,string id ,string role,string iddir)
        {
            List<Projets> ListeProjet = new List<Projets>();
            List<District> ListeDistrict = new List<District>();
            List<Region> ListeRegion = new List<Region>();
            List<Correspondants> ListeCor = new List<Correspondants>();
            List<Directions> ListeDir = new List<Directions>();
            List<Services> ListeSer = new List<Services>();
            List<Entites> ListeEntite = new List<Entites>();
            List<Etapes> ListeEtape = new List<Etapes>();
    
            try
            {

                string txtdir = dr.LibDir;
                string txtser = sr.LibService;
                string txtentite = ett.LibEntite;

                string txtnum = pr.Numero;
                string txttitre = pr.Titre;
                string txttype = pr.Type;
                string txtpromoteur = pr.Promoteur;
                string txtsource = pr.Source;
                string txtcapacite = pr.Capacite;

                string txtcontrainte = etp.Contrainte;
                string txtdebut = etp.Debut;
                string txtfin = etp.Fin;
                string txtetat = etp.Etat;
                string txtetape = etp.LibEtape;
                string txtobs = etp.Obs;
                string txturgence = etp.Urgence;
                string txtsituation = etp.Situation;
                string txtsolution = etp.Solution;

                string txtnom = co.NomCor;
                string txtprenom = co.PrenomCor;
                string txttel = co.TelCor;
                string txtmail = co.EmailCor;

                string txtregion = re.LibRegion;
                string txtdistrict = dis.LibDistrict;

                int x = 1, z = 1, w = 0;
                string text1 = "";

                
                char guillemet = '"';
                ListeDistrict = action.GetDistrict();

                ListeRegion = action.GetRegion();

                ListeEtape = action.GetAvancement();

                
                pr.Numero = txtnum;

                ListeProjet = action.GetProjet();
                ListeCor = action.GetCorrespondant();
                ListeSer = action.Getservice();
                ListeDir = action.GetDirection();
                ListeEntite = action.GetEntite();

                
                var projet = ListeProjet.Where(f => f.Test.ToUpper().Trim() == "NOUVEAU");

                string text = "";
                
                if (!string.IsNullOrEmpty(txtnum) || !string.IsNullOrEmpty(txttitre)||
                    !string.IsNullOrEmpty(txtcapacite) || !string.IsNullOrEmpty(txtsource)
                    || !string.IsNullOrEmpty(txtpromoteur) || !string.IsNullOrEmpty(txttype)
                    || !string.IsNullOrEmpty(txtregion) || !string.IsNullOrEmpty(txtdistrict)||
                    !string.IsNullOrEmpty(txtnom) || !string.IsNullOrEmpty(txtprenom)||
                    !string.IsNullOrEmpty(txttel) || !string.IsNullOrEmpty(txtmail)||
                    !string.IsNullOrEmpty(txtdir) || !string.IsNullOrEmpty(txtser) || !string.IsNullOrEmpty(txtentite)
                    || !string.IsNullOrEmpty(txtcontrainte) || !string.IsNullOrEmpty(txtdebut)||
                    !string.IsNullOrEmpty(txtfin) || !string.IsNullOrEmpty(txtetape) || !string.IsNullOrEmpty(txtetat)||
                    !string.IsNullOrEmpty(txtobs) || !string.IsNullOrEmpty(txturgence)
                    || !string.IsNullOrEmpty(txtsituation) || !string.IsNullOrEmpty(txtsolution))
                {

                    text += "<div id='qunit'></div>";
                    text += "<div id='qunit-fixture'>";
                    text += "<table id='testTable' style='width:100%'>";
                    text += "<thead><tr><th><h3>Liste Des Projets</h3></th></tr></thead><tbody>";

                foreach (var p in projet)
                {

                    var testprojet = ListeProjet.Exists(pro => pro.IdProjet == p.IdProjet && pro.Test.ToUpper().Trim()=="NOUVEAU" && (p.Titre.ToUpper().Contains(txttitre.ToUpper()) || string.IsNullOrEmpty(txttitre))
                                             && (pro.Numero.ToUpper().Contains(txtnum.ToUpper()) || string.IsNullOrEmpty(txtnum))
                                            && (pro.Promoteur.ToUpper().Contains(txtpromoteur.ToUpper()) || string.IsNullOrEmpty(txtpromoteur))
                                             && (pro.Type.ToUpper().Contains(txttype.ToUpper()) || string.IsNullOrEmpty(txttype))
                                             && (pro.Capacite.ToUpper().Contains(txtcapacite.ToUpper()) || string.IsNullOrEmpty(txtcapacite))
                                             && (pro.Source.ToUpper().Contains(txtsource.ToUpper()) || string.IsNullOrEmpty(txtsource)));
                    
                    var TestEtape =
                        ListeEtape.Exists(f => (p.IdProjet == f.IdProjet)
                        && (f.LibEtape.ToUpper().Contains(txtetape.ToUpper()) || string.IsNullOrEmpty(txtetape.ToUpper()))
                        && (f.Contrainte.ToUpper().Contains(txtcontrainte.ToUpper()) || string.IsNullOrEmpty(txtcontrainte))
                        && (string.IsNullOrEmpty(txtdebut) || f.Debut.Contains(txtdebut))
                        && (string.IsNullOrEmpty(txtfin) || f.Fin.Contains(txtfin))
                        && (f.Urgence.ToUpper().Contains(txturgence.ToUpper()) || string.IsNullOrEmpty(txturgence))
                        && (f.Obs.ToUpper().Contains(txtobs.ToUpper()) || string.IsNullOrEmpty(txtobs))
                        && (f.Contrainte.ToUpper().Contains(txtcontrainte.ToUpper()) || string.IsNullOrEmpty(txtcontrainte))
                        && (f.Solution.ToUpper().Contains(txtsolution.ToUpper()) || string.IsNullOrEmpty(txtsolution))
                        && (f.Etat.ToUpper().Contains(txtetat.ToUpper()) || string.IsNullOrEmpty(txtetat))
                        );
                    var testregion = ListeRegion.Exists(f => (f.IdProjet == p.IdProjet)
                        && (f.LibRegion.ToUpper().Contains(txtregion.ToUpper()) || string.IsNullOrEmpty(txtregion)));
                    var testdistrict = ListeDistrict.Exists(f => f.IdProjet == p.IdProjet
                        && (f.LibDistrict.ToUpper().Contains(txtdistrict.ToUpper()) || string.IsNullOrEmpty(txtdistrict))
                        );
                    var testcor = ListeCor.Exists(f => f.IdCor == p.IdCor && (f.NomCor.ToUpper().Contains(txtnom.ToUpper()) || string.IsNullOrEmpty(txtnom))
                        && (f.PrenomCor.ToUpper().Contains(txtprenom.ToUpper()) || string.IsNullOrEmpty(txtprenom))
                        && (f.TelCor.Contains(txttel) || string.IsNullOrEmpty(txttel))
                        && (f.EmailCor.ToLower().Contains(txtmail.ToLower()) || string.IsNullOrEmpty(txtmail)));
                    bool testdir = false, testser = false, testent = false;

                    if (testcor)
                    {
                        foreach (var cor in ListeCor)
                        {
                            if (cor.IdCor == p.IdCor)
                            {
                                testser = ListeSer.Exists(f => f.IdService == cor.IdService && (f.LibService.ToUpper().Contains(txtser.ToUpper()) || string.IsNullOrEmpty(txtser)));
                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper()) || string.IsNullOrEmpty(txtdir)));
                                if (testser)
                                {
                                    var testser1 = ListeSer.First(f => f.IdService == cor.IdService && (f.LibService.ToUpper().Contains(txtser.ToUpper())));
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                        testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite && (f.LibEntite.ToUpper().Contains(txtentite.ToUpper())));
                                    }
                                }
                                else
                                {
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                        testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite && (f.LibEntite.ToUpper().Contains(txtentite.ToUpper())));
                                    }
                                }

                            }
                        }
                    }
                    if (TestEtape && testregion && testdistrict && testcor && testent && testdir && (testser || !testser))
                    {
                        if (testprojet)
                        {
                            text += "<tr>";
                            text += "<td>";
                            text += "<div id='design' class='col-sm-12'>";
                            text += "<div class='panel panel-primary'>";
                            text += "<div class='panel panel-heading'>";
                            text += "<h3 class='panel-title'><a id='bt_" + p.IdProjet + "' href='Javascript:expandcollapse1(" + guillemet + p.IdProjet + guillemet + "," + guillemet + p.Numero + guillemet + ");'>" + p.Numero + "</a>&nbsp;&nbsp;&nbsp;" + p.Titre.Trim() + "</h3>";
                            text += "</div>";
                            text += "<div id='" + p.IdProjet + "' style='display:none'>";

                            text += "<div class='panel panel-body'>";
                            
                                foreach (var eta in ListeEtape)
                                {
                                    if (eta.IdProjet == p.IdProjet)
                                    {
                                        
                                        DateTime dt = Convert.ToDateTime(eta.Fin);

                                        TimeSpan ts = dt - DateTime.UtcNow;
                                        int nbr = ts.Days;
                                        if (nbr >= 0)
                                        {
                                            text += "<label style='color:red'>";
                                            text += "Etapes " + x + " :" + nbr + " Jours Restants</label><br/>";
                                        }
                                        x++;
                                    }
                                    else
                                    {
                                        x = 1;
                                    }
                                }
                                text += "<div id='description'  style='float:left;width:400px'>";
                                text += "<fieldset><legend style='color:green'>";
                                text += "Déscriptions du projet</legend> ";
                                text += "<label style='color:blue'> Titre :</label><br/><label style='color:grey'>" + p.Titre + "</label><br/>";
                                text += "<label style='color:blue'>Promoteur :</label><br/><label>" + p.Promoteur + "</label><br/>";
                                text += "<label style='color:blue'>Source :</label><br/><label>" + p.Source + "</label><br/>";
                                text += "<label style='color:blue'>Type :</label><br/><label>" + p.Type + "</label><br/>";
                                text += "<label style='color:blue'>Resumé :</label><br/><label>" + p.Capacite + "</label><br/>";

                                foreach (var dist in ListeRegion)
                                {
                                    if (dist.IdProjet == p.IdProjet)
                                    {
                                        text += "<label style='color:blue'>Région :</label><br/><label>";
                                        text += dist.LibRegion + "</label><br/>";
                                    }
                                }

                                foreach (var dist in ListeDistrict)
                                {
                                    if (dist.IdProjet == p.IdProjet)
                                    {
                                        text += "<label style='color:blue'>District :</label><br/>";
                                        text += dist.LibDistrict + "<br/>";
                                    }
                                }
                                text += "</fieldset></div><div id='etat' style='float:left;width:400px'>";

                                foreach (var etape in ListeEtape)
                                {
                                    var nbrav = ListeEtape.Where(f => f.IdProjet == p.IdProjet).Count();
                                    if (etape.IdProjet == p.IdProjet)
                                    {
                                        w++;
                                        text += "<fieldset><legend style='color:green'>Etat d'avancement " + z + "</legend>";

                                        DateTime debut = Convert.ToDateTime(etape.Debut);
                                        DateTime fin = Convert.ToDateTime(etape.Fin);

                                        text += "<label style='color:blue'>Etapes :</label><br/>" + etape.LibEtape + "<br/>";
                                        text += "<label style='color:blue'>Debut :</label><br/>";
                                        if (string.Format("{0:dd/MM/yyyy}", debut) == "31/12/2016")
                                            text += "<label hidden='hidden'>31/12/2016</label><br/>";
                                        else
                                            text += string.Format("{0:dd/MM/yyyy}", debut) + "<br/>";

                                        text += "<label style='color:blue'>Fin :</label><br/>";
                                        if (string.Format("{0:dd/MM/yyyy}", fin) == "31/12/2016")
                                            text += "<label hidden='hidden'>31/12/2016</label><br/>";
                                        else
                                            text += string.Format("{0:dd/MM/yyyy}", fin) + "<br/>";

                                        text += "<label style='color:blue'>Situation actuelle :</label><br/>" + etape.Situation + "<br/>";
                                        text += "<label style='color:blue'>Contrainte :</label><br/>" + etape.Contrainte + "<br/>";
                                        text += "<label style='color:blue'>Solution :</label><br/>" + etape.Solution + "<br/>";
                                        text += "<label style='color:blue'>Obsérvations :</label><br/>" + etape.Obs + "<br/>";
                                        text += "<label style='color:blue'>Etat :</label><br/>" + etape.Etat + "<br/>";
                                        text += "<label style='color:blue'>Niveau d'urgence :</label><br/>" + etape.Urgence + "<br/></fieldset>";
                                        z++;
                                    }
                                    else
                                    {
                                        z = 1;
                                    }
                                }

                                if (testcor)
                                {
                                    foreach (var cor in ListeCor)
                                    {
                                        if (cor.IdCor == p.IdCor)
                                        {
                                            testser = ListeSer.Exists(f => f.IdService == cor.IdService && (f.LibService.ToUpper().Contains(txtser.ToUpper())));

                                            if (testser)
                                            {
                                                var testser1 = ListeSer.First(f => f.IdService == cor.IdService && (f.LibService.ToUpper().Contains(txtser.ToUpper())));
                                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                                var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                                testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite);
                                                var ent = ListeEntite.First(f => f.IdEntite == testdir1.IdEntite);
                                                text += "</div><div id='agent'  style='float:left;width:400px'>";
                                                text += "<fieldset><legend style='color:green'>Agent résponsable</legend>";
                                                text += "<label style='color:blue'>Entite résponsable:</label><br/>" + ent.LibEntite.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Direction :</label><br/>" + testdir1.LibDir.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Service :</label><br/>" + testser1.LibService.ToUpper().Trim() + "<br/>";

                                                text += "<label style='color:blue'>Agent résponsable:</label><br/>" + cor.NomCor.Trim() + " " + cor.PrenomCor.Trim() + "<br/>";
                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor + "<br/>";
                                                text += "<label style='color:blue'>E-mail:</label><br/>" + cor.EmailCor + "<br/>";
                                                text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                text += "&nbsp;&nbsp;<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                if ((role.ToUpper().Trim() == "ADMINISTRATEUR" && Convert.ToInt32(id) == p.IdEnr) || role.ToUpper().Trim() == "ADMINISTRATEUR" || Convert.ToInt32(id) == p.IdEnr)
                                                {
                                                    text += "&nbsp;&nbsp;<a id='btsuppr'  class='btn btn-info' href='addprojet.aspx?action=supprimer&id=" + p.IdProjet + "'>Supprimer</a>";
                                                }
                                                text += "</fieldset>";
                                            }
                                            else
                                            {
                                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                                var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir && (f.LibDir.ToUpper().Contains(txtdir.ToUpper())));
                                                testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdDir);
                                                var ent = ListeEntite.First(f => f.IdEntite == testdir1.IdEntite);

                                                text += "</div><div id='agent'  style='float:left;width:400px'>";
                                                text += "<fieldset><legend style='color:green'>Agent résponsable</legend>";
                                                text += "<label style='color:blue'>Entite résponsable:</label><br/>" + ent.LibEntite.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Direction :</label><br/>" + testdir1.LibDir.ToUpper().Trim() + "<br/>";

                                                text += "<label style='color:blue'>Agent résponsable:</label><br/>" + cor.NomCor.Trim() + " " + cor.PrenomCor.Trim() + "<br/>";
                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor + "<br/>";
                                                text += "<label style='color:blue'>E-mail:</label><br/>" + cor.EmailCor + "<br/>";

                                                if (role.ToUpper().Trim() == "ADMINISTRATEUR")
                                                {
                                                    text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                    text += "&nbsp;&nbsp;&nbsp<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                    text += "&nbsp;&nbsp;<a id='btsuppr'  class='btn btn-info' href='addprojet.aspx?action=supprimer&id=" + p.IdProjet + "'>Supprimer</a>";
                                                }
                                                else if (role.ToUpper().Trim() == "SUPERVISEUR")
                                                {
                                                    text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                    text += "&nbsp;&nbsp;&nbsp<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                    text += "&nbsp;&nbsp;<a id='btsuppr'  class='btn btn-info' href='addprojet.aspx?action=supprimer&id=" + p.IdProjet + "'>Supprimer</a>";                           
                                                }
                                                else if (role.ToUpper().Trim() == "SUPER UTILISATEUR")
                                                {
                                                    text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                    text += "&nbsp;&nbsp;&nbsp<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                }
                                                else if (role.ToUpper().Trim() == "UTILISATEUR")
                                                {

                                                }
                                                text += "&nbsp;&nbsp;<a href='impression.aspx?id=" + p.IdProjet + "' class='btn btn-info'>Imprimer</a>";
                                                text += "</fieldset>";
                                            }
                                        }
                                    }
                                }
                        }
                    }
                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</td>";

                    text += "</tr>";
                }
                text += "</tbody></table>";
                text += "</div>";
               }


                return text + " * " + text1;
            }
            catch (Exception ex)
            {
                throw ex; //Response.Write(ex.Message + "<br>" + ex.StackTrace);
            }
            finally
            {
                action = null;
                ListeCor = null;
                ListeDir = null;
                ListeDistrict = null;
                ListeEntite = null;
                ListeEtape = null;
                ListeProjet = null;
                ListeRegion = null;
                ListeSer = null;
                dr = null;
                sr = null;
                ett = null; 
                pr = null; 
                etp = null; 
                re = null; 
                dis = null; 
                co = null;
            }
        }

        public string Remplir1(string page, string id, string role, string iddir)
        {
            List<Projets> ListeProjet = new List<Projets>();
            List<District> ListeDistrict = new List<District>();
            List<Region> ListeRegion = new List<Region>();
            List<Etapes> ListeEtape = new List<Etapes>();
            List<Correspondants> ListeCor = new List<Correspondants>();
            List<Directions> ListeDir = new List<Directions>();
            List<Services> ListeSer = new List<Services>();
            List<Entites> ListeEntite = new List<Entites>();

                
                
            try
            {
                int x = 1, z = 1, w = 0;
                string text1 = "";

                char guillemet = '"';
                ListeDistrict = action.GetDistrict();

                ListeRegion = action.GetRegion();

                ListeEtape = action.GetAvancement();

                ListeProjet = action.GetProjet();
                ListeCor = action.GetCorrespondant();
                ListeSer = action.Getservice();
                ListeDir = action.GetDirection();
                ListeEntite = action.GetEntite();

                var testprojet1 = ListeProjet.Where(f => f.Test.ToUpper().Trim() == "NOUVEAU");


                /*************************************************************
                 **************************TEST*******************************
                 **************************************************************/


                int limit = 10;
                int nbrpage = testprojet1.Count() / limit;
                int curpage, strrequest;

                try
                {
                    if (!string.IsNullOrEmpty(page) && int.Parse(page) <= ListeProjet.Count)
                    {
                        strrequest = int.Parse(page);
                        curpage = (strrequest) * limit;

                    }
                    else
                    {
                        curpage = 0;
                        strrequest = 0;
                    }
                }
                catch
                {
                    curpage = 0;
                    strrequest = 0;
                }
                var offset = testprojet1.Skip(curpage).Take(limit).ToList();
                
                string text = "";
                text += "<div id='qunit'></div>";
                text += "<div id='qunit-fixture'>";
                text += "<table id='tablepaging' style='width:100%'>";
                text += "<thead><tr><th><h3>Liste Des Projets &nbsp;&nbsp;Nombre de Pages :" +  (nbrpage + 1) +"&nbsp; &nbsp;Total :"+testprojet1.Count()
                +"</h3></th></tr></thead><tbody>";
                foreach (var p in offset)
                {

                    var testprojet = ListeProjet.Exists(pro => pro.IdProjet == p.IdProjet && pro.Test.ToUpper().Trim() == "NOUVEAU");
                    
                    var TestEtape =
                        ListeEtape.Exists(f => (p.IdProjet == f.IdProjet));
                    var testregion = ListeRegion.Exists(f => (f.IdProjet == p.IdProjet));
                    var testdistrict = ListeDistrict.Exists(f => f.IdProjet == p.IdProjet);
                    var testcor = ListeCor.Exists(f => f.IdCor == p.IdCor );
                    bool testdir = false, testser = false, testent = false;

                    if (testcor)
                    {
                        foreach (var cor in ListeCor)
                        {
                            if (cor.IdCor == p.IdCor)
                            {
                                testser = ListeSer.Exists(f => f.IdService == cor.IdService);
                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                if (testser)
                                {
                                    var testser1 = ListeSer.First(f => f.IdService == cor.IdService);
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir );
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir );
                                    }
                                }
                                else
                                {
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir);
                                        testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite);
                                    }
                                }

                            }
                        }
                    }
                    if (TestEtape && testregion && testdistrict && testcor && testent && testdir && (testser || !testser))
                    {
                        if (testprojet)
                        {
                            text += "<tr>";
                            text += "<td>";
                            text += "<div id='design' class='col-sm-12'>";
                            text += "<div class='panel panel-primary'>";
                            text += "<div class='panel panel-heading'>";
                            text += "<h3 class='panel-title'><a id='bt_" + p.IdProjet + "' href='Javascript:expandcollapse1(" + guillemet + p.IdProjet + guillemet + "," + guillemet + p.Numero + guillemet + ");'>" + p.Numero + "</a>&nbsp;&nbsp;&nbsp;" + p.Titre.Trim() + "</h3>";
                            text += "</div>";
                            text += "<div id='" + p.IdProjet + "' style='display:none'>";

                            text += "<div class='panel panel-body'>";
                            if (p.Titre.Trim().ToUpper() == "PROJET SUPPRIMER")
                            {
                                var resp = ListeCor.First(f => f.IdCor == p.IdEnr);
                                text += "Supprimer par :<br/>";
                                text += resp.NomCor.ToUpper() + " " + resp.PrenomCor;
                                text += "<br/><label>Motif :</label><br/>";
                                text += p.Promoteur.ToUpper();
                            }
                            else
                            {
                                foreach (var eta in ListeEtape)
                                {
                                    if (eta.IdProjet == p.IdProjet)
                                    {
                                        
                                        DateTime dt = Convert.ToDateTime(eta.Fin);

                                        TimeSpan ts = dt - DateTime.UtcNow;
                                        int nbr = ts.Days;
                                        if (nbr >= 0)
                                        {
                                            text += "<label style='color:red'>";
                                            text += "Etapes " + x + " :" + nbr + " Jours Restants</label><br/>";
                                        }
                                        x++;
                                    }
                                    else
                                    {
                                        x = 1;
                                    }
                                }
                                text += "<div id='description'  style='float:left;width:400px'>";
                                text += "<fieldset><legend style='color:green'>";
                                text += "Déscriptions du projet</legend> ";
                                text += "<label style='color:blue'> Titre :</label><br/><label style='color:grey'>" + p.Titre + "</label><br/>";
                                text += "<label style='color:blue'>Promoteur :</label><br/><label>" + p.Promoteur + "</label><br/>";
                                text += "<label style='color:blue'>Source :</label><br/><label>" + p.Source + "</label><br/>";
                                text += "<label style='color:blue'>Type :</label><br/><label>" + p.Type + "</label><br/>";
                                text += "<label style='color:blue'>Resumé :</label><br/><label>" + p.Capacite + "</label><br/>";

                                foreach (var dist in ListeRegion)
                                {
                                    if (dist.IdProjet == p.IdProjet)
                                    {
                                        text += "<label style='color:blue'>Région :</label><br/><label>";
                                        text += dist.LibRegion + "</label><br/>";
                                    }
                                }

                                foreach (var dist in ListeDistrict)
                                {
                                    if (dist.IdProjet == p.IdProjet)
                                    {
                                        text += "<label style='color:blue'>District :</label><br/>";
                                        text += dist.LibDistrict + "<br/>";
                                    }
                                }
                                text += "</fieldset></div><div id='etat' style='float:left;width:400px'>";

                                foreach (var etape in ListeEtape)
                                {
                                    var nbrav = ListeEtape.Where(f => f.IdProjet == p.IdProjet).Count();
                                    if (etape.IdProjet == p.IdProjet)
                                    {
                                        w++;
                                        text += "<fieldset><legend style='color:green'>Etat d'avancement " + z + "</legend>";

                                        DateTime debut = Convert.ToDateTime(etape.Debut);
                                        DateTime fin = Convert.ToDateTime(etape.Fin);

                                        
                                        text += "<label style='color:blue'>Etapes :</label><br/>" + etape.LibEtape + "<br/>";
                                        text += "<label style='color:blue'>Debut :</label><br/>";
                                        if (string.Format("{0:dd/MM/yyyy}", debut) == "31/12/2016")
                                            text += "<label hidden='hidden'>31/12/2016</label><br/>";
                                        else
                                            text += string.Format("{0:dd/MM/yyyy}", debut) + "<br/>";

                                        text += "<label style='color:blue'>Fin :</label><br/>";
                                        if (string.Format("{0:dd/MM/yyyy}", fin) == "31/12/2016")
                                            text += "<label hidden='hidden'>31/12/2016</label><br/>";
                                        else
                                            text += string.Format("{0:dd/MM/yyyy}", fin) + "<br/>";

                                        //text += "<label style='color:blue'>Debut :</label><br/>" + string.Format("{0:dd/MM/yyyy}", debut) + "<br/>";
                                        //text += "<label style='color:blue'>Fin :</label><br/>" + string.Format("{0:dd/MM/yyyy}", fin) + "<br/>";
                                        text += "<label style='color:blue'>Situation actuelle :</label><br/>" + etape.Situation + "<br/>";
                                        text += "<label style='color:blue'>Contrainte :</label><br/>" + etape.Contrainte + "<br/>";
                                        text += "<label style='color:blue'>Solution :</label><br/>" + etape.Solution + "<br/>";
                                        text += "<label style='color:blue'>Obsérvations :</label><br/>" + etape.Obs + "<br/>";
                                        text += "<label style='color:blue'>Etat :</label><br/>" + etape.Etat + "<br/>";
                                        text += "<label style='color:blue'>Niveau d'urgence :</label><br/>" + etape.Urgence + "<br/></fieldset>";
                                        z++;
                                    }
                                    else
                                    {
                                        z = 1;
                                    }
                                }

                                if (testcor)
                                {
                                    foreach (var cor in ListeCor)
                                    {
                                        if (cor.IdCor == p.IdCor)
                                        {
                                            testser = ListeSer.Exists(f => f.IdService == cor.IdService);

                                            if (testser)
                                            {
                                                var testser1 = ListeSer.First(f => f.IdService == cor.IdService);
                                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir );
                                                var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                                testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite);
                                                var ent = ListeEntite.First(f => f.IdEntite == testdir1.IdEntite);
                                                text += "</div><div id='agent'  style='float:left;width:400px'>";
                                                text += "<fieldset><legend style='color:green'>Agent résponsable</legend>";
                                                text += "<label style='color:blue'>Entite résponsable:</label><br/>" + ent.LibEntite.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Direction :</label><br/>" + testdir1.LibDir.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Service :</label><br/>" + testser1.LibService.ToUpper().Trim() + "<br/>";

                                                text += "<label style='color:blue'>Agent résponsable:</label><br/>" + cor.NomCor.Trim() + " " + cor.PrenomCor.Trim() + "<br/>";
                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor + "<br/>";
                                                text += "<label style='color:blue'>E-mail:</label><br/>" + cor.EmailCor + "<br/>";
                                                text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                text += "&nbsp;&nbsp;<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                if ((role.ToUpper().Trim() == "ADMINISTRATEUR" && Convert.ToInt32(id) == p.IdEnr) || role.ToUpper().Trim() == "ADMINISTRATEUR" || Convert.ToInt32(id) == p.IdEnr)
                                                {
                                                    text += "&nbsp;&nbsp;<a id='btsuppr'  class='btn btn-info' href='addprojet.aspx?action=supprimer&id=" + p.IdProjet + "'>Supprimer</a>";
                                                }
                                                text += "</fieldset>";
                                            }
                                            else
                                            {
                                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                                var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir);
                                                testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdDir);
                                                var ent = ListeEntite.First(f => f.IdEntite == testdir1.IdEntite);

                                                text += "</div><div id='agent'  style='float:left;width:400px'>";
                                                text += "<fieldset><legend style='color:green'>Agent résponsable</legend>";
                                                text += "<label style='color:blue'>Entite résponsable:</label><br/>" + ent.LibEntite.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Direction :</label><br/>" + testdir1.LibDir.ToUpper().Trim() + "<br/>";

                                                text += "<label style='color:blue'>Agent résponsable:</label><br/>" + cor.NomCor.Trim() + " " + cor.PrenomCor.Trim() + "<br/>";
                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor + "<br/>";
                                                text += "<label style='color:blue'>E-mail:</label><br/>" + cor.EmailCor + "<br/>";

                                                //if (id != null && role != null)
                                                //{
                                                if (role.ToUpper().Trim() == "ADMINISTRATEUR")
                                                {
                                                    text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                    text += "&nbsp;&nbsp;&nbsp<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                    text += "&nbsp;&nbsp;<a id='btsuppr'  class='btn btn-info' href='addprojet.aspx?action=supprimer&id=" + p.IdProjet + "'>Supprimer</a>";
                                                }
                                                else if (role.ToUpper().Trim() == "SUPERVISEUR")
                                                {
                                                    text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                    text += "&nbsp;&nbsp;&nbsp<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                    text += "&nbsp;&nbsp;<a id='btsuppr'  class='btn btn-info' href='addprojet.aspx?action=supprimer&id=" + p.IdProjet + "'>Supprimer</a>";
                                                
                                                }
                                                else if (role.ToUpper().Trim() == "SUPER UTILISATEUR" && p.IdEnr == int.Parse(iddir))
                                                {
                                                    text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                    text += "&nbsp;&nbsp;&nbsp<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";

                                                }
                                                else if (role.ToUpper().Trim() == "SIMPLE UTILISATEUR")
                                                {

                                                }
                                                text += "&nbsp;&nbsp;<a href='impression.aspx?id=" + p.IdProjet + "' class='btn btn-info'>Imprimer</a>";


                                                //}
                                                /*
                                            else
                                            {
                                                Response.Redirect("connexion.aspx");
                                            }*/
                                                text += "</fieldset>";
                                            }
                                        }
                                    }
                                }
                            }


                        }
                    }
                    //}

                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</td>";

                    text += "</tr>";
                }

                text += "</tbody></table>";
                text += "</div>";

                if (!string.IsNullOrEmpty(page) && int.Parse(page) > 0)
                {
                    text += "<a class='pg-normal' href='addprojet.aspx?page=" + 0 + "'>First</a>&nbsp;&nbsp;";
                }
                else
                {
                    text += "<Label class='pg-selected'>First</Label>&nbsp;&nbsp;";
                }
                if (!string.IsNullOrEmpty(page) && int.Parse(page) <= nbrpage && int.Parse(page) > 0)
                {
                    text += "&nbsp;&nbsp;<a  class='pg-normal' href='addprojet.aspx?page=" + (int.Parse(page) - 1) + "'>Previous</a>&nbsp;&nbsp;";
                }
                else
                {
                    text += "<Label class='pg-selected'>Previous</Label>&nbsp;&nbsp;";
                }

                if (!string.IsNullOrEmpty(page) && int.Parse(page) < nbrpage && nbrpage>0)
                {
                    text += "<a class='pg-normal' href='addprojet.aspx?page=" + (int.Parse(page) + 1) + "'>Next</a>&nbsp;&nbsp;";
                }
                else if (string.IsNullOrEmpty(page) && nbrpage>0)
                {
                    text += "<a class='pg-normal' href='addprojet.aspx?page=" + 1 + "'>Next</a>&nbsp;&nbsp;"; ;
                }
                else
                {
                    text += "<label class='pg-selected'>Next</label>&nbsp;&nbsp;";
                }
                if ((!string.IsNullOrEmpty(page) && int.Parse(page) < nbrpage && nbrpage>0) || (string.IsNullOrEmpty(page) && nbrpage>0))
                {
                    text += "&nbsp;&nbsp;<a class='pg-normal' href='addprojet.aspx?page=" + nbrpage + "'>Last</a><br/>";
                }
                else
                {
                    text += "<Label class='pg-selected'>Last</Label>&nbsp;&nbsp;";
                }
                text += "Pages :"+(strrequest + 1) + " / " + (nbrpage + 1);
                return text + " * " + text1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                action = null;
                ListeCor = null;
                ListeDir = null;
                ListeDistrict = null;
                ListeEntite = null;
                ListeEtape = null;
                ListeProjet = null;
                ListeRegion = null;
                ListeSer = null;
            }
        }


        /******************************************************************************************
         ******************************************************************************************
         ******************************************************************************************/

        public string Impression()
        {
            List<Correspondants> ListeCor = new List<Correspondants>();
            List<Directions> ListeDir = new List<Directions>();
            List<Services> ListeSer = new List<Services>();
            List<Entites> ListeEntite = new List<Entites>();
            List<Projets> ListeProjet = new List<Projets>();
            List<District> ListeDistrict = new List<District>();
            List<Region> ListeRegion = new List<Region>();
            List<Etapes> ListeEtape = new List<Etapes>();
                
            try
            {
                ListeDistrict = action.GetDistrict();
                ListeRegion = action.GetRegion();
                ListeEtape = action.GetAvancement();
                ListeProjet = action.GetProjet();
                ListeCor = action.GetCorrespondant();
                ListeSer = action.Getservice();
                ListeDir = action.GetDirection();
                ListeEntite = action.GetEntite();
                string text = "";
                text += "<table id='tablepaging' border='1' style='width:100%'>";
                text += "<thead><tr><th>Numéro</th><th>Titre</th><th>Résumé</th>"+
                    "<th>Provenance</th><th>Destination</th><th>Date</th>"+
                    "<th>Statut</th><th>Observation</th><th>Nombre</th></tr></thead><tbody>";
                var TestProjet = ListeProjet.Where(f => f.Test.ToUpper().Trim() == "NOUVEAU");
                foreach (var p in TestProjet)
                {
                    var testprojet = ListeProjet.Exists(pro => pro.IdProjet == p.IdProjet);                    
                    var TestEtape =
                        ListeEtape.Exists(f => (p.IdProjet == f.IdProjet));
                    var testregion = ListeRegion.Exists(f => (f.IdProjet == p.IdProjet));
                    var testdistrict = ListeDistrict.Exists(f => f.IdProjet == p.IdProjet);
                    var testcor = ListeCor.Exists(f => f.IdCor == p.IdCor);
                    bool testdir = false, testser = false, testent = false;
                    if (testcor)
                    {
                        foreach (var cor in ListeCor)
                        {
                            if (cor.IdCor == p.IdCor)
                            {
                                testser = ListeSer.Exists(f => f.IdService == cor.IdService);
                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                if (testser)
                                {
                                    var testser1 = ListeSer.First(f => f.IdService == cor.IdService);
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                    }
                                }
                                else
                                {
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir);
                                        testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite);
                                    }
                                }
                            }
                        }
                    }
                    if (TestEtape && testregion && testdistrict && testcor && testent && testdir && (testser || !testser))
                    {
                        if (testprojet)
                        {
                            text += "<tr>";
                            text += "<td>";
                            text += p.Numero + "</td><td>" + p.Titre.ToLower() + "</td><td>";
                            text += p.Capacite + "</td><td>" + p.Promoteur + "</td><td>" + p.Source+"</td><td>";                            
                                foreach (var etape in ListeEtape)
                                {
                                    if (etape.IdProjet == p.IdProjet)
                                    {
                                        DateTime debut = Convert.ToDateTime(etape.Debut);
                                        text += string.Format("{0:dd/MM/yyyy}", debut); ;
                                    }
                                }
                                text += "</td><td>";
                                foreach (var etape in ListeEtape)
                                {
                                    if (etape.IdProjet == p.IdProjet)
                                    {
                                        text += etape.Situation;
                                    }
                                }
                                text += "</td><td>";
                                foreach (var etape in ListeEtape)
                                {
                                    if (etape.IdProjet == p.IdProjet)
                                    {
                                        text += etape.Obs;
                                    }
                                }
                                text += "</td><td>";
                                foreach (var etape in ListeEtape)
                                {
                                    if (etape.IdProjet == p.IdProjet)
                                    {
                                        text += etape.Etat;
                                    }
                                }
                                text += "</td>";
                                


                        }
                    }                    
                    text += "</tr>";
                }
                text += "</tbody></table>";
                return text ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                action = null;
                ListeCor = null;
                ListeDir = null;
                ListeDistrict = null;
                ListeEntite = null;
                ListeEtape = null;
                ListeProjet = null;
                ListeRegion = null;
                ListeSer = null;
            }
        }


        /******************************************************************************************
         ******************************************************************************************
         ******************************************************************************************/

        public string Impression1(string id)
        {
            List<Projets> ListeProjet = new List<Projets>();
            List<District> ListeDistrict = new List<District>();
            List<Region> ListeRegion = new List<Region>();
            List<Etapes> ListeEtape = new List<Etapes>();
            List<Correspondants> ListeCor = new List<Correspondants>();
            List<Directions> ListeDir = new List<Directions>();
            List<Services> ListeSer = new List<Services>();
            List<Entites> ListeEntite = new List<Entites>();

            try
            {
                ListeDistrict = action.GetDistrict();
                ListeRegion = action.GetRegion();
                ListeEtape = action.GetAvancement();
                ListeProjet = action.GetProjet();
                ListeCor = action.GetCorrespondant();
                ListeSer = action.Getservice();
                ListeDir = action.GetDirection();
                ListeEntite = action.GetEntite();
                string text = "";
                text += "<table id='tablepaging' border='1' style='width:100%'>";
                text += "<thead><tr><th>Numéro</th><th>Titre</th><th>Résumé</th>" +
                    "<th>Provenance</th><th>Destination</th><th>Date</th>" +
                    "<th>Statut</th><th>Observation</th><th>Nombre</th></tr></thead><tbody>";
                var TestProjet = ListeProjet.Where(f => f.Test.ToUpper().Trim() == "NOUVEAU" && f.IdProjet==int.Parse(id));
                foreach (var p in TestProjet)
                {
                    var testprojet = ListeProjet.Exists(pro => pro.IdProjet == p.IdProjet);
                    var TestEtape =
                        ListeEtape.Exists(f => (p.IdProjet == f.IdProjet));
                    var testregion = ListeRegion.Exists(f => (f.IdProjet == p.IdProjet));
                    var testdistrict = ListeDistrict.Exists(f => f.IdProjet == p.IdProjet);
                    var testcor = ListeCor.Exists(f => f.IdCor == p.IdCor);
                    bool testdir = false, testser = false, testent = false;
                    if (testcor)
                    {
                        foreach (var cor in ListeCor)
                        {
                            if (cor.IdCor == p.IdCor)
                            {
                                testser = ListeSer.Exists(f => f.IdService == cor.IdService);
                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                if (testser)
                                {
                                    var testser1 = ListeSer.First(f => f.IdService == cor.IdService);
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                    }
                                }
                                else
                                {
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir);
                                        testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite);
                                    }
                                }
                            }
                        }
                    }
                    if (TestEtape && testregion && testdistrict && testcor && testent && testdir && (testser || !testser))
                    {
                        if (testprojet)
                        {
                            text += "<tr>";
                            text += "<td>";
                            text += p.Numero + "</td><td>" + p.Titre.ToLower() + "</td><td>";
                            text += p.Capacite + "</td><td>" + p.Promoteur + "</td><td>" + p.Source + "</td><td>";
                            foreach (var etape in ListeEtape)
                            {
                                if (etape.IdProjet == p.IdProjet)
                                {
                                    DateTime debut = Convert.ToDateTime(etape.Debut);
                                    text += string.Format("{0:dd/MM/yyyy}", debut); ;
                                }
                            }
                            text += "</td><td>";
                            foreach (var etape in ListeEtape)
                            {
                                if (etape.IdProjet == p.IdProjet)
                                {
                                    text += etape.Situation;
                                }
                            }
                            text += "</td><td>";
                            foreach (var etape in ListeEtape)
                            {
                                if (etape.IdProjet == p.IdProjet)
                                {
                                    text += etape.Obs;
                                }
                            }
                            text += "</td><td>";
                            foreach (var etape in ListeEtape)
                            {
                                if (etape.IdProjet == p.IdProjet)
                                {
                                    text += etape.Etat;
                                }
                            }
                            text += "</td>";
                        }
                    }                  
                    text += "</tr>";
                }
                text += "</tbody></table>";
                return text;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                action = null;
                ListeCor = null;
                ListeDir = null;
                ListeDistrict = null;
                ListeEntite = null;
                ListeEtape = null;
                ListeProjet = null;
                ListeRegion = null;
                ListeSer = null;            
            }
        }


        /******************************************************************************************
         ******************************************************************************************
         ******************************************************************************************/


        public string Archive(string page, string id, string role, string iddir)
        {
            try
            {

                int x = 1, z = 1, w = 0;
                string text1 = "";

                char guillemet = '"';
                List<Projets> ListeProjet = new List<Projets>();

                List<District> ListeDistrict = new List<District>();
                ListeDistrict = action.GetDistrict();

                List<Region> ListeRegion = new List<Region>();
                ListeRegion = action.GetRegion();

                List<Etapes> ListeEtape = new List<Etapes>();
                ListeEtape = action.GetAvancement();

                List<Correspondants> ListeCor = new List<Correspondants>();
                List<Directions> ListeDir = new List<Directions>();
                List<Services> ListeSer = new List<Services>();
                List<Entites> ListeEntite = new List<Entites>();


                ListeProjet = action.GetProjet();
                ListeCor = action.GetCorrespondant();
                ListeSer = action.Getservice();
                ListeDir = action.GetDirection();
                ListeEntite = action.GetEntite();

                var testprojet1 = ListeProjet.Where(f => f.Test.ToUpper().Trim() == "ARCHIVE");

                int limit = 10;
                int nbrpage = testprojet1.Count() / limit;
                int curpage, strrequest;

                try
                {
                    if (!string.IsNullOrEmpty(page) && int.Parse(page) <= ListeProjet.Count)
                    {
                        strrequest = int.Parse(page);
                        curpage = (strrequest) * limit;

                    }
                    else
                    {
                        curpage = 0;
                        strrequest = 0;
                    }
                }
                catch
                {
                    curpage = 0;
                    strrequest = 0;
                }
                var offset = testprojet1.Skip(curpage).Take(10).ToList();
                string text = "";
                text += "<div id='qunit'></div>";
                text += "<div id='qunit-fixture'>";
                text += "<table id='tablepaging' style='width:100%'>";
                text += "<thead><tr><th><h3>Liste Des Projets &nbsp;&nbsp;Nombre de Pages :" + (nbrpage + 1) + "&nbsp; &nbsp;Total :" + testprojet1.Count()
                + "</h3></th></tr></thead><tbody>";
                foreach (var p in offset)
                {

                    var testprojet = ListeProjet.Exists(pro => pro.IdProjet == p.IdProjet && pro.Test.ToUpper().Trim() == "ARCHIVE");

                    var TestEtape =
                        ListeEtape.Exists(f => (p.IdProjet == f.IdProjet));
                    var testregion = ListeRegion.Exists(f => (f.IdProjet == p.IdProjet));
                    var testdistrict = ListeDistrict.Exists(f => f.IdProjet == p.IdProjet);
                    var testcor = ListeCor.Exists(f => f.IdCor == p.IdCor);
                    bool testdir = false, testser = false, testent = false;

                    if (testcor)
                    {
                        foreach (var cor in ListeCor)
                        {
                            if (cor.IdCor == p.IdCor)
                            {
                                testser = ListeSer.Exists(f => f.IdService == cor.IdService);
                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                if (testser)
                                {
                                    var testser1 = ListeSer.First(f => f.IdService == cor.IdService);
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                    }
                                }
                                else
                                {
                                    testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                    if (testdir)
                                    {
                                        var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir);
                                        testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite);
                                    }
                                }

                            }
                        }
                    }
                    if (TestEtape && testregion && testdistrict && testcor && testent && testdir && (testser || !testser))
                    {
                        if (testprojet)
                        {
                            text += "<tr>";
                            text += "<td>";
                            text += "<div id='design' class='col-sm-12'>";
                            text += "<div class='panel panel-primary'>";
                            text += "<div class='panel panel-heading'>";
                            text += "<h3 class='panel-title'><a id='bt_" + p.IdProjet + "' href='Javascript:expandcollapse1(" + guillemet + p.IdProjet + guillemet + "," + guillemet + p.Numero + guillemet + ");'>" + p.Numero + "</a>&nbsp;&nbsp;&nbsp;" + p.Titre.Trim() + "</h3>";
                            text += "</div>";
                            text += "<div id='" + p.IdProjet + "' style='display:none'>";

                            text += "<div class='panel panel-body'>";
                            if (p.Titre.Trim().ToUpper() == "PROJET SUPPRIMER")
                            {
                                var resp = ListeCor.First(f => f.IdCor == p.IdEnr);
                                text += "Supprimer par :<br/>";
                                text += resp.NomCor.ToUpper() + " " + resp.PrenomCor;
                                text += "<br/><label>Motif :</label><br/>";
                                text += p.Promoteur.ToUpper();
                            }
                            else
                            {
                                foreach (var eta in ListeEtape)
                                {
                                    if (eta.IdProjet == p.IdProjet)
                                    {                                        
                                        DateTime dt = Convert.ToDateTime(eta.Fin);

                                        TimeSpan ts = dt - DateTime.UtcNow;
                                        int nbr = ts.Days;
                                        if (nbr >= 0)
                                        {
                                            text += "<label style='color:red'>";
                                            text += "Etapes " + x + " :" + nbr + " Jours Restants</label><br/>";
                                        }
                                        x++;
                                    }
                                    else
                                    {
                                        x = 1;
                                    }
                                }
                                text += "<div id='description'  style='float:left;width:400px'>";
                                text += "<fieldset><legend style='color:green'>";
                                text += "Déscriptions du projet</legend> ";
                                text += "<label style='color:blue'> Titre :</label><br/><label style='color:grey'>" + p.Titre + "</label><br/>";
                                text += "<label style='color:blue'>Promoteur :</label><br/><label>" + p.Promoteur + "</label><br/>";
                                text += "<label style='color:blue'>Source :</label><br/><label>" + p.Source + "</label><br/>";
                                text += "<label style='color:blue'>Type :</label><br/><label>" + p.Type + "</label><br/>";
                                text += "<label style='color:blue'>Resumé :</label><br/><label>" + p.Capacite + "</label><br/>";

                                foreach (var dist in ListeRegion)
                                {
                                    if (dist.IdProjet == p.IdProjet)
                                    {
                                        text += "<label style='color:blue'>Région :</label><br/><label>";
                                        text += dist.LibRegion + "</label><br/>";
                                    }
                                }

                                foreach (var dist in ListeDistrict)
                                {
                                    if (dist.IdProjet == p.IdProjet)
                                    {
                                        text += "<label style='color:blue'>District :</label><br/>";
                                        text += dist.LibDistrict + "<br/>";
                                    }
                                }
                                text += "</fieldset></div><div id='etat' style='float:left;width:400px'>";

                                foreach (var etape in ListeEtape)
                                {
                                    var nbrav = ListeEtape.Where(f => f.IdProjet == p.IdProjet).Count();
                                    if (etape.IdProjet == p.IdProjet)
                                    {
                                        w++;
                                        text += "<fieldset><legend style='color:green'>Etat d'avancement " + z + "</legend>";

                                        DateTime debut = Convert.ToDateTime(etape.Debut);
                                        DateTime fin = Convert.ToDateTime(etape.Fin);

                                        
                                        text += "<label style='color:blue'>Etapes :</label><br/>" + etape.LibEtape + "<br/>";
                                        text += "<label style='color:blue'>Debut :</label><br/>";
                                        if (string.Format("{0:dd/MM/yyyy}", debut) == "31/12/2016")
                                            text += "<label hidden='hidden'>31/12/2016</label><br/>";
                                        else
                                            text += string.Format("{0:dd/MM/yyyy}", debut) + "<br/>";

                                        text += "<label style='color:blue'>Fin :</label><br/>";
                                        if (string.Format("{0:dd/MM/yyyy}", fin) == "31/12/2016")
                                            text += "<label hidden='hidden'>31/12/2016</label><br/>";
                                        else
                                            text += string.Format("{0:dd/MM/yyyy}", fin) + "<br/>";

                                        text += "<label style='color:blue'>Situation actuelle :</label><br/>" + etape.Situation + "<br/>";
                                        text += "<label style='color:blue'>Contrainte :</label><br/>" + etape.Contrainte + "<br/>";
                                        text += "<label style='color:blue'>Solution :</label><br/>" + etape.Solution + "<br/>";
                                        text += "<label style='color:blue'>Obsérvations :</label><br/>" + etape.Obs + "<br/>";
                                        text += "<label style='color:blue'>Etat :</label><br/>" + etape.Etat + "<br/>";
                                        text += "<label style='color:blue'>Niveau d'urgence :</label><br/>" + etape.Urgence + "<br/></fieldset>";
                                        z++;
                                    }
                                    else
                                    {
                                        z = 1;
                                    }
                                }

                                if (testcor)
                                {
                                    foreach (var cor in ListeCor)
                                    {
                                        if (cor.IdCor == p.IdCor)
                                        {
                                            testser = ListeSer.Exists(f => f.IdService == cor.IdService);

                                            if (testser)
                                            {
                                                var testser1 = ListeSer.First(f => f.IdService == cor.IdService);
                                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                                var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir || f.IdDir == testser1.IdDir);
                                                testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdEntite);
                                                var ent = ListeEntite.First(f => f.IdEntite == testdir1.IdEntite);
                                                text += "</div><div id='agent'  style='float:left;width:400px'>";
                                                text += "<fieldset><legend style='color:green'>Agent résponsable</legend>";
                                                text += "<label style='color:blue'>Entite résponsable:</label><br/>" + ent.LibEntite.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Direction :</label><br/>" + testdir1.LibDir.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Service :</label><br/>" + testser1.LibService.ToUpper().Trim() + "<br/>";

                                                text += "<label style='color:blue'>Agent résponsable:</label><br/>" + cor.NomCor.Trim() + " " + cor.PrenomCor.Trim() + "<br/>";
                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor + "<br/>";
                                                text += "<label style='color:blue'>E-mail:</label><br/>" + cor.EmailCor + "<br/>";
                                                text += "<a class='btn btn-info' href='addetape.aspx?id=" + p.IdProjet + "'>Ajouter Etapes</a>";
                                                text += "&nbsp;&nbsp;<a class='btn btn-info' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a>";
                                                if ((role.ToUpper().Trim() == "ADMINISTRATEUR" && Convert.ToInt32(id) == p.IdEnr) || role.ToUpper().Trim() == "ADMINISTRATEUR" || Convert.ToInt32(id) == p.IdEnr)
                                                {
                                                    text += "&nbsp;&nbsp;<a id='btsuppr'  class='btn btn-info' href='addprojet.aspx?action=supprimer&id=" + p.IdProjet + "'>Supprimer</a>";
                                                }
                                                text += "</fieldset>";
                                            }
                                            else
                                            {
                                                testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                                                var testdir1 = ListeDir.First(f => f.IdDir == cor.IdDir);
                                                testent = ListeEntite.Exists(f => f.IdEntite == testdir1.IdDir);
                                                var ent = ListeEntite.First(f => f.IdEntite == testdir1.IdEntite);

                                                text += "</div><div id='agent'  style='float:left;width:400px'>";
                                                text += "<fieldset><legend style='color:green'>Agent résponsable</legend>";
                                                text += "<label style='color:blue'>Entite résponsable:</label><br/>" + ent.LibEntite.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Direction :</label><br/>" + testdir1.LibDir.ToUpper().Trim() + "<br/>";

                                                text += "<label style='color:blue'>Agent résponsable:</label><br/>" + cor.NomCor.Trim() + " " + cor.PrenomCor.Trim() + "<br/>";
                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor + "<br/>";
                                                text += "<label style='color:blue'>E-mail:</label><br/>" + cor.EmailCor + "<br/>";

                                               
                                                text += "</fieldset>";
                                            }
                                        }
                                    }
                                }
                            }


                        }
                    }
                    //}

                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</div>";
                    text += "</td>";

                    text += "</tr>";
                }

                text += "</tbody></table>";
                text += "</div>";
                if (!string.IsNullOrEmpty(page) && int.Parse(page) > 0)
                {
                    text += "<a class='pg-normal' href='archive.aspx?page=" + 0 + "'>First</a>&nbsp;&nbsp;";
                }
                else
                {
                    text += "<Label class='pg-selected'>First</Label>&nbsp;&nbsp;";
                }
                if (!string.IsNullOrEmpty(page) && int.Parse(page) <= nbrpage && int.Parse(page) > 0)
                {
                    text += "&nbsp;&nbsp;<a  class='pg-normal' href='archive.aspx?page=" + (int.Parse(page) - 1) + "'>Previous</a>&nbsp;&nbsp;";
                }
                else
                {
                    text += "<Label class='pg-selected'>Previous</Label>&nbsp;&nbsp;";
                }

                if (!string.IsNullOrEmpty(page) && int.Parse(page) < nbrpage)
                {
                    text += "<a class='pg-normal' href='archive.aspx?page=" + (int.Parse(page) + 1) + "'>Next</a>&nbsp;&nbsp;";
                }
                else if (string.IsNullOrEmpty(page) && nbrpage>0)
                {
                    text += "<a class='pg-normal' href='archive.aspx?page=" + 1 + "'>Next</a>&nbsp;&nbsp;"; ;
                }
                else
                {
                    text += "<label class='pg-selected'>Next</label>&nbsp;&nbsp;";
                }
                if ((!string.IsNullOrEmpty(page) && int.Parse(page) < nbrpage && nbrpage>0) || (string.IsNullOrEmpty(page) && nbrpage>0))
                {
                    text += "&nbsp;&nbsp;<a class='pg-normal' href='addprojet.aspx?page=" + nbrpage + "'>Last</a><br/>";
                }
                else
                {
                    text += "<Label class='pg-selected'>Last</Label>&nbsp;&nbsp;";
                }
                text += "Pages :" + (strrequest + 1) + " / " + (nbrpage + 1);
                
                return text + " * " + text1;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public string Alert(string id)
        {
            try
            {
                ActionBLL action = new ActionBLL();
                List<Etapes> ListeEtape = new List<Etapes>();
                List<Projets> ListeProjet = new List<Projets>();
                ListeEtape = action.GetAvancement();
                ListeProjet = action.GetProjet();
                string text = "";
                foreach (var e in ListeEtape)
                {
                    DateTime fin = Convert.ToDateTime(e.Fin);

                    TimeSpan ts = fin - DateTime.UtcNow;
                    int restants = ts.Days;
                    if (restants <= 30 && restants > 0)
                    {
                        var testprojet = ListeProjet.Where(f => f.IdProjet == e.IdProjet && (f.IdEnr == int.Parse(id) || f.IdCor == int.Parse(id)));
                        foreach (var p in testprojet)
                        {
                            text += "<div class='alert alert-danger fade in'>";
                            text += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
                            text += "<strong> Le projet numéro " + p.Numero + "</strong> ne reste plus que <strong>" + ts.Days + " </strong>Jours restants. N'oubliez pas de changer l'etat si l'étape est fait. ";
                            text += "<strong>" + p.Titre + " " + fin.ToShortDateString() + "</strong></div>";                                                 
                        }
                    }
                }
                return text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                action = null;               
            }
        }

        public string Recap()
        {
            try
            {
                ActionBLL action = new ActionBLL();
                List<Projets> ListeP = new List<Projets>();
                List<Correspondants> ListeC = new List<Correspondants>();
                List<Directions> ListeD = new List<Directions>();
                List<Nombre> nombre = new List<Nombre>();
                ListeP = action.GetProjet();
                ListeC = action.GetCorrespondant();
                ListeD = action.GetDirection();
                int c = 0;
                Directions Dir = new Directions();
                string text = "";
                int total = 0;
                foreach (var d in ListeD)
                {
                    var cor = ListeC.First(f => f.IdDir == d.IdDir);
                    c = ListeP.Count(f => f.IdCor == cor.IdCor && f.Test.Trim().ToUpper() == "NOUVEAU");
                    if (c > 0)
                    {
                        nombre.Add(new Nombre
                        {
                            resp = d.LibDir.Trim(),
                            nbr = c
                        });
                    }
                }

                text += "<table border='1'><tr><td>Direction</td><td>Nombre</td></tr>";
                foreach (var l in nombre)
                {
                    text += "<tr><td>" + l.resp + "</td><td>" + l.nbr + "</td></tr>";
                    total += l.nbr;
                }
                if (total < ListeP.Count(f => f.Test.Trim().ToUpper() == "NOUVEAU"))
                {
                    text += "<tr><td></td><td>" + (ListeP.Count(f => f.Test.Trim().ToUpper() == "NOUVEAU") - total) + "</td></tr>";
                }
                /*
                var test = ListeP.Exists(f => f.Test.Trim().ToUpper() == "ARCHIVE");
                if (test)
                {
                    if (ListeP.Where(f => f.Test.Trim().ToUpper() == "ARCHIVE").Count(f => f.Test.Trim().ToUpper() == "ARCHIVE") > 0)
                    {
                        text += "<tr><td>Archive</td><td>" + ListeP.Count(f => f.Test.Trim().ToUpper() == "ARCHIVE") + "</td></tr>";
                    }
                }*/
                text += "<tr><td>Total</td><td>" + ListeP.Count() + "</td></tr></table>";
                return text;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        class Nombre
        {
            public int nbr { get; set; }
            public string resp { get; set; }
        }
    }
}
