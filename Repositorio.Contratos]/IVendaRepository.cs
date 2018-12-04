using System.Collections.Generic;
using ObjetosNegocio;

namespace Repositorios.Contratos
{
	public interface IVendaRepository
	{
		#region Métodos

		List<Venda> Listar();
		Venda Obter(int codigo);
		void Incluir(Venda venda);
		bool PodeIncluir(Venda venda, out string mensagem);
		void Alterar(Venda venda);
		bool PodeAlterar(Venda venda, out string mensagem);
		void Excluir(int codigo);
		bool PodeExcluir(int codigo, out string mensagem);

		#endregion
	}
}