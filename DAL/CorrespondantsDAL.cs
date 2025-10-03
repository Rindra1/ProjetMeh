using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

using BEL;

namespace DAL
{
    public class CorrespondantsDAL
    {
        private SqlConnection cnx=new SqlConnection(ConfigurationManager.ConnectionStrings["Projet"].ConnectionString);
        private SqlCommand cmd;
        private string sql;

        


        public List<Correspondants> GetCorrespondant()
        {
            List<Correspondants> Liste = new List<Correspondants>();
            try
            {
                sql = "SELECT * FROM Correspondants";
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                var read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Correspondants cor = new Correspondants();
                        if (string.IsNullOrEmpty(read["iddir"].ToString()))
                            cor.IdDir = 0;
                        else
                            cor.IdDir = int.Parse(read["iddir"].ToString());

                        if (string.IsNullOrEmpty(read["idservice"].ToString()))
                            cor.IdService = 0;
                        else
                            cor.IdService = int.Parse(read["idservice"].ToString());

                        if (string.IsNullOrEmpty(read["NomCor"].ToString()))
                            cor.NomCor = "";
                        else
                            cor.NomCor = read["Nomcor"].ToString();

                        if (string.IsNullOrEmpty(read["PrenomCor"].ToString()))
                            cor.PrenomCor = "";
                        else
                            cor.PrenomCor = read["Prenomcor"].ToString();

                        if (string.IsNullOrEmpty(read["emailcor"].ToString()))
                            cor.EmailCor = "";
                        else
                            cor.EmailCor = read["emailcor"].ToString();

                        if (string.IsNullOrEmpty(read["telcor"].ToString()))
                            cor.TelCor = "";
                        else
                            cor.TelCor = read["telcor"].ToString();
                        if (!string.IsNullOrEmpty(read["idcor"].ToString()))
                            cor.IdCor = int.Parse(read["Idcor"].ToString());
                        else
                            cor.IdCor = 0;
                        Liste.Add(cor);
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

        public Int32 AddCorrespondant(Correspondants obj)
        {
            try
            {
                sql = "INSERT INTO Correspondants(iddir,idservice,nomcor,prenomcor,telcor,emailcor)" +
                    "VALUES(@idd,@ids,@nom,@prenom,@tel,@mail);select @@identity";
                cmd = new SqlCommand(sql, cnx);
                if (obj.IdDir != 0)
                    cmd.Parameters.Add("@idd", SqlDbType.Int).Value = obj.IdDir;
                else
                    cmd.Parameters.Add("@idd", SqlDbType.Int).Value = SqlInt32.Null;

                if (obj.IdService !=0 )
                    cmd.Parameters.Add("@ids", SqlDbType.Int).Value = obj.IdService;
                else
                    cmd.Parameters.Add("@ids", SqlDbType.Int).Value = SqlInt32.Null;

                cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 50).Value = obj.NomCor;
                cmd.Parameters.Add("@prenom", SqlDbType.NVarChar, 50).Value = obj.PrenomCor;
                cmd.Parameters.Add("@tel", SqlDbType.NVarChar, 20).Value = obj.TelCor;
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar, 50).Value = obj.EmailCor;

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

        public Int32 UpdateCorrespondant(Correspondants obj)
        {
            try
            {
                sql = "UPDATE Correspondants SET iddir=@idd,idservice=@ids," +
                    "nomcor=@nom,prenomcor=@prenom,telcor=@tel,emailcor=@mail " +
                    " WHERE idcor=@id;select @@identity";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdCor;
                if (obj.IdDir!=0)
                    cmd.Parameters.Add("@idd", SqlDbType.Int).Value = obj.IdDir;
                else
                    cmd.Parameters.Add("@idd", SqlDbType.Int).Value = SqlInt32.Null;

                if (obj.IdService!=0)
                    cmd.Parameters.Add("@ids", SqlDbType.Int).Value = obj.IdService;
                else
                    cmd.Parameters.Add("@ids", SqlDbType.Int).Value = SqlInt32.Null;
                cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 50).Value = obj.NomCor;
                cmd.Parameters.Add("@prenom", SqlDbType.NVarChar, 50).Value = obj.PrenomCor;
                cmd.Parameters.Add("@tel", SqlDbType.NVarChar, 20).Value = obj.TelCor;
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar, 50).Value = obj.EmailCor;

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

        public Int32 DeleteCorrespondant(Correspondants obj)
        {
            try
            {
                sql = "DELETE FROM Correspondants where idcor=@id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdCor;
                
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
