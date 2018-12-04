using System.Collections.Generic;
using ObjetosNegocio;

namespace Servicos.Contratos
{
	public interface IVendaService
	{
		#region Métodos

		List<Venda> Listar();
		Venda Obter(int codigo);
		bool Incluir(Venda venda, out string mensagem);
		bool Alterar(Venda venda, out string mensagem);
		bool Excluir(int codigo, out string mensagem);

		#endregion
	}
}