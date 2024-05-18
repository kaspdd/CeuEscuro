using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{
    public class FilmDAL : Conexao
    {

        //CRUD
        //Create
        public void Create(FilmDTO filme)
        {
            try
            {
                Conectar();
                //Comando para executar uma query do banco pelo c#, caso o comando abaixo serve para inserir novos usuarios.
                cmd = new SqlCommand("INSERT INTO Film (TituloFilm,ProdutoraFilm,UrlImgFilm,Classifcacao_Id,Genero_Id) VALUES (@TituloFilm,@ProdutoraFilm,@UrlImgFilm,@Classifcacao_Id,@Genero_Id);", conn);

                //O comando abaixo serve para vincular cada campo do banco com os parametros do usuarioDTO (usuario modelo).
                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classifcacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                //Comando para executar a query no banco!
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }
        //read
        public List<FilmDTO> GetFilms()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilm, TituloFilm, ProdutoraFilm, UrlImgFilm, DescricaoClassificacao , DescricaoGenero  FROM Film INNER JOIN Classificacao ON Classifcacao_Id = IdCLassificacao INNER JOIN Genero ON Genero_Id = IdGenero;", conn);

                //chamando a variavel dr do tipo de leitura do banco para armazenar os dados do camando acima.
                dr = cmd.ExecuteReader();

                List<FilmDTO> lista = new List<FilmDTO>();

                //Enquanto o dr continuar lendo os dados do banco
                while (dr.Read())
                {
                    //ele vai adicionar os dados da tabela nos parametros do usuarioDTO
                    FilmDTO filme = new FilmDTO();
                    filme.idFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = Convert.ToString(dr["TituloFilm"]);
                    filme.ProdutoraFilm = Convert.ToString(dr["ProdutoraFilm"]);
                    filme.UrlImgFilm = Convert.ToString(dr["UrlImgFilm"]);
                    filme.Classificacao_Id = Convert.ToString(dr["DescricaoClassificacao"]);
                    filme.Genero_Id = Convert.ToString(dr["DescricaoGenero"]);
                    //no final ele vai adicionar tudo na lista
                    lista.Add(filme);
                }


                //e retornar a lista.
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }
        //update
        public void Update(FilmDTO filme)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("UPDATE Film SET TituloFilm = @TituloFilm, ProdutoraFilm = @ProdutoraFilm,UrlImgFilm = @UrlImgFilm, Classifcacao_Id = @Classifcacao_Id, Genero_Id = @Genero_Id WHERE IdFilm = @IdFilm;", conn);


                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classifcacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                cmd.Parameters.AddWithValue("@IdFilm", filme.idFilm);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }
        //delete
        public void Delete(int idFilme)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("DELETE FROM Film WHERE IdFilm = @IdFilm;", conn);

                cmd.Parameters.AddWithValue("@IdFilm", idFilme);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }
        //Search by id
        public FilmDTO SearchByID(int filmeId)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("SELECT * FROM Film WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", filmeId);
                dr = cmd.ExecuteReader();
                FilmDTO filme = new FilmDTO();
                if (dr.Read())
                {
                    filme = new FilmDTO();
                    filme.idFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = Convert.ToString(dr["TituloFilm"]);
                    filme.ProdutoraFilm = Convert.ToString(dr["ProdutoraFilm"]);
                    filme.UrlImgFilm = Convert.ToString(dr["UrlImgFilm"]);
                    filme.Classificacao_Id = Convert.ToString(dr["Classifcacao_Id"]);
                    filme.Genero_Id = Convert.ToString(dr["Genero_Id"]);
                }

                return filme;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Search by name
        public FilmDTO SearchByName(string filmeTitulo)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("SELECT * FROM Film WHERE TituloFilm = @TituloFilm;", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", filmeTitulo);
                dr = cmd.ExecuteReader();
                FilmDTO filme = new FilmDTO();
                if (dr.Read())
                {
                    filme = new FilmDTO();
                    filme.idFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = Convert.ToString(dr["TituloFilm"]);
                    filme.ProdutoraFilm = Convert.ToString(dr["ProdutoraFilm"]);
                    filme.UrlImgFilm = Convert.ToString(dr["UrlImgFilm"]);
                    filme.Classificacao_Id = Convert.ToString(dr["Classifcacao_Id"]);
                    filme.Genero_Id = Convert.ToString(dr["Genero_Id"]);
                }

                return filme;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        // filtro
        public List<FilmDTO> Filter(string generoFilme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilm, TituloFilm, ProdutoraFilm, UrlImgFilm, DescricaoClassificacao , DescricaoGenero  FROM Film INNER JOIN Classificacao ON Classifcacao_Id = IdCLassificacao INNER JOIN Genero ON Genero_Id = IdGenero WHERE DescricaoGenero = @DescricaoGenero;", conn);
                //atribuindo o compo DescricaoGenero ao parametro generoFilme.
                cmd.Parameters.AddWithValue("@DescricaoGenero", generoFilme);

                //chamando a variavel dr do tipo de leitura do banco para armazenar os dados do camando acima.
                dr = cmd.ExecuteReader();

                List<FilmDTO> lista = new List<FilmDTO>();

                //Enquanto o dr continuar lendo os dados do banco
                while (dr.Read())
                {
                    //ele vai adicionar os dados da tabela nos parametros do usuarioDTO
                    FilmDTO filme = new FilmDTO();
                    filme.idFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = Convert.ToString(dr["TituloFilm"]);
                    filme.ProdutoraFilm = Convert.ToString(dr["ProdutoraFilm"]);
                    filme.UrlImgFilm = Convert.ToString(dr["UrlImgFilm"]);
                    filme.Classificacao_Id = Convert.ToString(dr["DescricaoClassificacao"]);
                    filme.Genero_Id = Convert.ToString(dr["DescricaoGenero"]);
                    //no final ele vai adicionar tudo na lista
                    lista.Add(filme);
                }


                //e retornar a lista.
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }

        public List<ClassificacaoDTO> LoadDLLClassificacao()

        {
            try
            {
                Conectar();

                cmd = new SqlCommand("SELECT * FROM Classificacao;", conn);
                dr = cmd.ExecuteReader();

                List<ClassificacaoDTO> lista = new List<ClassificacaoDTO>();
                while (dr.Read())
                {
                    ClassificacaoDTO classificacao = new ClassificacaoDTO();
                    classificacao.IdClassificacao = Convert.ToInt32(dr["IdClassificacao"]);
                    classificacao.DescricaoClassificacao = Convert.ToString(dr["DescricaoClassificacao"]);
                    lista.Add(classificacao);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<GeneroDTO> LoadDLLGenero()

        {
            try
            {
                Conectar();

                cmd = new SqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();

                List<GeneroDTO> lista = new List<GeneroDTO>();
                while (dr.Read())
                {
                    GeneroDTO genero = new GeneroDTO();
                    genero.IdGenero = Convert.ToInt32(dr["IdGenero"]);
                    genero.DescricaoGenero = Convert.ToString(dr["DescricaoGenero"]);
                    lista.Add(genero);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
