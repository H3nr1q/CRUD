using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRUD
{
    public class Aluno : INotifyPropertyChanged
    {

        private int _id;
        private string _nomeCompleto;
        private string _telefone;
        private string _email;
        private string _serie;
      
        public Aluno(int id, string nomeCompleto, string telefone, string email, string serie)
        {
            this._id = id;
            this._nomeCompleto = nomeCompleto;
            this._telefone = telefone;
            this._email = email;
            this._serie = serie;
           
        }

        public Aluno()
        {
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                Notifica("Id");
            }

        }
        public string NomeCompleto
        {
            get
            {
                return _nomeCompleto;
            }
            set
            {
                _nomeCompleto = value;
                Notifica("NomeCompleto");
            }

        }

        public string Telefone
        {
            get
            {
                return _telefone;
            }
            set
            {
                _telefone = value;
                Notifica("Telefone");
            }

        }


        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                Notifica("Email");
            }

        }



        public string Serie
        {
            get
            {
                return _serie;
            }
            set
            {
                _serie = value;
                Notifica("Serie");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;


            private void Notifica(string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        

    }
}
