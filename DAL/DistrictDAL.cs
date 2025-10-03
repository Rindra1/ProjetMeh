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
    public class DistrictDAL
    {
        private string sql;
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;

        public List<District> GetDistrict()
        {
            sql = "SELECT * FROM District";
            List<District> Liste = new List<District>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Liste.Add(new District
                        {
                            IdDistrict=read["iddistrict"]==DBNull.Value?default(int):int.Parse(read["iddistrict"].ToString()),
                            IdProjet = read["idprojet"] == DBNull.Value ? default(int) : int.Parse(read["idprojet"].ToString()),
                            LibDistrict = read["libdistrict"] == DBNull.Value ? default(string) : read["libdistrict"].ToString(),
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


        public Int32 AddDistrict(District obj)
        {
            sql = "INSERT INTO District(IdProjet,libdistrict)" +
                "VALUES(@idp,@lib);select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@idp", SqlDbType.Int).Value = obj.IdProjet;
                cmd.Parameters.Add("@lib", SqlDbType.NVarChar, 250).Value = obj.LibDistrict;
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int resultat = Convert.ToInt32(cmd.ExecuteScalar());
                return resultat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
            }
        }
    }
}
