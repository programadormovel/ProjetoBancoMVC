using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Funcionario.Repository
{
    public class Conexao
    {
        protected SqlConnection conn;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        //método para abrir a conexão
        protected void AbrirConexao()
        {
            try
            {
                //conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=AULAMVC;User Id=sa;Password=123456");
                conn = new SqlConnection("Data Source=localhost;Initial Catalog=AULAMVC;User Id=sa;Password=Ad#1an01");
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir a conexão: " + e.Message);
            }
        }

        //metodo para fechar a conexão

        protected void FecharConexao()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao fechar a conexão: " + e.Message);
            }
        }
    }
}