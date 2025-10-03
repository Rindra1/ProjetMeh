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
    public class NouveauDAL
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;
        private string sql;

        public List<NouveauComptes> GetAllNouveau()
        {
            sql = "SELECT * FROM Nouveaux";
            List<NouveauComptes> Liste = new List<NouveauComptes>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {

                        Liste.Add(new NouveauComptes
                        {
                            _IdNouveau = read["idnouveau"] == DBNull.Value ? default(int) : int.Parse(read["IdNouveau"].ToString()),
                            _EntiteN = read["entite"] == DBNull.Value ? default(string) : read["entite"].ToString(),
                            _DirectionN = read["direction"] == DBNull.Value ? default(string) : read["direction"].ToString(),
                            _ServiceN = read["service"] == DBNull.Value ? default(string) : read["service"].ToString(),
                            _NomN = read["nom"] == DBNull.Value ? default(string) : read["nom"].ToString(),
                            _PrenomN = read["prenom"] == DBNull.Value ? default(string) : read["prenom"].ToString(),
                            _EmailN = read["email"] == DBNull.Value ? default(string) : read["email"].ToString(),
                            _TelN = read["telephone"] == DBNull.Value ? default(string) : read["telephone"].ToString(),
                            _PseudoN = read["pseudo"] == DBNull.Value ? default(string) : read["pseudo"].ToString(),
                            _CodeN = read["code"] == DBNull.Value ? default(string) : read["code"].ToString()
                        });
                        
                    }
                }
                return Liste;
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

        public Int32 AddNouveau(NouveauComptes obj)
        {
            sql = "INSERT INTO Nouveaux(entite,direction,service,nom,prenom,email" +
            ",telephone,pseudo,code)VALUES(@ent,@dir,@ser,@nom,@prenom,@mail,@tel,@pseudo,@code)";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@ent", SqlDbType.VarChar, 10).Value = obj._EntiteN;
                cmd.Parameters.Add("@dir", SqlDbType.VarChar, 50).Value = obj._DirectionN;
                if (!string.IsNullOrEmpty(obj._ServiceN))
                    cmd.Parameters.Add("@ser", SqlDbType.VarChar, 50).Value = obj._ServiceN;
                else
                    cmd.Parameters.Add("@ser", SqlDbType.VarChar, 50).Value = SqlString.Null;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 50).Value = obj._NomN;
                cmd.Parameters.Add("@prenom", SqlDbType.VarChar, 50).Value = obj._PrenomN;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 50).Value = obj._EmailN;
                cmd.Parameters.Add("@tel", SqlDbType.VarChar, 15).Value = obj._TelN;
                cmd.Parameters.Add("@pseudo", SqlDbType.VarChar, 50).Value = obj._PseudoN;
                cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = obj._CodeN;
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int resultat = Convert.ToInt32(cmd.ExecuteNonQuery());
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

        public Int32 DeleteNouveau(NouveauComptes obj)
        {
            sql = "DELETE FROM Nouveaux WHERE IdNouveau=@id";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 10).Value = obj._IdNouveau;
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int resultat = Convert.ToInt32(cmd.ExecuteNonQuery());
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
