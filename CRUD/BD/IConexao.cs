using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUD.BD
{
    public interface IConexao
    {
        public abstract void Conecta();
        public abstract void Desonecta();

        public abstract void InserirAluno(Aluno aluno, ObservableCollection<Aluno> lista);

        public abstract void ExcluirAluno(Aluno aluno, ObservableCollection<Aluno> lista);

        //public abstract void AtualizaAluno();

        //public abstract void BuscaAluno();

        //public abstract void BuscaTodosAlunos();
    }
}
