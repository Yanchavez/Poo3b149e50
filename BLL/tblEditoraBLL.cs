using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using poo3b149e50.DAL;
using poo3b149e50.DTO;

namespace poo3b149e50.BLL
{
    public class tblEditoraBLL
    {
        private Connect daoBanco = new Connect();
        public DataTable listarEditoras()
        {
            string sql = string.Format($@"SELECT * FROM TBL_Editora");
            return daoBanco.Consulta(sql);
        }

        public void criarEditora(tblEditoraDTO dados)
        {
            string sql = string.Format($@"INSERT INTO TBL_Editora VALUES (NULL, '{dados.Nome_editora}', '{dados.Endereco_editora}', '{dados.UF_editora}');");
            daoBanco.Consulta(sql);
        }

        public void deletarEditora(tblEditoraDTO dados)
        {
            string query = string.Format($@"DELETE FROM TBL_Editora where id = {dados.Id_editora};");
            daoBanco.Comando(query);
        }

        public void atualizarEditora(tblEditoraDTO dados)
        {
            string query = string.Format($@"UPDATE TBL_Editora SET nome = '{dados.Nome_editora}', endereco = '{dados.Endereco_editora}', UF = '{dados.UF_editora}' ) WHERE id = {dados.Id_editora};");
            daoBanco.Comando(query);
        }
    }
}