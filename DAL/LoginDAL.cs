using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BEL;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace DAL
{
    public class LoginDAL
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;
        private string sql;
        public List<Comptes> GetLogins()
        {
            sql = "SELECT * FROM Login";
            List<Comptes> Liste = new List<Comptes>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        
                        Liste.Add(new Comptes
                        {
                            IdLogin = read["idlogin"] == DBNull.Value ? default(int) : int.Parse(read["idlogin"].ToString()),
                            IdCor = read["idcor"] == DBNull.Value ? default(int) : int.Parse(read["idcor"].ToString()),
                            Pseudo = read["pseudo"] == DBNull.Value ? default(string) : read["pseudo"].ToString(),
                            Code = read["code"] == DBNull.Value ? default(string) : read["code"].ToString(),
                            Role = read["librole"] == DBNull.Value ? default(string) : read["librole"].ToString(),
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


        public Int32 AddLogin(Comptes obj)
        {
            sql = "INSERT INTO Login(IdCor,Pseudo,Code,LibRole)" +
                "VALUES(@id,@p,@c,@l);select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdCor;
                cmd.Parameters.Add("@p", SqlDbType.NVarChar, 250).Value = obj.Pseudo;
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 250).Value = obj.Code;
                cmd.Parameters.Add("@l", SqlDbType.NVarChar, 25).Value = obj.Role;

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

        public Int32 UpdateLogin(Comptes obj)
        {
            sql = "Update Login SET IdCor=@id,Pseudo=@p,Code=@c,LibRole=@l " +
                " WHERE IdLogin=@i";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@i", SqlDbType.Int).Value = obj.IdLogin;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdCor;
                cmd.Parameters.Add("@p", SqlDbType.NVarChar, 250).Value = obj.Pseudo;
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 250).Value = obj.Code;
                cmd.Parameters.Add("@l", SqlDbType.NVarChar, 25).Value = obj.Role;

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

        public Int32 UpdateLogin1(Comptes obj)
        {
            sql = "Update Login SET Pseudo=@p,Code=@c " +
                " WHERE IdLogin=@i";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@i", SqlDbType.Int).Value = obj.IdLogin;
                cmd.Parameters.Add("@p", SqlDbType.NVarChar, 250).Value = obj.Pseudo;
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 250).Value = obj.Code;
                
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

        public Int32 DeleteLogin(Comptes obj)
        {
            sql = "DELETE FROM Login " +
                " WHERE IdLogin=@i";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@i", SqlDbType.Int).Value = obj.IdLogin;
                
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
