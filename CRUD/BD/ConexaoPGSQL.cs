using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUD.BD.Postgree
{
    public class ConexaoPGSQL:IConexao
    {
        private string strConexao = "Server=localhost; Database=WPFCRUD; Port=5432; User Id=postgres; Password=123";
        private NpgsqlCommand comando;
        private NpgsqlDataAdapter da;
        private NpgsqlDataReader dr;
        private NpgsqlConnection conexao;
        
        public int codMax;
        public List<Aluno> lista;
        public Aluno aluno;
        //public int index;

        public ConexaoPGSQL()
        {
            comando = new NpgsqlCommand();
            conexao = new NpgsqlConnection(strConexao);
            comando.Connection = conexao;
            lista = new List<Aluno>();
            codMax = 1;

        }
        


        public void InserirAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "insert into aluno(id, nomeCompleto, telefone, email, serie) values(@id, @nomeCompleto, @telefone, @email, @serie)";
                comando.Parameters.AddWithValue("@id", codMax);
                comando.Parameters.AddWithValue("@nomeCompleto", aluno.NomeCompleto);
                comando.Parameters.AddWithValue("@telefone", aluno.Telefone);
                comando.Parameters.AddWithValue("@email", aluno.Email);
                comando.Parameters.AddWithValue("@serie", aluno.Serie);
                comando.ExecuteNonQuery();
                //depois insiro na lista
                lista.Add(new Aluno(codMax, aluno.NomeCompleto, aluno.Telefone, aluno.Email, aluno.Serie));
                codMax++;

            }
            catch
            {
                throw;
            }

            finally
            {
                conexao.Close();
                comando.Parameters.Clear();
            }
            
        }

        public void ExcluirAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {

            try
            {
                //Primeiro removo do banco
                conexao.Open();
                comando.CommandText = "delete from aluno where id = @id";
                comando.Parameters.AddWithValue("@id", aluno.Id);
                comando.ExecuteNonQuery();
                //removo da lista
                lista.Remove(aluno);

            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Parameters.Clear();
            }
           
        }

        public void AtualizaAluno(int id, Aluno aluno, ObservableCollection<Aluno> lista, int index)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "update aluno set " +
                                               "nomeCompleto = @nomeCompleto, " +
                                               "telefone = @telefone, " +
                                               "email = @email, " +
                                               "serie = @serie " +
                                               "where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nomeCompleto", aluno.NomeCompleto);
                comando.Parameters.AddWithValue("@telefone", aluno.Telefone);
                comando.Parameters.AddWithValue("@email", aluno.Email);
                comando.Parameters.AddWithValue("@serie", aluno.Serie);
                comando.ExecuteNonQuery();
                //depois autualizo minha lista
                lista[index].NomeCompleto = aluno.NomeCompleto;
                lista[index].Telefone = aluno.Telefone;
                lista[index].Email = aluno.Email;
                lista[index].Serie = aluno.Serie;

            }
            catch 
            {

                throw;
            }
            finally
            {
                conexao.Close();
                comando.Parameters.Clear();
            }
            
        }

        public void BuscaAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            try
            {
                conexao.Open();
                //busco no banco de dados
                lista.Clear();
                comando.CommandText = "select id, nomeCompleto, telefone, email, serie  from aluno " +
                                    "where nomeCompleto like @nomeCompleto ";
                comando.Parameters.AddWithValue("@nomeCompleto", "%" + aluno.NomeCompleto + "%");
                dr = comando.ExecuteReader();

                //limpo minha lista e insiro somente a busca personalizada
                while (dr.HasRows && dr.Read())
                {
                    lista.Add(new Aluno(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4)));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Parameters.Clear();
            }
            
        }

        public void BuscaTodosAlunos(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            try
            {
                conexao.Open();
                lista.Clear();
                comando.CommandText = "select id, nomeCompleto, telefone, email, serie  from aluno";
                dr = comando.ExecuteReader();

                while (dr.HasRows && dr.Read())
                {

                    lista.Add(new Aluno(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4)));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Parameters.Clear();
            }
            
        }
    }
}
