using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;
using System.Web.Services;

namespace ProjetMeh
{
    public partial class mail : System.Web.UI.Page
    {
        private ActionBLL action;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btenvoi_Click(object sender, EventArgs e)
        {
            action = new ActionBLL();
            string txtdest = Request.Form["txtdestinataire"];
            string[] dest = txtdest.Split(',');
            string exp = txtexp.Text.ToLower();
            string mdp = txtmdp.Text;
            string obj = txtobjet.Text;
            string texte = txttexte.Text;
            //string host = txthost.Text.Trim().ToLower();
            string host = Request.Form["txth"].Trim().ToLower();
            try
            {
                for (int i = 0; i < dest.Length; i++)
                {
                    action.MessageMail(host, dest[i].ToString(), exp, obj, texte, mdp);
                }
                lblmsg.Text = "Mail envoyer avec succès!";
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
            }
            catch
            {
                lblmsg.Text = "Une erreur est survenue! ";
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "ShowDialog(true);", true);
            }
            finally
            {
                action = null;
            }
        }

        [WebMethod]
        public static string GetCorrespondant()
        {
            ActionBLL action = new ActionBLL();
            List<Correspondants> Liste = new List<Correspondants>();
            Liste = action.GetCorrespondant();
            var test = Liste.Where(f => f.EmailCor.Trim() != "");
            string text = "<datalist id='datalist'>";
            foreach (var l in test)
            {
                text += "<option>";
                text += l.EmailCor.Trim().ToLower();
                text += "</option>";
            }
            text += "</datalist>";
            return text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("mail.aspx");
        }
    }
}