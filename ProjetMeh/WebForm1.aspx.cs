using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ProjetMeh
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            SqlConnection cnx = new SqlConnection(WebConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
            string sql = "select top 2 limit 1 * from entites";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            try
            {
            cnx.Open();
            var read=cmd.ExecuteReader();
            
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Response.Write(read["libentite"].ToString()+"<br/>");
                    }
                }
                cnx.Close();
            
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "<br/>" + ex.StackTrace);
            }*/
            
                string teste="";
                string  page=Request.Params["page"];
                
                ActionBLL action = new ActionBLL();
                List<Projets> Liste = new List<Projets>();
                List<Etapes> Listeetape = new List<Etapes>();
                Listeetape = action.GetAvancement();
                Liste = action.GetProjet();

                int limit = 10;
                int nbrpage = Liste.Count / limit;
                int debut = (nbrpage-1)*limit;
                int curpage,strrequest;
                teste += "<table border='1px'><thead><tr><th>Numéro</th><th>Titre</th><th>Sources</th><th>Observations</th></tr></thead><tbody>";
                try
                {
                    if (!string.IsNullOrEmpty(page) && int.Parse(page) <= Liste.Count)
                    {
                        strrequest = int.Parse(page);
                        curpage = (strrequest)*limit ;
                        
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
                List<Projets> tester=new List<Projets>();
                foreach (var t in Listeetape)
                {
                    tester = Liste.Where(f => f.IdProjet == t.IdProjet).ToList();
                }
                var offset = Liste.Skip(curpage).Take(10).ToList();
                var test1 = tester.Skip(curpage).Take(10).ToList();
                foreach (var lis in offset)
                {
                    teste += "<tr><td>";
                    teste += lis.Numero+"</td><td>";
                    teste += lis.Titre +"</td><td>";
                    teste += lis.Source + "</td><td>";
                    foreach (var t in Listeetape)
                    {
                        if(t.IdProjet==lis.IdProjet)
                        teste += t.Obs;
                    }
                    teste += "</td></tr>";
                    
                }
                teste += "</tbody></table><div id='eliminer'>";
                teste += "<a style='border:1px solid black;background:blue' href='WebForm1.aspx?page=" + 0 + "'>First</a>&nbsp;&nbsp;";
                if (!string.IsNullOrEmpty(page) && int.Parse(page) <= nbrpage && int.Parse(page) > 0)
                {
                    teste += "&nbsp;&nbsp;<a style='border:1px solid black;background:blue;color:white' href='WebForm1.aspx?page=" + (int.Parse(page) - 1) + "'>Previous</a>&nbsp;&nbsp;";
                }
                else
                {
                    teste += "<Label style='border:1px solid black;background:blue;color:white'>Previous</Label>&nbsp;&nbsp;";
                }

                /*
                for (int i = 0; i <= Liste.Count; i++)
                {
                    if (i<=nbrpage)
                    {
                        if (strrequest == i)
                            teste += "<label>Page" + (i+1) + "</label>";
                        else
                            teste += "<a href='WebForm1.aspx?page=" + i + "'>Page " + (i+1) + "</a>";
                    }
                }*/

                if (!string.IsNullOrEmpty(page) && int.Parse(page) < nbrpage)
                {
                    teste += "<a style='border:1px solid black;background:blue' href='WebForm1.aspx?page=" + (int.Parse(page) + 1) + "'>Next</a>&nbsp;&nbsp;";
                }
                else if (string.IsNullOrEmpty(page))
                {
                    teste += "<a style='border:1px solid black;background:blue' href='WebForm1.aspx?page=" + 1 + "'>Next</a>&nbsp;&nbsp;";
                }
                else
                {
                    teste += "<label style='border:1px solid black;background:blue'>Next</label>&nbsp;&nbsp;";
                }
                teste += "&nbsp;&nbsp;<a style='border:1px solid black;background:blue' href='WebForm1.aspx?page=" + nbrpage + "'>Last</a>";
                teste += "Page :" + (strrequest+1) + "/" + (nbrpage+1);
                //string t = Request.Params["ing"];
                //teste += " <a href='WebForm1.aspx?id=" + inh + "'>Next</a>";
                teste += "Nombre page:" + (Liste.Count / limit)+"</div>";
                test.InnerHtml = teste;
                    
        }

       
    }
}