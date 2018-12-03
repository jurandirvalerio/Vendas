﻿using System.Collections.Generic;
using ObjetosNegocio;

namespace Repositorios.Contratos
{
	public interface IClienteRepository
	{
		#region Métodos

		List<Cliente> Listar();
		Cliente Obter(int codigo);
		void Incluir(Cliente cliente);
		void Alterar(Cliente cliente);
		void Excluir(int codigo);

		#endregion
	}
}