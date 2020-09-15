using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace poo3b149e50.DTO
{
    public class tblAutorDTO
    {
        private int id_autor, idade_autor;
        private string nome_autor;

        public int Id_autor { get => id_autor; set => id_autor = value; }

        public string Nome_autor
        {
            get { return nome_autor; }
            set
            {
                if (value != string.Empty)
                {
                    nome_autor = value;
                }
                else
                {
                    throw new Exception("Nome do autor é obrigatório!");
                }
            }
        }

        public int Idade_autor
        {
            get { return idade_autor; }
            set
            {
                if (value >= 0)
                {
                    idade_autor = value;
                }
                else
                {
                    throw new Exception("Idade para autor inválida");
                }
            }
        }
    }
}