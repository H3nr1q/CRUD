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
        public NpgsqlCommand comando;
        public NpgsqlDataAdapter da;
        public NpgsqlDataReader dr;
        private NpgsqlConnection conexao { get; set; }
        
        public int codMax;

        string instrucaoSQL;
        public List<Aluno> lista;
        public Aluno aluno;
        public int index;

        public ConexaoPGSQL()
        {
            comando = new NpgsqlCommand(instrucaoSQL);
            lista = new List<Aluno>();
            codMax = 1;

        }
        

        public void Conecta()
        {
            conexao = new NpgsqlConnection(strConexao);
            conexao.Open();
        }

        public void Desonecta()
        {
            conexao.Close();
        }

        public void InserirAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            instrucaoSQL = "insert into aluno(id, nomeCompleto, telefone, email, serie) values(@id, @nomeCompleto, @telefone, @email, @serie)";
            comando.Parameters.AddWithValue("@id", codMax);
            comando.Parameters.AddWithValue("@nomeCompleto", aluno.NomeCompleto);
            comando.Parameters.AddWithValue("@telefone", aluno.Telefone);
            comando.Parameters.AddWithValue("@email", aluno.Email);
            comando.Parameters.AddWithValue("@serie", aluno.Serie);
            comando.ExecuteNonQuery();
            //depois insiro na lista
            lista.Add(new Aluno(codMax, aluno.NomeCompleto, aluno.Telefone, aluno.Email, aluno.Serie));
        }

    //    public void ExcluirAluno()
    //    {
    //        //Primeiro removo do banco
    //        instrucaoSQL = "delete from aluno where id = @id";
    //        comando = new NpgsqlCommand(instrucaoSQL, conexao);
    //        comando.Parameters.AddWithValue("@id", alunoSelecionado.Id);
    //        comando.ExecuteNonQuery();
    //        //removo da lista
    //        listaAluno.Remove(alunoSelecionado);
    //    }

    //    public void AtualizaAluno()
    //    {
    //        instrucaoSQL = "update aluno set " +
    //                                       "nomeCompleto = @nomeCompleto, " +
    //                                       "telefone = @telefone, " +
    //                                       "email = @email, " +
    //                                       "serie = @serie " +
    //                                       "where id = @id";
    //        comando = new NpgsqlCommand(instrucaoSQL, conexao);
    //        comando.Parameters.AddWithValue("@id", alunoSelecionado.Id);
    //        comando.Parameters.AddWithValue("@nomeCompleto", alunoPreenchido.NomeCompleto);
    //        comando.Parameters.AddWithValue("@telefone", alunoPreenchido.Telefone);
    //        comando.Parameters.AddWithValue("@email", alunoPreenchido.Email);
    //        comando.Parameters.AddWithValue("@serie", alunoPreenchido.Serie);
    //        comando.ExecuteNonQuery();
    //        //depois autualizo minha lista
    //        listaAluno[index].NomeCompleto = alunoPreenchido.NomeCompleto;
    //        listaAluno[index].Telefone = alunoPreenchido.Telefone;
    //        listaAluno[index].Email = alunoPreenchido.Email;
    //        listaAluno[index].Serie = alunoPreenchido.Serie;
    //    }

    //    public void BuscaAluno()
    //    {
    //        //busco no banco de dados
    //        listaAluno.Clear();
    //        instrucaoSQL = "select id, nomeCompleto, telefone, email, serie  from aluno " +
    //                            "where nomeCompleto like @nomeCompleto ";
    //        comando = new NpgsqlCommand(instrucaoSQL, conexao);
    //        comando.Parameters.AddWithValue("@nomeCompleto", "%" + alunoPreenchido.NomeCompleto + "%");
    //        dr = comando.ExecuteReader();

    //        //limpo minha lista e insiro somente a busca personalizada
    //        while (dr.HasRows && dr.Read())
    //        {
    //            listaAluno.Add(new Aluno(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4)));
    //        }
    //    }

    //    public void BuscaTodosAlunos()
    //    {
    //        listaAluno.Clear();
    //        conexao.Open();
    //        instrucaoSQL = "select id, nomeCompleto, telefone, email, serie  from aluno";
    //        comando = new NpgsqlCommand(instrucaoSQL, conexao);
    //        dr = comando.ExecuteReader();

    //        while (dr.HasRows && dr.Read())
    //        {

    //            listaAluno.Add(new Aluno(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4)));
    //        }
    //    }
    }
}
