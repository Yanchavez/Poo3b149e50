using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using poo3b149e50.DAL;
using poo3b149e50.DTO;

namespace poo3b149e50.BLL
{
    public class tblLivroBLL
    {
        private Connect daoBanco = new Connect();
        public DataTable listarLivros()
        {
            string sql = string.Format($@"SELECT * FROM TBL_Livro");
            return daoBanco.Consulta(sql);
        }

        public void criarLivro(tblLivroDTO dados)
        {
            string sql = string.Format($@"INSERT INTO TBL_Livro VALUES(NULL, '{dados.Id_autor}', '{dados.Id_editora}', '{dados.Titulo_livro}', '{dados.Data_cadastro.ToString("yyyy-MM-dd")}', '{dados.Num_paginas}', '{dados.Valor_livro}');");
            daoBanco.Comando(sql);
        }

        public void deletarLivro(tblLivroDTO dados)
        {
            string sql = string.Format($@"DELETE FROM TBL_Livro where idLivro = {dados.Id_livro};");
            daoBanco.Comando(sql);
        }

        public void atualizarLivro(tblLivroDTO dados)
        {
            string sql = string.Format($@"UPDATE TBL_Livro SET idAutor = '{dados.Id_autor}', idEditora = '{dados.Id_editora}', titulo = '{dados.Titulo_livro}', dataCadastro = '{dados.Data_cadastro.ToString("yyyy-MM-dd")}', numPaginas = '{dados.Num_paginas}', valor = '{dados.Valor_livro}' WHERE idLivro = '{dados.Id_livro}';");
            daoBanco.Comando(sql);
        }
    }
}