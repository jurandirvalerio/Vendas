﻿using System.Collections.Generic;
using ObjetosNegocio;

namespace Servicos.Contratos
{
	public interface IClienteService
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