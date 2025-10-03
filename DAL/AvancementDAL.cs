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
    public class AvancementDAL
    {
        private string sql;
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;

        public List<Etapes> GetAvancement()
        {
            sql = "select idetape,idprojet,libetape, debut," +
                "fin," +
            "urgence,obs,contrainte,solution,etat,situation from avancements order by idprojet asc";
            List<Etapes> Liste = new List<Etapes>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Etapes p = new Etapes();
                        p.IdProjet = int.Parse(read["idprojet"].ToString());
                        p.IdEtape = int.Parse(read["idetape"].ToString());
                        
                        if (string.IsNullOrEmpty(read["libetape"].ToString()))
                            p.LibEtape = "";
                        else
                            p.LibEtape = read["libetape"].ToString();

                        if (string.IsNullOrEmpty(read["urgence"].ToString()))
                            p.Urgence = "";
                        else
                            p.Urgence = read["urgence"].ToString();

                        if (string.IsNullOrEmpty(read["Obs"].ToString()))
                            p.Obs = "";
                        else
                            p.Obs = read["Obs"].ToString();

                        if (string.IsNullOrEmpty(read["Contrainte"].ToString()))
                            p.Contrainte = "";
                        else
                            p.Contrainte = read["contrainte"].ToString();

                        if (string.IsNullOrEmpty(read["solution"].ToString()))
                            p.Solution = "";
                        else
                            p.Solution = read["solution"].ToString();

                        if (string.IsNullOrEmpty(read["etat"].ToString()))
                            p.Etat = "";
                        else
                            p.Etat = read["etat"].ToString();

                        if (string.IsNullOrEmpty(read["debut"].ToString()))
                            p.Debut = "31/12/2016";
                        else
                            p.Debut = read["debut"].ToString();

                        if (string.IsNullOrEmpty(read["fin"].ToString()))
                            p.Fin = "31/12/2016";
                        else
                            p.Fin = read["fin"].ToString();

                        if (string.IsNullOrEmpty(read["situation"].ToString()))
                            p.Situation = "";
                        else
                            p.Situation = read["situation"].ToString();

                        /*
                        Liste.Add(new Etapes
                        {
                            
                            IdEtape = read["idetape"] == DBNull.Value ? default(int) : int.Parse(read["idetape"].ToString()),
                            IdProjet = read["idprojet"] == DBNull.Value ? default(int) : int.Parse(read["idprojet"].ToString()),
                            LibEtape = read["libetape"] == DBNull.Value ? default(string) : read["libetape"].ToString(),
                            Urgence = read["urgence"] == DBNull.Value ? default(string) : read["urgence"].ToString(),
                            Obs = read["obs"] == DBNull.Value ? default(string) : read["obs"].ToString(),
                            Contrainte = read["contrainte"] == DBNull.Value ? default(string) : read["contrainte"].ToString(),
                            Solution = read["solution"] == DBNull.Value ? default(string) : read["solution"].ToString(),
                            Etat = read["etat"] == DBNull.Value ? default(string) : read["etat"].ToString(),
                            Debut = read["debut"] == DBNull.Value ? default(string) : read["debut"].ToString(),
                            Fin = read["fin"] == DBNull.Value ? default(string) : read["fin"].ToString(),

                        });
                         */
                        Liste.Add(p);
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



        public Int32 AddEtape(Etapes obj)
        {
            sql = "INSERT INTO Avancements(idprojet,situation,libetape,urgence,obs,solution,contrainte,etat,debut,fin)" +
                "VALUES(@idp,@situation,@lib,@urgence,@obs,@sol,@con,@etat,@debut,@fin);select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@idp", SqlDbType.Int).Value = obj.IdProjet;
                if (!string.IsNullOrEmpty(obj.LibEtape))
                    cmd.Parameters.Add("@lib", SqlDbType.NText).Value = obj.LibEtape;
                else
                    cmd.Parameters.Add("@lib", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Situation))
                    cmd.Parameters.Add("@situation", SqlDbType.NText).Value = obj.Situation;
                else
                    cmd.Parameters.Add("@situation", SqlDbType.NText).Value = SqlString.Null;
                cmd.Parameters.Add("@urgence", SqlDbType.NVarChar, 50).Value = obj.Urgence;
                if (!string.IsNullOrEmpty(obj.Obs))
                    cmd.Parameters.Add("@obs", SqlDbType.NText).Value = obj.Obs;
                else
                    cmd.Parameters.Add("@obs", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Solution))
                    cmd.Parameters.Add("@sol", SqlDbType.NText).Value = obj.Solution;
                else
                    cmd.Parameters.Add("@sol", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Contrainte))
                    cmd.Parameters.Add("@con", SqlDbType.NText).Value = obj.Contrainte;
                else
                    cmd.Parameters.Add("@con", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Etat))
                    cmd.Parameters.Add("@etat", SqlDbType.NText).Value = obj.Etat;
                else
                    cmd.Parameters.Add("@etat", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(Convert.ToString(obj.Debut)))
                    cmd.Parameters.Add("@debut", SqlDbType.Date).Value = Convert.ToDateTime(obj.Debut);
                else
                    cmd.Parameters.Add("@debut", SqlDbType.Date).Value = SqlDateTime.Null;
                if (!string.IsNullOrEmpty(Convert.ToString(obj.Fin)))
                    cmd.Parameters.Add("@fin", SqlDbType.Date).Value =Convert.ToDateTime(obj.Fin);
                else
                    cmd.Parameters.Add("@fin", SqlDbType.Date).Value = SqlDateTime.Null;


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

        public Int32 UpdateEtape(Etapes obj)
        {
            sql = "UPDATE Avancements SET libetape=@lib,situation=@situation,urgence=@urgence"+
            ",obs=@obs,solution=@sol,contrainte=@con,etat=@etat,debut=@debut,fin=@fin " +
                " WHERE idetape=@id;select @@identity";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdEtape;
                if (!string.IsNullOrEmpty(obj.LibEtape))
                    cmd.Parameters.Add("@lib", SqlDbType.NText).Value = obj.LibEtape;
                else
                    cmd.Parameters.Add("@lib", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Situation))
                    cmd.Parameters.Add("@situation", SqlDbType.NText).Value = obj.Situation;
                else
                    cmd.Parameters.Add("@situation", SqlDbType.NText).Value = SqlString.Null;
                cmd.Parameters.Add("@urgence", SqlDbType.NVarChar, 50).Value = obj.Urgence;
                if (!string.IsNullOrEmpty(obj.Obs))
                    cmd.Parameters.Add("@obs", SqlDbType.NText).Value = obj.Obs;
                else
                    cmd.Parameters.Add("@obs", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Solution))
                    cmd.Parameters.Add("@sol", SqlDbType.NText).Value = obj.Solution;
                else
                    cmd.Parameters.Add("@sol", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Contrainte))
                    cmd.Parameters.Add("@con", SqlDbType.NText).Value = obj.Contrainte;
                else
                    cmd.Parameters.Add("@con", SqlDbType.NText).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Etat))
                    cmd.Parameters.Add("@etat", SqlDbType.NText).Value = obj.Etat;
                else
                    cmd.Parameters.Add("@etat", SqlDbType.NText).Value = SqlString.Null;

                if (!string.IsNullOrEmpty(Convert.ToString(obj.Debut)))
                    cmd.Parameters.Add("@debut", SqlDbType.Date).Value = Convert.ToDateTime(obj.Debut);
                else
                    cmd.Parameters.Add("@debut", SqlDbType.Date).Value = SqlDateTime.Null;
                if (!string.IsNullOrEmpty(Convert.ToString(obj.Fin)))
                    cmd.Parameters.Add("@fin", SqlDbType.Date).Value = Convert.ToDateTime(obj.Fin);
                else
                    cmd.Parameters.Add("@fin", SqlDbType.Date).Value = SqlDateTime.Null;


                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int resultat = Convert.ToInt32(cmd.ExecuteNonQuery());
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

        public Int32 DeleteEtape(Etapes obj)
        {
            sql = "Delete from Avancements WHERE idprojet=@id";
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdProjet;
                
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
