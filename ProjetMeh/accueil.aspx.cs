using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using BEL;
using BLL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services;

namespace ProjetMeh
{
    public partial class accueil : System.Web.UI.Page
    {
        private AccueilBLL acc;
        private StringBuilder build;
        private StringBuilder build1;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            build1 = new StringBuilder();
            build = new StringBuilder();

            try
            {
                if (Session["pseudo"] != null)
                {
                    //build.Append(Remplir1());
                    build1.Append(Remplir());
                    //pan.Controls.Add(new Literal { Text = build.ToString() });
                    panel.Controls.Add(new Literal { Text = build1.ToString() });
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "<br/>" + ex.StackTrace);
            }
             
        }

        private string Remplir1()
        {
            acc = new AccueilBLL();
            try
            {
                string text=acc.Recap();
                //pan.Controls.Add(new Literal { Text = text });
                return text;
            }
            finally
            {
                acc = null;
            }
        }

        private string Remplir()
        {
            acc = new AccueilBLL();                
            try
            {
                string text = acc.Alert(Session["id"].ToString());
                //panel.Controls.Add(new Literal { Text = text });
                return text;
            }
            finally
            {
                acc = null;
            }
        }


    }
}