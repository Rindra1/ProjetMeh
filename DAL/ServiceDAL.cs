using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using BEL;

namespace DAL
{
    public class ServiceDAL
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;
        private string sql;

        public List<Services> GetService()
        {
            sql = "SELECT * FROM Services";
            List<Services> Liste = new List<Services>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Liste.Add(new Services
                        {
                            IdService=read["idservice"]==DBNull.Value?default(int):int.Parse(read["idservice"].ToString()),
                            IdDir = read["iddir"] == DBNull.Value ? default(int) : int.Parse(read["iddir"].ToString()),
                            LibService = read["libservice"] == DBNull.Value ? default(string) : read["libservice"].ToString(),
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

        public Int32 AddService(Services obj)
        {
            sql = "INSERT INTO services(iddir,libservice)" +
                "VALUES(@idd,@lib);select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@idd", SqlDbType.Int).Value = obj.IdDir;
                cmd.Parameters.Add("@lib", SqlDbType.NVarChar,50).Value = obj.LibService;               
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

        public Int32 UpdateService(Services obj)
        {
            sql = "UPDATE services SET iddir=@idd,libservice=@lib " +
                " WHERE idservice=@id";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdService;
                cmd.Parameters.Add("@idd", SqlDbType.Int).Value = obj.IdDir;
                cmd.Parameters.Add("@lib", SqlDbType.NVarChar, 50).Value = obj.LibService;
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int resultat = cmd.ExecuteNonQuery();
                if (resultat > 0)
                    return resultat;
                else
                    return 0;
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

        public Int32 DeleteService(Services obj)
        {
            sql = "DELETE FROM services  " +
                " WHERE idservice=@id";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdService;
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int resultat = cmd.ExecuteNonQuery();
                if (resultat > 0)
                    return resultat;
                else
                    return 0;
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
