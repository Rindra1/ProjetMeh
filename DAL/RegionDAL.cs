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
    public class RegionDAL
    {
        private string sql;
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;

        public List<Region> GetRegion()
        {
            sql = "SELECT * FROM Region";
            List<Region> Liste = new List<Region>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Liste.Add(new Region
                        {
                            IdProjet=read["idprojet"]==DBNull.Value?default(int):int.Parse(read["idprojet"].ToString()),
                            IdRegion = read["idregion"] == DBNull.Value ? default(int) : int.Parse(read["idregion"].ToString()),
                            LibRegion = read["libregion"] == DBNull.Value ? default(string) : read["libregion"].ToString()
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


        public Int32 AddRegion(Region obj)
        {
            sql = "INSERT INTO Region(IdProjet,libregion)" +
                "VALUES(@idp,@lib);select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@idp", SqlDbType.Int).Value = obj.IdProjet;
                cmd.Parameters.Add("@lib", SqlDbType.NVarChar, 250).Value = obj.LibRegion;
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

        public Int32 UpdateRegion(Region obj)
        {
            sql = "UPDATE Region(IdProjet,libregion)" +
                "VALUES(@idp,@lib);select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@idp", SqlDbType.Int).Value = obj.IdProjet;
                cmd.Parameters.Add("@lib", SqlDbType.NVarChar, 250).Value = obj.LibRegion;
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
