using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CeuEscuro.DAL
{
    public class UsuarioDAL : Conexao
    {
        //Autenticar
        public UsuarioDTO Autenticar(string nome, string senha)
        {
            //estrutura para tratamento de erros.
            try
            {
                Conectar();
                //Fazendo um select no banco para verificar o nome e senha do usuario digitado nos parametros do metodo.
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario AND SenhaUsuario = @SenhaUsuario;", conn);
                //os comando abaixo estao solicitando os parametros digitados no metodos e associando ao valor digitado no select acima.
                //o cmd.Parameters serve para associar ao parametros
                //O AddWithValue serve para associar o parametro ao parametro do query
                cmd.Parameters.AddWithValue("@NomeUsuario", nome);
                cmd.Parameters.AddWithValue("@SenhaUsuario", senha);

                UsuarioDTO usuario = null;
                // a variavel dr vai ler e guardar o que foi selecionado no cmd select.
                dr = cmd.ExecuteReader();

                //se a variavel dr tiver algo
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.NomeUsuario = dr["NomeUsuario"].ToString();
                    usuario.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    usuario.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();

                }
                return usuario;
                //se nao, ele vai para o catch


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //Console.WriteLine($"Erro ao executar {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //CRUD
        //Create
        public void Create(UsuarioDTO usuario)
        {
            try
            {
                Conectar();
                //Comando para executar uma query do banco pelo c#, caso o comando abaixo serve para inserir novos usuarios.
                cmd = new SqlCommand("INSERT INTO Usuario (NomeUsuario,EmailUsuario,SenhaUsuario,DtNascUsuario,TipoUsuario_Id) VALUES (@NomeUsuario,@EmailUsuario,@SenhaUsuario,@DtNascUsuario,@TipoUsuario_Id);", conn);

                //O comando abaixo serve para vincular cada campo do banco com os parametros do usuarioDTO (usuario modelo).
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", usuario.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", usuario.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DtNascUsuario", usuario.DtNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
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

        //Read
        public List<UsuarioDTO> GetUsers()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdUsuario, NomeUsuario, EmailUsuario, SenhaUsuario, DtNascUsuario, DescricaoTipoUsuario FROM Usuario INNER JOIN TipoUsuario ON TipoUsuario_Id = IdTipoUsuario;", conn);

                //chamando a variavel dr do tipo de leitura do banco para armazenar os dados do camando acima.
                dr = cmd.ExecuteReader();

                List<UsuarioDTO> lista = new List<UsuarioDTO>();

                //Enquanto o dr continuar lendo os dados do banco
                while (dr.Read())
                {
                    //ele vai adicionar os dados da tabela nos parametros do usuarioDTO
                    UsuarioDTO usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    usuario.EmailUsuario = Convert.ToString(dr["EmailUsuario"]);
                    usuario.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = Convert.ToString(dr["DescricaoTipoUsuario"]);
                    //no final ele vai adicionar tudo na lista
                    lista.Add(usuario);
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

        //Update
        public void Update( UsuarioDTO usuario)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("UPDATE Usuario SET NomeUsuario = @NomeUsuario, EmailUsuario = @EmailUsuario, SenhaUsuario = @SenhaUsuario, DtNascUsuario = @DtNascUsuario, TipoUsuario_Id = @TipoUsuario_Id WHERE IdUsuario = @IdUsuario;", conn) ;

                
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", usuario.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", usuario.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DtNascUsuario", usuario.DtNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                
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
        //Delete
        public void Delete(int idUsuario)
        {
            try
            {
                Conectar();
                
                cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                
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
        //Search by Id
        public UsuarioDTO SearchByID (int usuarioId)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", usuarioId);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO();
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    usuario.EmailUsuario = Convert.ToString(dr["EmailUsuario"]);
                    usuario.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = Convert.ToString(dr["TipoUsuario_Id"]);
                }

                return usuario;

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

        //Search by Name
        public UsuarioDTO SearchByName(string usuarioNome)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuarioNome);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO();
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    usuario.EmailUsuario = Convert.ToString(dr["EmailUsuario"]);
                    usuario.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = Convert.ToString(dr["TipoUsuario_Id"]);
                }

                return usuario;

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

        //Load DropDownList
        public List<TipoUsuarioDTO> LoadDLL()

        {
            try
            {
                Conectar();

                cmd = new SqlCommand("SELECT * FROM TipoUsuario;", conn);
                dr = cmd.ExecuteReader();

                List<TipoUsuarioDTO> lista = new List<TipoUsuarioDTO>();
                while (dr.Read())
                {
                    TipoUsuarioDTO usuario = new TipoUsuarioDTO();
                    usuario.IdTipoUsuario = Convert.ToInt32(dr["IdTipoUsuario"]);
                    usuario.DescricaoTipoUsuario = Convert.ToString(dr["DescricaoTipoUsuario"]);
                    lista.Add(usuario);
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
