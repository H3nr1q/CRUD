using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUD.BD
{
    public class ConexaoMYSQL : IConexao
    {


        public ConexaoMYSQL()
        {
            
        }

        public void AtualizaAluno(Aluno aluno, ObservableCollection<Aluno> lista, int index)
        {
            throw new NotImplementedException();
        }

        public void AtualizaAluno(Aluno alunoNovo, Aluno alunoAntigo)
        {
            throw new NotImplementedException();
        }

        public void BuscaAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            throw new NotImplementedException();
        }

        public void BuscaTodosAlunos(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            throw new NotImplementedException();
        }

        public void ExcluirAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            throw new NotImplementedException();
        }

        public void InserirAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            throw new NotImplementedException();
        }
    }
}
