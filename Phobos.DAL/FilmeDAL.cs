using MySql.Data.MySqlClient;
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.DAL
{
    public class FilmeDAL:Conexao
    {
        //CRUD

        //Create
        public void Cadastrar(FilmeDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO Filme (Titulo,Genero,Produtora,UrlImg,FilmeClassif) VALUES (@Titulo,@Genero,@Produtora,@UrlImg,@FilmeClassif)", conn);
                cmd.Parameters.AddWithValue("@Titulo", objCad.Titulo);
                cmd.Parameters.AddWithValue("@Genero", objCad.Genero);
                cmd.Parameters.AddWithValue("@Produtora", objCad.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objCad.UrlImg);
                cmd.Parameters.AddWithValue("@FilmeClassif", objCad.FilmeClassif);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //Read
        public List<FilmeListDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Titulo, Genero, Produtora, UrlImg, Descricao FROM Filme INNER JOIN Classificacao ON Filme.FilmeClassif = Classificacao.Id", conn);
                dr = cmd.ExecuteReader();
                //ponteiro - lista vazia
                List<FilmeListDTO> Lista = new List<FilmeListDTO>();
                while (dr.Read())
                {
                    FilmeListDTO obj = new FilmeListDTO();
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Genero = dr["Genero"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Descricao = dr["Descricao"].ToString();

                    //adiciar a lista
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar registros !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Update
        public void Editar(FilmeDTO objEdit)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE Filme SET Titulo = @Titulo, Genero = @Genero, Produtora = @Produtora, UrlImg = @UrlImg, FilmeClassif = @FilmeClassif WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Titulo", objEdit.Titulo);
                cmd.Parameters.AddWithValue("@Genero", objEdit.Genero);
                cmd.Parameters.AddWithValue("@Produtora", objEdit.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objEdit.UrlImg);
                cmd.Parameters.AddWithValue("@FilmeClassif", objEdit.FilmeClassif);
                cmd.Parameters.AddWithValue("@Id", objEdit.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar Filme !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void Excluir(int objDel)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM Filme WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", objDel);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao eliminar registro !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }


        //BuscarPorId
        public FilmeDTO BuscaPorId(int Id)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Filme WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Genero = dr["Genero"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.FilmeClassif = dr["FilmeClassif"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar registro !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar Admin
        public List<FilmeDTO> ListarAdmin()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Filme.Id,Titulo, Genero, Produtora, UrlImg, Descricao FROM Filme INNER JOIN Classificacao ON Filme.FilmeClassif = Classificacao.Id", conn);
                dr = cmd.ExecuteReader();
                //ponteiro - lista vazia
                List<FilmeDTO> Lista = new List<FilmeDTO>();
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Genero = dr["Genero"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.FilmeClassif = dr["Descricao"].ToString();

                    //adiciar a lista
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar registros !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


    }
}
