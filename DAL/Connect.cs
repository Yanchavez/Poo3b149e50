using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;




namespace poo3b149e50.DAL
{
    public class Connect
    {
        private string string_conexao = "Persist Security info=false ; server=localhost ; database=bd_Livraria ; user=root ; pwd=''";
        private MySqlConnection conexao;

        public void Conectar()
        {
            try
            {
                conexao = new MySqlConnection(string_conexao);
                conexao.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception("Erro de conexão com o Banco de Dados. " + e.Message);
            }
        }

        public void Comando(string sql)
        {
            try
            {
                Conectar();
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw new Exception("Não foi possível executar  " + e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable Consulta(string sql)
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dados = new MySqlDataAdapter(sql, conexao);
                dados.Fill(dt);
                return dt;
            }
            catch (MySqlException e)
            {
                throw new Exception("Não foi possível executar a consulta " + e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }



    }
}