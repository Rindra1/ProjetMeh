using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using BLL;
using BEL;
using System.Web.Security;

namespace ProjetMeh
{
    public partial class ajout : System.Web.UI.Page
    {
        private Comptes com;
        private Correspondants cor;
        private Directions dir;
        private Services ser;
        private ActionBLL action;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Remplir1();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ajout.aspx");
        }

        private void Remplir1()
        {
            char guillemet = '"';
            action = new ActionBLL();
            List<Correspondants> ListeCor = new List<Correspondants>();
            List<Directions> ListeDir = new List<Directions>();
            List<Comptes> ListeLogin = new List<Comptes>();
            List<Services> Listeservice = new List<Services>();
            List<Entites> ListeEntite = new List<Entites>();

            ListeLogin = action.GetLogins();
            ListeDir = action.GetDirection();
            ListeCor = action.GetCorrespondant();
            Listeservice = action.Getservice();
            ListeEntite = action.GetEntite();
                
            string page = Request.Params["page"];

            int limit = 10;
            int nbrpage = ListeLogin.Count() / limit;
            int curpage, strrequest;

            try
            {
                if (!string.IsNullOrEmpty(page) && int.Parse(page) <= ListeLogin.Count)
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
            var offset = ListeLogin.Skip(curpage).Take(limit).ToList();
            try
            {
                string text = "";
                text += "<table id='tablepaging' style='max-width:780px'><tr><td>Liste Login</td></tr>";
                foreach (var test in offset)
                {
                    var testcor = ListeCor.Where(f => f.IdCor == test.IdCor);
                    foreach (var cor in testcor)
                    {
                        //var testlogin = ListeLogin.Exists(f => f.IdCor == cor.IdCor);
                        var testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                        var testservice = Listeservice.Exists(f => f.IdService == cor.IdService);
                        if (testdir  && !testservice)
                        {
                            foreach (var dir in ListeDir)
                            {
                                foreach (var en in ListeEntite)
                                {
                                    foreach (var lo in ListeLogin)
                                    {
                                        if (lo.IdCor == cor.IdCor && dir.IdDir == cor.IdDir && en.IdEntite == dir.IdEntite)
                                        {
                                            text += "<tr class='even'>";
                                            text += "<td>";
                                            text += "<div class='col-sm-12'>";
                                            text += "<div class='panel panel-primary'>";
                                            text += "<div class='panel panel-heading'>";
                                            text += "<h3 class='panel-title'><a id='bt_" + cor.NomCor + "' href='Javascript:expandcollapse1(" + guillemet + lo.IdLogin + guillemet + "," + guillemet + cor.NomCor + guillemet + ");'>" + en.LibEntite.Trim().ToUpper() + "</a>&nbsp;&nbsp;" + dir.LibDir.ToUpper().Trim() + "</h3>";
                                            text += "</div>";
                                            text += "<div id='" + lo.IdLogin + "' style='display:none'>";
                                            text += "<div class='panel panel-body'>";
                                            text += "<label style='color:blue'>Entite :</label><br/>" + en.LibEntite.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>Direction :</label><br/>" + dir.LibDir.ToUpper().Trim() + "<br/>";
                                            text += "<label style='color:blue'>Nom :</label><br/>" + cor.NomCor.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>Prénom :</label><br/>" + cor.PrenomCor.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>E-mail :</label><br/>" + cor.EmailCor.Trim() + "<br/>"; ;
                                            text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>Role :</label><br/>" + lo.Role.ToUpper().Trim() + "<br/>";
                                            text += "<label style='color:blue'>Pseudo :</label><br/>" + lo.Pseudo.Trim() + "<br/>"; ;
                                            text += "<label style='color:blue'>Mot de passe :</label><br/>" + lo.Code + "<br/>";
                                            text += "<a class='btn btn-success' href='ajout.aspx?action=modifier&idl=" + lo.IdLogin + "&idc=" + cor.IdCor + "&ids=0&idd=" + dir.IdDir + "&ide=" + en.IdEntite + "'>Modifier</a>";
                                            text += "<a class='btn btn-success' href='ajout.aspx?action=supprimer&idl=" + lo.IdLogin + "'>Supprimer</a>";
                                        }
                                    }
                                }
                            }
                        }
                        else if ( testservice && !testdir)
                        {
                            foreach (var ser in Listeservice)
                            {
                                foreach (var dir in ListeDir)
                                {
                                    foreach (var en in ListeEntite)
                                    {
                                        foreach (var lo in ListeLogin)
                                        {
                                            if (ser.IdService == cor.IdService && cor.IdCor == lo.IdCor && dir.IdDir == ser.IdDir && en.IdEntite == dir.IdEntite)
                                            {
                                                text += "<tr class='even'>";
                                                text += "<td>";
                                                text += "<div class='col-sm-12'>";
                                                text += "<div class='panel panel-primary'>";
                                                text += "<div class='panel panel-heading'>";
                                                text += "<h3 class='panel-title'><a id='bt_" + cor.NomCor + "' href='Javascript:expandcollapse1(" + guillemet + lo.IdLogin + guillemet + "," + guillemet + cor.NomCor + guillemet + ");'>" + en.LibEntite.Trim().ToUpper() + "</a>&nbsp;&nbsp;" + dir.LibDir.ToUpper().Trim() + " " + ser.LibService.Trim().ToUpper() + "</h3>";
                                                text += "</div>";
                                                text += "<div id='" + lo.IdLogin + "' style='display:none'>";
                                                text += "<div class='panel panel-body'>";
                                                text += "<label style='color:blue'>Entite :</label><br/>" + en.LibEntite.Trim().ToUpper() + "<br/>";
                                                text += "<label style='color:blue'>Direction :</label><br/>" + dir.LibDir.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Service :</label><br/>" + ser.LibService.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Nom :</label><br/>" + cor.NomCor.Trim().ToUpper() + "<br/>";
                                                text += "<label style='color:blue'>Prénom :</label><br/>" + cor.PrenomCor.Trim().ToUpper() + "<br/>";
                                                text += "<label style='color:blue'>E-mail :</label><br/>" + cor.EmailCor.Trim() + "<br/>"; ;
                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor.Trim().ToUpper() + "<br/>";
                                                text += "<label style='color:blue'>Role :</label><br/>" + lo.Role.ToUpper().Trim() + "<br/>";
                                                text += "<label style='color:blue'>Pseudo :</label><br/>" + lo.Pseudo.Trim() + "<br/>"; ;
                                                text += "<label style='color:blue'>Mot de passe :</label><br/>" + lo.Code + "<br/>";
                                                text += "<a class='btn btn-success' href='ajout.aspx?action=modifier&idl=" + lo.IdLogin + "&idc=" + cor.IdCor + "&ids=" + ser.IdService + "&idd=" + dir.IdDir + "&ide=" + en.IdEntite + "'>Modifier</a>";
                                                text += "<a class='btn btn-success' href='ajout.aspx?action=supprimer&idl=" + lo.IdLogin + "'>Supprimer</a>";
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

                }
                text += "</table>";
                text += "<a class='pg-normal' href='ajout.aspx?page=" + 0 + "'>Premier</a>&nbsp;&nbsp;";
                if (!string.IsNullOrEmpty(page) && int.Parse(page) <= nbrpage && int.Parse(page) > 0)
                {
                    text += "&nbsp;&nbsp;<a  class='pg-normal' href='ajout.aspx?page=" + (int.Parse(page) - 1) + "'>Precedant</a>&nbsp;&nbsp;";
                }
                else
                {
                    text += "<Label class='pg-selected'>Precedant</Label>&nbsp;&nbsp;";
                }

                if (!string.IsNullOrEmpty(page) && int.Parse(page) < nbrpage)
                {
                    text += "<a class='pg-normal' href='ajout.aspx?page=" + (int.Parse(page) + 1) + "'>Suivant</a>&nbsp;&nbsp;";
                }
                else if (string.IsNullOrEmpty(page))
                {
                    text += "<a class='pg-normal' href='ajout.aspx?page=" + 1 + "'>Suivant</a>&nbsp;&nbsp;"; ;
                }
                else
                {
                    text += "<label class='pg-selected'>Suivant</label>&nbsp;&nbsp;";
                }
                text += "&nbsp;&nbsp;<a class='pg-normal' href='ajout.aspx?page=" + nbrpage + "'>dernier</a><br/>";
                text += "Pages :" + (strrequest + 1) + " / " + (nbrpage + 1);
                panel.InnerHtml = text;
                string actions = Request.Params["action"];
                string idl = Request.Params["idl"];
                string idc = Request.Params["idc"];
                string ids = Request.Params["ids"];
                string idd = Request.Params["idd"];
                string ide = Request.Params["ide"];
                switch (actions)
                {
                    case "supprimer":
                        Comptes c = new Comptes();
                        c.IdLogin = int.Parse(idl);
                        int idt = action.DeleteLogin(c);
                        if (idt > 0)
                        {
                            lblmsg.Text = "Comptes Supprimer avec succès! ";
                            ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                        }
                        else
                        {
                            lblmsg.Text = "Une erreur est survenue ";
                            ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                        }
                        break;
                    case "modifier":
                        var lo = ListeLogin.First(f => f.IdLogin == int.Parse(idl));
                        var co = ListeCor.First(f => f.IdCor == int.Parse(idc));
                        var dir = ListeDir.First(f => f.IdDir == int.Parse(idd));
                        var en = ListeEntite.First(f => f.IdEntite == int.Parse(ide));
                        if (int.Parse(ids) > 0)
                        {
                            var se = Listeservice.First(f => f.IdService == int.Parse(ids));
                            txtservice.Text = se.LibService;
                        }
                        txtpseudo.Text = lo.Pseudo;
                        txtnom.Text = co.NomCor;
                        txtprenom.Text = co.PrenomCor;
                        txtmail.Text = co.EmailCor;
                        txttel.Text = co.TelCor;
                        txtfonction.Text = dir.LibDir;
                        ddlentite.SelectedValue = Convert.ToString(en.IdEntite);
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "<br/>" + ex.StackTrace);
            }
            finally
            {
                ListeCor = null;
                ListeDir = null;
                ListeEntite = null;
                ListeLogin = null;
                Listeservice = null;
                action = null;

            }   


        }


        private void Remplir()
        {
            char guillemet = '"';
            action = new ActionBLL();
            List<Correspondants> ListeCor = new List<Correspondants>();
            List<Directions> ListeDir = new List<Directions>();
            List<Comptes> ListeLogin = new List<Comptes>();
            List<Services> Listeservice = new List<Services>();
            List<Entites> ListeEntite = new List<Entites>();
            try
            {
                string text = "";
                text += "<table id='tablepaging' style='max-width:780px'><tr><td>Liste Login</td></tr>";
                ListeLogin = action.GetLogins();
                ListeDir = action.GetDirection();
                ListeCor = action.GetCorrespondant();
                Listeservice = action.Getservice();
                ListeEntite = action.GetEntite();
                foreach (var cor in ListeCor)
                {
                    var testlogin = ListeLogin.Exists(f => f.IdCor == cor.IdCor);
                    var testdir = ListeDir.Exists(f => f.IdDir == cor.IdDir);
                    var testservice = Listeservice.Exists(f => f.IdService == cor.IdService);
                    if (testdir && testlogin && !testservice)
                    {
                        foreach (var dir in ListeDir)
                        {
                            foreach (var en in ListeEntite)
                            {
                                foreach (var lo in ListeLogin)
                                {
                                    if (lo.IdCor == cor.IdCor && dir.IdDir == cor.IdDir && en.IdEntite == dir.IdEntite)
                                    {
                                        text += "<tr class='even'>";
                                        text += "<td>";
                                        text += "<div class='col-sm-12'>";
                                        text += "<div class='panel panel-primary'>";
                                        text += "<div class='panel panel-heading'>";
                                        text += "<h3 class='panel-title'><a id='bt_" + cor.NomCor + "' href='Javascript:expandcollapse1(" + guillemet + lo.IdLogin + guillemet + "," + guillemet + cor.NomCor + guillemet + ");'>" + en.LibEntite.Trim().ToUpper() + "</a>&nbsp;&nbsp;" + dir.LibDir.ToUpper().Trim() + "</h3>";
                                        text += "</div>";
                                        text += "<div id='" + lo.IdLogin + "' style='display:none'>";
                                        text += "<div class='panel panel-body'>";
                                        text += "<label style='color:blue'>Entite :</label><br/>" + en.LibEntite.Trim().ToUpper() + "<br/>";
                                        text += "<label style='color:blue'>Direction :</label><br/>" + dir.LibDir.ToUpper().Trim() + "<br/>";
                                        text += "<label style='color:blue'>Nom :</label><br/>" + cor.NomCor.Trim().ToUpper() + "<br/>";
                                        text += "<label style='color:blue'>Prénom :</label><br/>" + cor.PrenomCor.Trim().ToUpper() + "<br/>";
                                        text += "<label style='color:blue'>E-mail :</label><br/>" + cor.EmailCor.Trim() + "<br/>"; ;
                                        text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor.Trim().ToUpper() + "<br/>";
                                        text += "<label style='color:blue'>Role :</label><br/>" + lo.Role.ToUpper().Trim() + "<br/>";
                                        text += "<label style='color:blue'>Pseudo :</label><br/>" + lo.Pseudo.Trim() + "<br/>"; ;
                                        text += "<label style='color:blue'>Mot de passe :</label><br/>" + lo.Code + "<br/>";
                                        text += "<a class='btn btn-success' href='ajout.aspx?action=modifier&idl=" + lo.IdLogin + "&idc=" + cor.IdCor + "&ids=0&idd=" + dir.IdDir + "&ide=" + en.IdEntite + "'>Modifier</a>";
                                        text += "<a class='btn btn-success' href='ajout.aspx?action=supprimer&idl=" + lo.IdLogin + "'>Supprimer</a>";
                                    }
                                }
                            }
                        }
                    }
                    else if (testlogin && testservice && !testdir)
                    {
                        foreach (var ser in Listeservice)
                        {
                            foreach (var dir in ListeDir)
                            {
                                foreach (var en in ListeEntite)
                                {
                                    foreach (var lo in ListeLogin)
                                    {
                                        if (ser.IdService == cor.IdService && cor.IdCor == lo.IdCor && dir.IdDir == ser.IdDir && en.IdEntite == dir.IdEntite)
                                        {
                                            text += "<tr class='even'>";
                                            text += "<td>";
                                            text += "<div class='col-sm-12'>";
                                            text += "<div class='panel panel-primary'>";
                                            text += "<div class='panel panel-heading'>";
                                            text += "<h3 class='panel-title'><a id='bt_" + cor.NomCor + "' href='Javascript:expandcollapse1(" + guillemet + lo.IdLogin + guillemet + "," + guillemet + cor.NomCor + guillemet + ");'>" + en.LibEntite.Trim().ToUpper() + "</a>&nbsp;&nbsp;" + dir.LibDir.ToUpper().Trim() + " " + ser.LibService.Trim().ToUpper() + "</h3>";
                                            text += "</div>";
                                            text += "<div id='" + lo.IdLogin + "' style='display:none'>";
                                            text += "<div class='panel panel-body'>";
                                            text += "<label style='color:blue'>Entite :</label><br/>" + en.LibEntite.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>Direction :</label><br/>" + dir.LibDir.ToUpper().Trim() + "<br/>";
                                            text += "<label style='color:blue'>Service :</label><br/>" + ser.LibService.ToUpper().Trim() + "<br/>";
                                            text += "<label style='color:blue'>Nom :</label><br/>" + cor.NomCor.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>Prénom :</label><br/>" + cor.PrenomCor.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>E-mail :</label><br/>" + cor.EmailCor.Trim() + "<br/>"; ;
                                            text += "<label style='color:blue'>Téléphone :</label><br/>" + cor.TelCor.Trim().ToUpper() + "<br/>";
                                            text += "<label style='color:blue'>Role :</label><br/>" + lo.Role.ToUpper().Trim() + "<br/>";
                                            text += "<label style='color:blue'>Pseudo :</label><br/>" + lo.Pseudo.Trim() + "<br/>"; ;
                                            text += "<label style='color:blue'>Mot de passe :</label><br/>" + lo.Code + "<br/>";
                                            text += "<a class='btn btn-success' href='ajout.aspx?action=modifier&idl=" + lo.IdLogin + "&idc=" + cor.IdCor + "&ids=" + ser.IdService + "&idd=" + dir.IdDir + "&ide=" + en.IdEntite + "'>Modifier</a>";
                                            text += "<a class='btn btn-success' href='ajout.aspx?action=supprimer&idl=" + lo.IdLogin + "'>Supprimer</a>";
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
                text += "</table>";
                text += "<div id='pageNavposition' style='padding-top:0; text-align:center'></div>";
                text += "<script type='text/javascript'>var pager = new Pager('tablepaging', 6);";
                text += "pager.init();pager.showPageNav('pager', 'pageNavposition');pager.showPage(1);";
                text += "</script>";
                panel.InnerHtml = text;
                string actions = Request.Params["action"];
                string idl = Request.Params["idl"];
                string idc = Request.Params["idc"];
                string ids = Request.Params["ids"];
                string idd = Request.Params["idd"];
                string ide = Request.Params["ide"];
                switch (actions)
                {
                    case "supprimer":
                        Comptes c = new Comptes();
                        c.IdLogin = int.Parse(idl);
                        int idt = action.DeleteLogin(c);
                        if (idt > 0)
                        {
                            lblmsg.Text = "Comptes Supprimer avec succès! ";
                            ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                        }
                        else
                        {
                            lblmsg.Text = "Une erreur est survenue ";
                            ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                        }
                        break;
                    case "modifier":
                        var lo = ListeLogin.First(f => f.IdLogin == int.Parse(idl));
                        var co = ListeCor.First(f => f.IdCor == int.Parse(idc));
                        var dir = ListeDir.First(f => f.IdDir == int.Parse(idd));
                        var en = ListeEntite.First(f => f.IdEntite == int.Parse(ide));
                        if (int.Parse(ids) > 0)
                        {
                            var se = Listeservice.First(f => f.IdService == int.Parse(ids));
                            txtservice.Text = se.LibService;
                        }
                        txtpseudo.Text = lo.Pseudo;
                        txtnom.Text = co.NomCor;
                        txtprenom.Text = co.PrenomCor;
                        txtmail.Text = co.EmailCor;
                        txttel.Text = co.TelCor;
                        txtfonction.Text = dir.LibDir;
                        ddlentite.SelectedValue = Convert.ToString(en.IdEntite);
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "<br/>" + ex.StackTrace);
            }
            finally
            {
                ListeCor = null;
                ListeDir = null;
                ListeEntite = null;
                ListeLogin = null;
                Listeservice = null;
                action = null;
               
            }


        }

        protected void bt_ok_Click(object sender, EventArgs e)
        {
            com = new Comptes();
            cor = new Correspondants();
            dir = new Directions();
            ser = new Services();
            action = new ActionBLL();
            List<Comptes> ListeComptes = new List<Comptes>();
            int idlogin = 0;
            int id = 0;
            int iddir = 0;
            int idser = 0;
            int idcor = 0;
            string correspondants = Request.Params["correspondant"];
            try
            {
                com.Pseudo = txtpseudo.Text.Trim();
                com.Role = ddlrole.SelectedItem.Text.Trim();
                com.Code = FormsAuthentication.HashPasswordForStoringInConfigFile(txtmdp.Text, "MD5");
                cor.EmailCor = txtmail.Text.Trim();
                cor.NomCor = txtnom.Text.Trim().ToUpper();
                cor.PrenomCor = txtprenom.Text.Trim().ToLower();
                cor.TelCor = txttel.Text.Trim();
                dir.LibDir = txtfonction.Text.Trim().ToUpper();
                dir.IdEntite = int.Parse(ddlentite.SelectedValue);
                if (string.IsNullOrEmpty(Request.Params["action"]))
                {
                    id = action.Testlogin(com);
                    if (id > 0)
                    {

                    }
                    else
                    {
                        iddir = action.TestDir(dir);
                        if (!string.IsNullOrEmpty(txtservice.Text))
                        {
                            ser.LibService = txtservice.Text.Trim().ToUpper();
                            ser.IdDir = iddir;
                            idser = action.TestService(ser);
                            cor.IdService = idser;
                            idcor = action.TestCor(cor);
                            com.IdCor = idcor;
                            idlogin = action.AddLogin(com);
                            if (idlogin > 0)
                            {
                                lblmsg.Text = "Comptes ajouter avec succés!";
                                ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            cor.IdDir = iddir;
                            idcor = action.TestCor(cor);
                            com.IdCor = idcor;
                            idlogin = action.AddLogin(com);
                            lblmsg.Text = "Comptes ajouter avec succés!";
                            ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);                            
                        }
                    }
                }
                else
                {
                    List<Comptes> ListeCompte = new List<Comptes>();
                    ListeCompte = action.GetLogins();
                    var test = ListeCompte.Exists(f => f.Pseudo.Trim() == txtpseudo.Text.Trim() && f.IdLogin != Convert.ToInt32(Request.Params["idl"]));
                    if (!test)
                    {
                        iddir = action.TestDir(dir);                            
                        if (!string.IsNullOrEmpty(txtservice.Text))
                        {                        
                            ser.LibService = txtservice.Text.Trim().ToUpper();
                            ser.IdDir = iddir;
                            idser = action.TestService(ser);                                                        
                            cor.IdService = idser;
                            cor.IdCor = int.Parse(Request.Params["idc"]);  
                            idcor = action.UpdateCorrespondant(cor);                        
                            com.IdCor = int.Parse(Request.Params["idc"]);
                            com.IdLogin = int.Parse(Request.Params["idl"]);                            
                            idlogin = action.UpdateLogin(com);
                            lblmsg.Text = "Comptes modifier avec succès!";
                            ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);                            
                        }
                        else
                        {
                            cor.IdDir = iddir;
                            cor.IdCor = int.Parse(Request.Params["idc"]);
                            idcor = action.UpdateCorrespondant(cor);                            
                            com.IdCor = int.Parse(Request.Params["idc"]);
                            com.IdLogin = int.Parse(Request.Params["idl"]);                            
                            idlogin = action.UpdateLogin(com);
                            lblmsg.Text = "Comptes modifier avec succés!";
                            ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);                            
                        }
                    }
                    else
                    {
                        Response.Write("<h1>Pseudo deja existant</h1>");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "L'erreur suivante s'est derouler: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
            }
        }

        protected void bt_annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("accueil.aspx");
        }
    }
}