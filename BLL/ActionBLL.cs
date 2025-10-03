using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BEL;
using DAL;
using System.Net;
using System.Net.Mail;
using System.IO.Ports;

namespace BLL
{
    public class ActionBLL
    {
        private SerialPort SP = new SerialPort();

        #region MESSAGE
        public string MessageMail(string host,string dest,string exp,string obj,string msge,string mdp)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(exp, exp);
                msg.To.Add(new MailAddress(dest));
                msg.Subject = obj;
                msg.Body = msge;
                msg.Priority = MailPriority.High;
                msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = host ;
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(exp, mdp);
                smtp.EnableSsl = true;                
                smtp.Send(msg);
                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public string SendSms(string num,string msg)
        {
            try
            {
                SP.PortName = "COM9";
                SP.Open();
                string ph_no;
                ph_no = char.ConvertFromUtf32(34) + num + char.ConvertFromUtf32(34);
                SP.Write("AT+CMGF=1" + char.ConvertFromUtf32(13));
                SP.Write("AT+CMGS=" + ph_no + char.ConvertFromUtf32(13));
                SP.Write(msg + char.ConvertFromUtf32(26) + char.ConvertFromUtf32(13));
                SP.Close();
                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Entite
        public List<Entites> GetEntite()
        {
            EntiteDAL objdal = new EntiteDAL();
            try
            {
                return objdal.GetEntite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }


        public string Get(Projets projet,Etapes etape,Region region)
        {
            string text = "";
            ActionBLL action = new ActionBLL();
            List<Projets> ListeProjet = new List<Projets>();
            List<Etapes> ListeEtape = new List<Etapes>();
            List<Region> ListeRegion=new List<Region>();


            ListeProjet = action.GetProjet();
            ListeEtape = action.GetAvancement();
            ListeRegion=action.GetRegion();

            var testetape = ListeEtape.Exists(et =>
                            (et.Debut.Contains(etape.Debut) || string.IsNullOrEmpty(etape.Debut))
                                && (et.Fin.Contains(etape.Fin) || string.IsNullOrEmpty(etape.Fin))
                                && (et.LibEtape.ToUpper().Contains(etape.LibEtape.ToUpper()) || string.IsNullOrEmpty(etape.LibEtape))
                                && (et.Urgence.ToUpper().Contains(etape.Urgence.ToUpper()) || string.IsNullOrEmpty(etape.Urgence))
                                && (et.Obs.ToUpper().Contains(etape.Obs.ToUpper()) || string.IsNullOrEmpty(etape.Obs))
                                && (et.Contrainte.ToUpper().Contains(etape.Contrainte.ToUpper()) || string.IsNullOrEmpty(etape.Contrainte))
                                && (et.Solution.ToUpper().Contains(etape.Solution.ToUpper()) || string.IsNullOrEmpty(etape.Solution))
                                && (et.Etat.ToUpper().Contains(etape.Etat.ToUpper()) || string.IsNullOrEmpty(etape.Etat)));

            var testprojet = ListeProjet.Exists(p => (p.Titre.ToUpper().Contains(projet.Titre.ToUpper()) || string.IsNullOrEmpty(projet.Titre))
                            && (p.Numero.ToUpper().Contains(projet.Numero.ToUpper()) || string.IsNullOrEmpty(projet.Numero))
                            && (p.Promoteur.ToUpper().Contains(projet.Promoteur.ToUpper()) || string.IsNullOrEmpty(projet.Promoteur))
                            && (p.Type.ToUpper().Contains(projet.Type.ToUpper()) || string.IsNullOrEmpty(projet.Type))
                            && (p.Capacite.ToUpper().Contains(projet.Capacite.ToUpper()) || string.IsNullOrEmpty(projet.Capacite))
                            && (p.Source.ToUpper().Contains(projet.Source.ToUpper()) || string.IsNullOrEmpty(projet.Source))
                           );
            var testregion = ListeRegion.Exists(f => f.LibRegion.ToUpper().Contains(region.LibRegion.ToUpper()) || string.IsNullOrEmpty(region.LibRegion));
            foreach (var p in ListeProjet)
            {
                
                    if ((p.Titre.ToUpper().Contains(projet.Titre.ToUpper()) || string.IsNullOrEmpty(projet.Titre))
                            && (p.Numero.ToUpper().Contains(projet.Numero.ToUpper()) || string.IsNullOrEmpty(projet.Numero))
                            && (p.Promoteur.ToUpper().Contains(projet.Promoteur.ToUpper()) || string.IsNullOrEmpty(projet.Promoteur))
                            && (p.Type.ToUpper().Contains(projet.Type.ToUpper()) || string.IsNullOrEmpty(projet.Type))
                            && (p.Capacite.ToUpper().Contains(projet.Capacite.ToUpper()) || string.IsNullOrEmpty(projet.Capacite))
                            && (p.Source.ToUpper().Contains(projet.Source.ToUpper()) || string.IsNullOrEmpty(projet.Source))
                        && (testregion))
                    {
                        text += "Titre :" + p.Titre;
                        /*
                        foreach (var reg in ListeRegion)
                        {
                            if (reg.IdProjet == p.IdProjet)
                                text += " Region :" + reg.LibRegion;
                        }
                         */
                        foreach (var e in ListeEtape)
                        {
                            if(e.IdProjet==p.IdProjet)
                            text += " Etapes :" + e.LibEtape + "<br/>";
                        }
                    }
                
            }
            return text;

        }


        #endregion

        #region Accueil
        public string GetAccueil(Projets p,Etapes e,Region reg,District dis,Correspondants cor,Directions dir,Entites ent,Services ser)
        {
            char guillemet = '"';
            string text="";
            ActionBLL action = new ActionBLL();
            List<Projets> ListeProjet = new List<Projets>();
            List<Etapes> ListeEtape = new List<Etapes>();
            List<Etapes> ListeEtape1 = new List<Etapes>();


            List<Correspondants> ListeCor = new List<Correspondants>();
            List<District> ListeDistrict = new List<District>();
            List<Region> ListeRegion = new List<Region>();
            List<Services> ListeService = new List<Services>();
            List<Entites> ListeEntite = new List<Entites>();
            List<Directions> ListeDir = new List<Directions>();

            try
            {
                text += "<table id='tablepaging' style='width:100%'>";
                text += "<tr><td><h3>Liste Des Projets</h3></td></tr>";

                ListeProjet = action.GetProjet();
                ListeEtape = action.GetAvancement();

                ListeEtape1 = action.GetAvancement();
                ListeCor = action.GetCorrespondant();
                ListeDistrict = action.GetDistrict();
                ListeRegion = action.GetRegion();
                ListeCor = action.GetCorrespondant();
                ListeDir = action.GetDirection();
                ListeEntite = action.GetEntite();
                ListeService = action.Getservice();

                var testprojet = ListeProjet.Exists(pr => (pr.Titre.ToUpper().Contains(p.Titre.ToUpper()) || string.IsNullOrEmpty(p.Titre))
                            && (pr.Numero.ToUpper().Contains(p.Numero.ToUpper()) || string.IsNullOrEmpty(p.Numero))
                           && (pr.Promoteur.ToUpper().Contains(p.Promoteur.ToUpper()) || string.IsNullOrEmpty(p.Promoteur))
                            && (pr.Type.ToUpper().Contains(p.Type.ToUpper()) || string.IsNullOrEmpty(p.Type))
                            && (pr.Capacite.ToUpper().Contains(p.Capacite.ToUpper()) || string.IsNullOrEmpty(p.Capacite))
                            && (pr.Source.ToUpper().Contains(p.Source.ToUpper()) || string.IsNullOrEmpty(p.Source)));


                foreach (var projet in ListeProjet)
                {
                    int i = 1;
                    int z = 1;
                    
                    var testetape = ListeEtape.Exists(et =>
                            (et.Debut.Contains(e.Debut) || string.IsNullOrEmpty(e.Debut))
                                && (et.Fin.Contains(e.Fin) || string.IsNullOrEmpty(e.Fin))
                                && (et.LibEtape.ToUpper().Contains(e.LibEtape.ToUpper()) || string.IsNullOrEmpty(e.LibEtape))
                                && (et.Urgence.ToUpper().Contains(e.Urgence.ToUpper()) || string.IsNullOrEmpty(e.Urgence))
                                && (et.Obs.ToUpper().Contains(e.Obs.ToUpper()) || string.IsNullOrEmpty(e.Obs))
                                && (et.Contrainte.ToUpper().Contains(e.Contrainte.ToUpper()) || string.IsNullOrEmpty(e.Contrainte))
                                && (et.Solution.ToUpper().Contains(e.Solution.ToUpper()) || string.IsNullOrEmpty(e.Solution))
                                && (et.Etat.ToUpper().Contains(e.Etat.ToUpper()) || string.IsNullOrEmpty(e.Etat))
                            );
                    
                        var testeregion = ListeRegion.Exists(f=>f.LibRegion.ToUpper().Contains(reg.LibRegion.ToUpper())||string.IsNullOrEmpty(reg.LibRegion));
                        var testedistrict = ListeDistrict.Exists(f => f.LibDistrict.ToUpper().Contains(dis.LibDistrict.ToUpper()) || string.IsNullOrEmpty(dis.LibDistrict));
                        
                        var testcor = ListeCor.Exists(f => (f.NomCor.ToUpper().Contains(cor.NomCor.ToUpper()) || string.IsNullOrEmpty(cor.NomCor))
                            && (f.PrenomCor.ToUpper().Contains(cor.PrenomCor.ToUpper()) || string.IsNullOrEmpty(cor.PrenomCor))
                            && (f.TelCor.ToUpper().Contains(cor.TelCor.ToUpper()) || string.IsNullOrEmpty(cor.TelCor))
                            && (f.EmailCor.ToUpper().Contains(cor.EmailCor.ToUpper()) || string.IsNullOrEmpty(cor.EmailCor)));
                        
                        var testdir = ListeDir.Exists(f => f.LibDir.ToUpper().Contains(dir.LibDir.ToUpper()) || string.IsNullOrEmpty(dir.LibDir));
                        var testentite = ListeEntite.Exists(f => f.LibEntite.ToUpper().Contains(ent.LibEntite.ToUpper()) || string.IsNullOrEmpty(ent.LibEntite));
                        var testservice = ListeService.Exists(f => f.LibService.ToUpper().Contains(ser.LibService.ToUpper()) || string.IsNullOrEmpty(ser.LibService));
                    
                        if ((projet.Titre.ToUpper().Contains(p.Titre.ToUpper()) || string.IsNullOrEmpty(p.Titre))
                            && (projet.Numero.ToUpper().Contains(p.Numero.ToUpper()) || string.IsNullOrEmpty(p.Numero))
                            && (projet.Promoteur.ToUpper().Contains(p.Promoteur.ToUpper()) || string.IsNullOrEmpty(p.Promoteur))
                            && (projet.Type.ToUpper().Contains(p.Type.ToUpper()) || string.IsNullOrEmpty(p.Type))
                            && (projet.Capacite.ToUpper().Contains(p.Capacite.ToUpper()) || string.IsNullOrEmpty(p.Capacite))
                            && (projet.Source.ToUpper().Contains(p.Source.ToUpper()) || string.IsNullOrEmpty(p.Source))
                            && (testetape))
                        {
                           //foreach(var et in ListeEtape){
                            //if (testetape)    
                            //{                                
                                if (testedistrict)
                                {
                                    if (testeregion)
                                    {
                                        if (testcor)
                                        {
                                            if (testdir)
                                            {
                                                if (testentite)
                                                {
                                                    if (!testservice)
                                                    {
                                                        string titre = projet.Numero + p.Titre;
                                                        text += "<tr class='even'>";
                                                        text += "<td>";
                                                        text += "<div class='col-sm-12'>";
                                                        text += "<div class='panel panel-primary'>";
                                                        text += "<div class='panel panel-heading'>";
                                                        text += "<h3 class='panel-title'><a id='bt_" + projet.IdProjet + "' href='Javascript:expandcollapse1(" + guillemet + projet.IdProjet + guillemet + "," + guillemet + projet.Numero + guillemet + ");'>" + projet.Numero + "</a>&nbsp;&nbsp;&nbsp;" + projet.Titre.Trim() + "</h3>";
                                                        text += "</div>";
                                                        text += "<div id='" + projet.IdProjet + "' style='display:none'>";

                                                        text += "<div class='panel panel-body'>";
                                                        text += "<div id='description'  style='float:left;width:400px'>";
                                                        foreach (var eta in ListeEtape1)
                                                        {
                                                            if (eta.IdProjet == projet.IdProjet)
                                                            {
                                                                TimeSpan ts = Convert.ToDateTime(eta.Fin) - DateTime.UtcNow;
                                                                int nbr = ts.Days;
                                                                text += "<label style='color:red'>";
                                                                text += "Etapes " + i + " :" + nbr + " Jours Restants</label><br/>";
                                                                i++;
                                                            }
                                                            else
                                                            {
                                                                i = 1;
                                                            }

                                                        }

                                                        text += "<fieldset><legend style='color:blue'>";
                                                        text += "Déscriptions du projet</legend> ";
                                                        text += "<label style='color:blue'> Titre :</label><br/>" + projet.Titre + "<br/>";
                                                        text += "<label style='color:blue'>Promoteur :</label><br/>" + projet.Promoteur + "<br/>";
                                                        text += "<label style='color:blue'>Source :</label><br/>" + projet.Source + "<br/>";
                                                        text += "<label style='color:blue'>Type :</label><br/>" + projet.Type + "<br/>";
                                                        text += "<label style='color:blue'>Capacite :</label><br/>" + projet.Capacite + "<br/>";

                                                        foreach (var re in ListeRegion)
                                                        {
                                                            if (projet.IdProjet == re.IdProjet)
                                                            {
                                                                text += "<label style='color:blue;'>Region :</label><br/>" + re.LibRegion + "<br/>";
                                                            }
                                                        }
                                                        foreach (var di in ListeDistrict)
                                                        {
                                                            if (projet.IdProjet == di.IdProjet)
                                                            {
                                                                text += "<label style='color:blue;'>District fory :</label><br/>" + di.LibDistrict + "<br/>";
                                                            }
                                                        }

                                                        text += "</fieldset></div><div id='etat' style='float:left;width:400px'>";



                                                        foreach (var eta in ListeEtape)
                                                        {

                                                            if (eta.IdProjet == projet.IdProjet)
                                                            {
                                                                //int i = 1;

                                                                text += "<fieldset><legend style='color:blue'>Etat d'avancement " + z + "</legend>";

                                                                DateTime Debut = Convert.ToDateTime(eta.Debut);
                                                                DateTime Fin = Convert.ToDateTime(eta.Fin);

                                                                text += "<label style='color:blue'>Etapes :</label><br/>" + eta.LibEtape + "<br/>";
                                                                text += "<label style='color:blue'>Debut :</label><br/>" + string.Format("{0:dd/MM/yyyy}", Debut) + "<br/>";
                                                                text += "<label style='color:blue'>Fin :</label><br/>" + string.Format("{0:dd/MM/yyyy}", Fin) + "<br/>";
                                                                text += "<label style='color:blue'>Situation actuelle :</label><br/>";
                                                                text += "<label style='color:blue'>Contrainte :</label><br/>" + eta.Contrainte + "<br/>";
                                                                text += "<label style='color:blue'>Solution :</label><br/>" + eta.Solution + "<br/>";
                                                                text += "<label style='color:blue'>Obsérvations :</label><br/>" + eta.Obs + "<br/>";
                                                                text += "<label style='color:blue'>Etat :</label><br/>" + eta.Etat + "<br/>";
                                                                text += "<label style='color:blue'>Niveau d'urgence :</label><br/>" + eta.Urgence + "<br/></fieldset>";

                                                                z++;

                                                            }
                                                            else
                                                            {
                                                                z = 1;
                                                            }
                                                        }

                                                        foreach (var co in ListeCor)
                                                        {
                                                            if (co.IdCor == projet.IdCor)
                                                            {
                                                                foreach (var di in ListeDir)
                                                                {
                                                                    if (di.IdDir == co.IdDir)
                                                                    {
                                                                        foreach (var en in ListeEntite)
                                                                        {
                                                                            if (en.IdEntite == di.IdEntite)
                                                                            {
                                                                                text += "</div><div style='float:left;width:400px'>";
                                                                                text += "<fieldset><legend style='color:blue'>Correspondants</legend>";
                                                                                text += "<label style='color:blue'>Entite Responsable :</label><br/>" + en.LibEntite + "<br/>";
                                                                                text += "<label style='color:blue'>Direction :</label><br/>" + di.LibDir + "<br/>";
                                                                                text += "<label style='color:blue'>Nom et Prénom :</label><br/>" + co.NomCor.ToUpper().Trim() + " " + co.PrenomCor.ToUpper().Trim() + "<br/>";
                                                                                text += "<label style='color:blue'>E-mail :</label><br/>" + co.EmailCor + "<br/>";
                                                                                text += "<label style='color:blue'>Téléphone :</label><br/>" + co.TelCor + "<br/>";
                                                                                text += "</fieldset>";
                                                                                

                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {


                                                    }
                                                    text += "<a class='btn btn-success' href='update.aspx?id=" + p.IdProjet + "'>Modifier</a></fieldset>";                                           
                                                                                
                                                    text += "</div>";
                                                    text += "</div>";
                                                    text += "</div>";
                                                    text += "</div>";
                                                    text += "</div>";
                                                    text += "</td>";
                                                    text += "</tr>";
                                                }
                                            }
                                        }
                                    //}
                               }
                            }
                            }
                        //}
             
                }

                text += "</table>";
                text += "<div id='pageNavposition' style='padding-top:0; text-align:center'></div>";
                text += "<script type='text/javascript'>var pager = new Pager('tablepaging', 3);";
                text += "pager.init();pager.showPageNav('pager', 'pageNavposition');pager.showPage(1);";
                text += "</script>";
                return text;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Entites
        public Int32 GetEntite(Entites obj)
        {
            EntiteDAL objdal = new EntiteDAL();
            List<Entites> Liste = new List<Entites>();
            try
            {
                Liste = objdal.GetEntite();
                var test = Liste.First(f => f.LibEntite.Trim().ToUpper() == obj.LibEntite.Trim().ToUpper());
                return test.IdEntite;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
                Liste.Clear();
            }

        }
        #endregion

        #region Direction
        public Int32 TestDir(Directions obj)
        {
            DirectionsDAL objdal = new DirectionsDAL();
            List<Directions> liste = new List<Directions>();                
            try
            {
                liste = objdal.GetDirection();
                var test = liste.Count;
                if (test > 0)
                {
                    var test1 = liste.Exists(f => f.LibDir.Trim().ToUpper() == obj.LibDir.Trim().ToUpper()
                        && f.IdEntite == obj.IdEntite);
                    if (test1)
                    {
                        var test2 = liste.First(f => f.LibDir.Trim().ToUpper() == obj.LibDir.Trim().ToUpper()
                        && f.IdEntite == obj.IdEntite);
                        return test2.IdDir;
                    }
                    else
                    {
                        return objdal.AddDirection(obj);
                    }
                }
                else
                {
                    return objdal.AddDirection(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                liste.Clear();
                obj = null;
                objdal = null;
            }
        }

        public List<Directions> GetDirection()
        {
            DirectionsDAL objdal = new DirectionsDAL();
            try
            {
                return objdal.GetDirection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }

        public Int32 AddDirection(Directions obj)
        {
            DirectionsDAL objdal = new DirectionsDAL();
            try
            {
                return objdal.AddDirection(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }
        #endregion

        #region Service

        public List<Services> Getservice()
        {
            ServiceDAL objdal = new ServiceDAL();
            try
            {
                return objdal.GetService();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }


        public Int32 TestService(Services obj)
        {
            ServiceDAL objdal = new ServiceDAL();
            List<Services> liste = new List<Services>();

            try
            {
                liste = objdal.GetService();
                var test = liste.Count;
                if (test > 0)
                {
                    var test1 = liste.Exists(f => f.LibService.Trim().ToUpper() == obj.LibService.Trim().ToUpper()
                        && f.IdDir == obj.IdDir);
                    if (test1)
                    {
                        var test2 = liste.First(f => f.LibService.Trim().ToUpper() == obj.LibService.Trim().ToUpper()
                        && f.IdDir == obj.IdDir);
                        return test2.IdService;
                    }
                    else
                    {
                        return objdal.AddService(obj);
                    }
                }
                else
                {
                    return objdal.AddService(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                liste.Clear();
                obj = null;
                objdal = null;
            }
        }

        public Int32 AddService(Services obj)
        {
            ServiceDAL objdal = new ServiceDAL();
            try
            {
                return objdal.AddService(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }
        #endregion

        #region Correspondant

        public Int32 TestCor(Correspondants cor)
        {
            CorrespondantsDAL objdal = new CorrespondantsDAL();
            List<Correspondants> Liste = new List<Correspondants>();

            try
            {

                Liste = objdal.GetCorrespondant();
                var test = Liste.Count;
                if (test > 0)
                {
                    Liste = objdal.GetCorrespondant();
                    var test1 = Liste.Exists(f => f.NomCor.Trim().ToUpper() == cor.NomCor
                        && f.PrenomCor.Trim().ToLower() == cor.PrenomCor &&
                        f.TelCor.Trim() == cor.TelCor && f.EmailCor.Trim().ToLower() == cor.EmailCor
                        && f.IdDir == cor.IdDir && f.IdService == cor.IdService);
                    if (test1)
                    {
                        var test2 = Liste.First(f => f.NomCor.Trim().ToUpper() == cor.NomCor
                        && f.PrenomCor.Trim().ToLower() == cor.PrenomCor &&
                        f.TelCor.Trim() == cor.TelCor && f.EmailCor.Trim().ToLower() == cor.EmailCor
                        && f.IdDir == cor.IdDir && f.IdService == cor.IdService);
                        return test2.IdCor;
                    }
                    else
                    {
                        return objdal.AddCorrespondant(cor);
                    }

                }
                else
                {
                    return objdal.AddCorrespondant(cor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
                Liste = null;
                cor = null;
            }
                 
        }

        


        public List<Correspondants> GetCorrespondant()
        {
            CorrespondantsDAL objdal = new CorrespondantsDAL();
            try
            {
                return objdal.GetCorrespondant();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }

        public Int32 AddCorrespondant(Correspondants obj)
        {
            CorrespondantsDAL objdal = new CorrespondantsDAL();
            try
            {
                return objdal.AddCorrespondant(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        public Int32 UpdateCorrespondant(Correspondants obj)
        {
            CorrespondantsDAL objdal = new CorrespondantsDAL();
            try
            {
                return objdal.UpdateCorrespondant(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        #endregion

        #region Login



        public Int32 Testlogin(Comptes obj)
        {
            LoginDAL objdal = new LoginDAL();
            List<Comptes> Liste = new List<Comptes>();
            try
            {
                Liste = objdal.GetLogins();

                var testlogin1 = Liste.Exists(f => f.Pseudo.Trim() == obj.Pseudo.Trim());
                if (!testlogin1)
                {
                    return 0;
                }
                else
                {
                    var testlogin2 = Liste.First(f => f.Pseudo.Trim() == obj.Pseudo.Trim());
                    return testlogin2.IdLogin;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
                Liste.Clear();
            }
        }

        public List<Comptes> GetLogins()
        {
            LoginDAL objdal = new LoginDAL();
            try
            {
                return objdal.GetLogins();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }


        public Int32 AddLogin(Comptes obj)
        {
            LoginDAL objdal = new LoginDAL();
            try
            {
                return objdal.AddLogin(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
                obj = null;
            }
        }

        public Int32 UpdateLogin(Comptes obj)
        {
            LoginDAL objdal = new LoginDAL();
            try
            {
                return objdal.UpdateLogin(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
                obj = null;
            }
        }

        public Int32 UpdateLogin1(Comptes obj)
        {
            LoginDAL objdal = new LoginDAL();
            try
            {
                return objdal.UpdateLogin1(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
                obj = null;
            }
        }

        public Int32 DeleteLogin(Comptes obj)
        {
            LoginDAL objdal = new LoginDAL();
            try
            {
                return objdal.DeleteLogin(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
                obj = null;
            }
        }

        #endregion

        #region Projet
        public List<Projets> GetProjet()
        {
            ProjetsDAL objdal = new ProjetsDAL();
            try
            {
                return objdal.GetProjet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }

        public Int32 AddProjet(Projets obj)
        {
            ProjetsDAL objdal = new ProjetsDAL();
            try
            {
                return objdal.AddProjet(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        public Int32 UpdateProjet(Projets obj)
        {
            ProjetsDAL objdal = new ProjetsDAL();
            try
            {
                return objdal.UpdateProjet(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        public Int32 DeleteProjet(Projets obj)
        {
            ProjetsDAL objdal = new ProjetsDAL();
            try
            {
                return objdal.DeleteProjet(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        #endregion

        #region District
        public List<District> GetDistrict()
        {
            DistrictDAL objdal = new DistrictDAL();
            try
            {
                return objdal.GetDistrict();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }

        public Int32 AddDistrict(District obj)
        {
            DistrictDAL objdal = new DistrictDAL();
            try
            {
                return objdal.AddDistrict(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }
        #endregion

        #region Region
        public List<Region> GetRegion()
        {
            RegionDAL objdal = new RegionDAL();
            try
            {
                return objdal.GetRegion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }


        public Int32 AddRegion(Region obj)
        {
            RegionDAL objdal = new RegionDAL();
            try
            {
                return objdal.AddRegion(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }
        #endregion

        #region Avancement
        public List<Etapes> GetAvancement()
        {
            AvancementDAL objdal = new AvancementDAL();
            try
            {
                return objdal.GetAvancement();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }

        public Int32 AddAvancement(Etapes obj)
        {
            AvancementDAL objdal = new AvancementDAL();
            try
            {
                return objdal.AddEtape(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        public Int32 UpdateAvancement(Etapes obj)
        {
            AvancementDAL objdal = new AvancementDAL();
            try
            {
                return objdal.UpdateEtape(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        public Int32 DeleteAvancement(Etapes obj)
        {
            AvancementDAL objdal = new AvancementDAL();
            try
            {
                return objdal.DeleteEtape(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                objdal = null;
            }
        }

        #endregion

        #region Nouveau Compte

        public List<NouveauComptes> GetAllNouveau()
        {
            NouveauDAL objdal = new NouveauDAL();
            try
            {
                return objdal.GetAllNouveau();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }

        public Int32 AddNouveau(NouveauComptes obj)
        {
            NouveauDAL objdal = new NouveauDAL();
            try
            {
                return objdal.AddNouveau(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
                obj = null;
            }
        }

        public Int32 DeleteNouveau(NouveauComptes obj)
        {
            NouveauDAL objdal = new NouveauDAL();
            try
            {
                return objdal.DeleteNouveau(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
                obj = null;
            }
        }
        #endregion

    }
}
