using Funcionario.Repository;
using ProjetoBancoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoBancoMVC.Repository
{
	public class FuncionarioRepository : Conexao
	{
		public byte[] Empy { get; private set; }	

		public List<FuncionarioModel> SelecionarFuncionarios()
		{
			try
			{
				AbrirConexao();

				Cmd = new SqlCommand("SelecionarFuncionarios", conn);
				Cmd.CommandType = CommandType.StoredProcedure;

				// Aqui irá ler os registros obtidos através do SqlDataReader
				Dr = Cmd.ExecuteReader();	

				// Criando uma lista vazia
				var lista = new List<FuncionarioModel>();	
				
				while (Dr.Read())
				{
					var func = new FuncionarioModel
					{
						IdFuncionario = Convert.ToInt32(Dr["Id"]),
						Nome = Convert.ToString(Dr["Nome"]),
						Sobrenome = Convert.ToString(Dr["Sobrenome"]),
						Cidade = Convert.ToString(Dr["Cidade"]),
						Endereco = Convert.ToString(Dr["Endereco"]),
						Email = Convert.ToString(Dr["Email"]),
						Imagem = (Dr["Imagem"] == DBNull.Value) ? Empy : (byte[])Dr["Imagem"]
						// Imagem = (byte[]) Dr["Imagem"]
					};
					lista.Add(func);
				}
				return lista;
			}
			catch (Exception e)
			{
				throw new Exception($"Erro ao selecionar o Funcionário: {e.Message}");
			}
		}
	}
}