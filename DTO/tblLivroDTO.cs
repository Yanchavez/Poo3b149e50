﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace poo3b149e50.DTO
{
    public class tblLivroDTO
    {
        private int id_livro, id_autor, id_editora, num_paginas;
        private double valor_livro;
        private DateTime data_cadastro;
        private string titulo_livro;

        public string Titulo_livro
        {
            get { return titulo_livro; }
            set
            {
                if (value != string.Empty)
                {
                    titulo_livro = value;
                }
                else
                {
                    throw new Exception("Título do Livro é obrigatório!");
                }
            }
        }

        public DateTime Data_cadastro { get => data_cadastro; set => data_cadastro = value; }
        public int Id_livro { get => id_livro; set => id_livro = value; }
        public int Id_autor { get => id_autor; set => id_autor = value; }
        public int Id_editora { get => id_editora; set => id_editora = value; }

        public double Valor_livro
        {
            get { return valor_livro; }
            set
            {
                if (value != 0)
                {
                    valor_livro = value;
                }
                else
                {
                    throw new Exception("Valor de livro é necessário!");
                }
            }
        }

        public int Num_paginas
        {
            get { return num_paginas; }
            set
            {
                if (value != 0)
                {
                    num_paginas = value;
                }
                else
                {
                    throw new Exception("Número de páginas são necessárias!");
                }
            }
        }

    }
}