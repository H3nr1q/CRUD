using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUD.BD
{
    public interface IConexao
    {

        void InserirAluno(Aluno aluno, ObservableCollection<Aluno> lista);

        void ExcluirAluno(Aluno aluno, ObservableCollection<Aluno> lista);
        void AtualizaAluno(Aluno aluno, ObservableCollection<Aluno> lista, int index);
        void BuscaAluno(Aluno aluno, ObservableCollection<Aluno> lista);
        void BuscaTodosAlunos(Aluno aluno, ObservableCollection<Aluno> lista);
         
    }
}
