using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace poo3b149e50.DTO
{
    public class tblEditoraDTO
    {
        private int id_editora;
        private string nome_editora, endereco_editora, uf_editora;

        public int Id_editora { get => id_editora; set => id_editora = value; }

        public string Nome_editora
        {
            get { return nome_editora; }
            set
            {
                if (value != string.Empty)
                {
                    nome_editora = value;
                }
                else
                {
                    throw new Exception("O campo E-mail é obrigatório.");
                }
            }
        }

        public string Endereco_editora
        {
            get { return endereco_editora; }
            set
            {
                if (value != string.Empty)
                {
                    endereco_editora = value;
                }
                else
                {
                    throw new Exception("O campo Endereço é obrigatório.");
                }
            }
        }

        public string UF_editora
        {
            get { return uf_editora; }
            set
            {
                if (value != string.Empty)
                {
                    uf_editora = value;
                }
                else
                {
                    throw new Exception("O campo UF é obrigatório.");
                }
            }
        }
    }
}