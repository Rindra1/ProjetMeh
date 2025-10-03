using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ProjetMeh
{
    public partial class impression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string text = "";
            if (!Page.IsPostBack)
            {
                text = Remplir();
                lblimp.Controls.Add(new Literal { Text = text });
                Session["remplir"] = text;
            }
            else
            {
                text = Session["remplir"].ToString();
                lblimp.Controls.Add(new Literal { Text = text });                
            }
        }

        private string Remplir()
        {
            AccueilBLL acc = new AccueilBLL();
               
            try
            {
                string text = "";
                string id = Request.Params["id"];
                if (string.IsNullOrEmpty(id))
                    text = acc.Impression();
                else
                    text += acc.Impression1(id);
                return text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                acc = null;
            }
        }
    }
}