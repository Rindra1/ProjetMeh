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
    public class DirectionsDAL
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;
        private string sql;
        

        public List<Directions> GetDirection()
        {
            sql = "SELECT * FROM Directions";
            List<Directions> Liste = new List<Directions>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Liste.Add(new Directions
                        {
                            IdDir = read["iddir"] == DBNull.Value ? default(int) : int.Parse(read["iddir"].ToString()),
                            IdEntite = read["identite"] == DBNull.Value ? default(int) : int.Parse(read["identite"].ToString()),
                            LibDir = read["libdir"] == DBNull.Value ? default(string) : read["libdir"].ToString(),
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

        public Int32 AddDirection(Directions obj)
        {
            sql = "INSERT INTO Directions(identite,libdir)"+
                "VALUES(@ide,@lib);select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@ide", SqlDbType.Int).Value = obj.IdEntite;
                cmd.Parameters.Add("@lib", SqlDbType.NVarChar, 50).Value = obj.LibDir;
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

        public Int32 UpdateDirection(Directions obj)
        {
            sql = "UPDATE Directions SET identite=@ide,libdir=@lib WHERE iddir=@idd";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@idd", SqlDbType.Int).Value = obj.IdDir;
                cmd.Parameters.Add("@ide", SqlDbType.Int).Value = obj.IdEntite;
                cmd.Parameters.Add("@lib", SqlDbType.NVarChar, 50).Value = obj.LibDir;
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

        public Int32 DeleteDirection(Directions obj)
        {
            sql = "DELETE FROM Directions WHERE iddir=@idd";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@idd", SqlDbType.Int).Value = obj.IdDir;
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
