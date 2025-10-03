using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using BEL;


namespace DAL
{
    public class EntiteDAL
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;
        private string sql;

        public List<Entites> GetEntite()
        {
            sql = "SELECT * FROM Entites";
            List<Entites> Liste = new List<Entites>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Liste.Add(new Entites
                        {
                            IdEntite = Convert.ToInt32(read["identite"].ToString()),
                            LibEntite = read["libentite"].ToString(),
                        });
                    }
                }
                cnx.Close();
                return Liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
