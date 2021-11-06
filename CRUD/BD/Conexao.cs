using CRUD.BD.Postgree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUD.BD
{
    public static class Conexao
    {
        private static IConexao conn;
        //public static void Con(IConexao con)
        //{
        //    conn = con;
        //    conn.Conecta();
        //}

        //public static void Desc()
        //{
        //    conn.Desonecta();
        //}

        public static void InserirAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            conn.InserirAluno(aluno, lista);
        }

        public static void ExcluirAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            conn.ExcluirAluno(aluno, lista);
        }

        public static void AtualizaAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            conn.AtualizaAluno(aluno, lista);
        }

        public static void BuscaAluno(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            conn.BuscaAluno(aluno, lista);
        }

        public static void BuscaTodosAlunos(Aluno aluno, ObservableCollection<Aluno> lista)
        {
            conn.BuscaTodosAlunos(aluno, lista);
        }
    }
}
