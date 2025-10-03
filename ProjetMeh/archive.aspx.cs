using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ProjetMeh
{
    public partial class archive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"]!=null)
                RemplirTableau();
        }

        public void RemplirTableau()
        {
            AccueilBLL acc = new AccueilBLL();
            string[] page1;
            string page = Request.Params["page"];
            string test = "";

            try
            {
                page1 = page.Split(',');
                foreach (var t in page1)
                {
                    test = t;
                }
            }
            catch
            {
                test = "";
            }
            string texte = acc.Archive(page, Session["id"].ToString(), Session["role"].ToString().ToUpper().Trim(), Session["iddir"].ToString());
            string[] split = texte.Split('*');
            string text = Convert.ToString(split[0]);
            string text1 = Convert.ToString(split[1]);
            lblarchive.Controls.Add(new Literal { Text = text });
        }
    }
}