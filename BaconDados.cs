using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    public class BaconDados
    {
        SqlConnection cn;
        SqlCommand comandos;
        SqlDataReader reader;

        public bool Create(Categoria cat)
        {
            bool rt = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "insert into Categorias(titulo)values(@catT";
                comandos.Parameters.AddWithValue("@catT", cat.Titulo);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rt = true;
                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar Cadastrar. \n" + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado. \n" + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return rt;
        }
        public List<Categoria> Retrieve(int id)
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categorias WHERE idCategoria = @catId";
                comandos.Parameters.AddWithValue("@catId", id);

                reader = comandos.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = reader.GetInt32(0),
                        Titulo = reader.GetString(1)
                    });
                }
                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar consultar. \n" + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado. \n" + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return lista;
        }
        public List<Categoria> Retrieve(string titulo)
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categorias WHERE LIkE @catT";
                comandos.Parameters.AddWithValue("@catT", titulo);

                reader = comandos.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = reader.GetInt32(0),
                        Titulo = reader.GetString(1)
                    });
                }
                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar consultar. \n" + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado. \n" + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return lista;
        }
        public bool Update(Categoria cat)
        {
            bool rt = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "UPDATE Categorias SET titulo = @catT where idcategoria=@catId";
                comandos.Parameters.AddWithValue("@catT", cat.Titulo);
                comandos.Parameters.AddWithValue("@catId", cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rt = true;
                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar Atualizar. \n" + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado. \n" + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return rt;
        }

        public bool Del(Categoria cat)
        {
            bool rt = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "DELETE FROM Categorias WHERE idcategoria=@catId";
                comandos.Parameters.AddWithValue("@catId", cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rt = true;
                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar Excluir. \n" + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado. \n" + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return rt;
        }

    }
}