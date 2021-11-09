using CRUD.BD;
using CRUD.BD.Postgree;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CRUD
{
    public class Escola : INotifyPropertyChanged
    {

        public ObservableCollection<Aluno> listaAluno { get; set; }
        public ICommand Inserir { get; set; }
        public ICommand Excluir { get; set; }
        public ICommand Alterar { get; set; }
        public ICommand Filtrar { get; set; }
        public ICommand LimparFiltro { get; set; }

        public Aluno alunoSelecionado { get; set; }
        public Aluno alunoPreenchido { get; set; }
        public int index { get; set; }
        public IConexao conexao;

        public Escola()
        {
            conexao = new ConexaoPGSQL();
            alunoPreenchido = new Aluno();
            listaAluno = new ObservableCollection<Aluno>();
            MeusComandos();            
        }

        


        public void MeusComandos()
        {
            Inserir = new RelayCommand(
                (object param) =>
                {
                    try
                    {
                        conexao.InserirAluno(alunoPreenchido, listaAluno);
                        limpaCampos();
                        Notifica(); 

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                },
                (object param) =>
                {
                    return true;
                }
                );

            Excluir = new RelayCommand(
                (object param) => {
                    if (alunoSelecionado != null) {
                        try
                        {
                            conexao.ExcluirAluno(alunoSelecionado, listaAluno);
                            Notifica();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        
                    }

                },
                (object param) =>
                {
                    return true;
                }
                );
            Alterar = new RelayCommand(
               (object param) =>
               {
                   if (alunoPreenchido != null)
                   {
                       try
                       {
                           alunoPreenchido.Id = alunoSelecionado.Id;
                           conexao.AtualizaAluno(alunoPreenchido, alunoSelecionado);
                           limpaCampos();
                           Notifica();
                       }
                       catch (Exception ex)
                       {

                           MessageBox.Show(ex.Message);
                       }
                   }

               },
               (object param) =>
               {
                   return true;
               }
               );

            Filtrar = new RelayCommand(
                (object param) =>
                {
                    if (alunoPreenchido.NomeCompleto != null)
                    { 
                        try
                        {
                            conexao.BuscaAluno(alunoPreenchido, listaAluno);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);

                        }
                    }
                    else
                    {
                        //caso não tenha nada no campo para busca, eu simplesmente atualizo minha lista somente pelo que já esta no banco de dados
                        conexao.BuscaTodosAlunos(alunoPreenchido, listaAluno);

                    }


                },
                
                (object param) =>
                {
                    return true;
                }
                );

            LimparFiltro = new RelayCommand(
                (object param) => {



                },
                (object param) =>
                {
                    return true;
                }
                );
        }



        public void limpaCampos()
        {
            alunoPreenchido.NomeCompleto = "";
            alunoPreenchido.Serie = "";
            alunoPreenchido.Email = "";
            alunoPreenchido.Telefone = "";

        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void Notifica(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }






}
