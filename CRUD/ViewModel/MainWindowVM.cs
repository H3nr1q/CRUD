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

        public Escola()
        {
            Conexao.Con(new ConexaoPGSQL());
            MeusComandos();            
        }

        


        public void MeusComandos()
        {
            Inserir = new RelayCommand(
                (object param) =>
                {
                    try
                    {
                        Conexao.InserirAluno(alunoPreenchido, listaAluno);
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
                            //Conexao.ExcluirAluno(alunoSelecionado);
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
                           //atualizo banco de dados primeiro
                           //Conexao.AtualizaAluno(alunoSelecionado);
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
                            //Conexao.BuscaAluno(alunoPreenchido);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);

                        }
                    }
                    else
                    {
                        //caso não tenha nada no campo para busca, eu simplesmente atualizo minha lista somente pelo que já esta no banco de dados
                        //Conexao.BuscaTodosAlunos(alunoPreenchido);

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
