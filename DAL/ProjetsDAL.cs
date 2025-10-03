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
    public class ProjetsDAL
    {
        private string sql;
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;

        public List<Projets> GetProjet()
        {
            sql = "SELECT * FROM Projets ";
            List<Projets> Liste = new List<Projets>();
            try
            {
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Projets p = new Projets();
                        if (string.IsNullOrEmpty(read["IdEnr"].ToString()))
                            p.IdEnr = 0;
                        else
                            p.IdEnr = int.Parse(read["idenr"].ToString());
                        if (string.IsNullOrEmpty(read["source"].ToString()))
                        {
                            p.Source = "";
                        }
                        else
                        {
                            p.Source = read["source"].ToString();
                        }

                        if (string.IsNullOrEmpty(read["capacite"].ToString()))
                            p.Capacite = "";
                        else
                            p.Capacite = read["capacite"].ToString();
                        
                        if (string.IsNullOrEmpty(read["numero"].ToString()))
                            p.Numero = "";
                        else
                            p.Numero = read["numero"].ToString();
                        
                        if (string.IsNullOrEmpty(read["promoteur"].ToString()))
                            p.Promoteur = "";
                        else
                            p.Promoteur = read["promoteur"].ToString();
                        
                        if (string.IsNullOrEmpty(read["type"].ToString()))
                            p.Type = "";
                        else
                            p.Type = read["type"].ToString();
                        
                        if (string.IsNullOrEmpty(read["titre"].ToString()))
                            p.Titre = "";
                        else
                            p.Titre = read["titre"].ToString();
                        if (string.IsNullOrEmpty(read["test"].ToString()))
                            p.Test = "";
                        else
                            p.Test = read["test"].ToString();
                        
                        p.IdCor = int.Parse(read["idcor"].ToString());
                        p.IdProjet = int.Parse(read["idprojet"].ToString());
                        
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

        public Int32 AddProjet(Projets obj)
        {
            try
            {

                sql = "INSERT INTO Projets(idenr,idcor,numero,titre,promoteur,source,type,capacite,test)" +
                    "VALUES(@ide,@idc,@num,@titre,@promoteur,@source,@type,@cap,@test);select @@identity";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@ide", SqlDbType.Int).Value = obj.IdEnr;
                cmd.Parameters.Add("@idc", SqlDbType.Int).Value = obj.IdCor;
                if(!string.IsNullOrEmpty(obj.Numero))
                    cmd.Parameters.Add("@num", SqlDbType.NVarChar, 50).Value = obj.Numero;
                else
                    cmd.Parameters.Add("@num", SqlDbType.NVarChar, 50).Value = SqlString.Null;
                if (!string.IsNullOrEmpty(obj.Titre))
                    cmd.Parameters.Add("@titre", SqlDbType.NVarChar, 250).Value = obj.Titre;
                else
                    cmd.Parameters.Add("@titre", SqlDbType.NVarChar, 250).Value = SqlString.Null;
                if(!string.IsNullOrEmpty(obj.Promoteur))
                    cmd.Parameters.Add("@promoteur", SqlDbType.NVarChar, 250).Value = obj.Promoteur;
                else
                    cmd.Parameters.Add("@promoteur", SqlDbType.NVarChar, 250).Value = SqlString.Null;

                if(!string.IsNullOrEmpty(obj.Source))
                    cmd.Parameters.Add("@source", SqlDbType.NVarChar, 250).Value = obj.Source;
                else
                    cmd.Parameters.Add("@source", SqlDbType.NVarChar, 250).Value = SqlString.Null;

                if (!string.IsNullOrEmpty(obj.Type))
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar, 250).Value = obj.Type;
                else
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar, 250).Value = SqlString.Null;

                if (!string.IsNullOrEmpty(obj.Capacite))
                    cmd.Parameters.Add("@cap", SqlDbType.NText).Value = obj.Capacite;
                else
                    cmd.Parameters.Add("@cap", SqlDbType.NText).Value = SqlString.Null;

                cmd.Parameters.Add("@test", SqlDbType.NChar, 10).Value = "nouveau";



                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int idprojet = Convert.ToInt32(cmd.ExecuteScalar());
                return idprojet;




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

        public Int32 UpdateProjet(Projets obj)
        {
            try
            {

                sql = "UPDATE Projets SET idcor=@idc,numero=@num,titre=@titre" +
                ",promoteur=@promoteur,source=@source,type=@type " +
                    " WHERE idprojet=@id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdProjet;
                cmd.Parameters.Add("@idc", SqlDbType.Int).Value = obj.IdCor;
                cmd.Parameters.Add("@num", SqlDbType.NVarChar, 50).Value = obj.Numero;
                cmd.Parameters.Add("@titre", SqlDbType.NVarChar, 250).Value = obj.Titre;
                cmd.Parameters.Add("@promoteur", SqlDbType.NVarChar, 250).Value = obj.Promoteur;
                cmd.Parameters.Add("@source", SqlDbType.NVarChar, 250).Value = obj.Source;
                cmd.Parameters.Add("@type", SqlDbType.NVarChar, 250).Value = obj.Type;
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int idprojet = cmd.ExecuteNonQuery();
                if (idprojet > 0)
                    return idprojet;
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

        public int DeleteProjet(Projets obj)
        {
            string sql = "Update Projets set Test=@test where idprojet=@id";
            try
            {

                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdProjet;
                cmd.Parameters.Add("@test", SqlDbType.NChar,10).Value = "archive";
                if (cnx.State != ConnectionState.Open)
                    cnx.Open();
                int idprojet = cmd.ExecuteNonQuery();
                if (idprojet > 0)
                    return idprojet;
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
