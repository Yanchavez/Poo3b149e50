using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using poo3b149e50.DAL;
using poo3b149e50.DTO;

namespace poo3b149e50.BLL
{
    public class tblAutorBLL
    {
        private Connect daoBanco = new Connect();
        public DataTable listarAutores()
        {
            string sql = string.Format($@"SELECT * FROM TBL_Autor");
            return daoBanco.Consulta(sql);
        }

        public void criarAutor(tblAutorDTO dados)
        {
            string sql = string.Format($@"INSERT INTO TBL_Autor VALUES (NULL, '{dados.Nome_autor}', '{dados.Idade_autor}');");
            daoBanco.Comando(sql);
        }

        public void deletarAutor(tblAutorDTO dados)
        {
            string sql = string.Format($@"DELETE FROM TBL_Autor where id = {dados.Id_autor};");
            daoBanco.Comando(sql);
        }

        public void atualizarAutor(tblAutorDTO dados)
        {
            string sql = string.Format($@"UPDATE TBL_Autor SET nome = '{dados.Nome_autor}', idade = '{dados.Idade_autor}' ) WHERE id = {dados.Id_autor};");
            daoBanco.Comando(sql);
        }
    }
}