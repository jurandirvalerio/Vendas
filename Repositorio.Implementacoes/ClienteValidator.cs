using AcessoDados.Contratos;
using ObjetosNegocio;
using Repositorios.Contratos;
using System.Linq;

namespace Repositorios.Implementacoes
{
	public class ClienteValidator : IClienteValidator
	{
		#region Campos

		private readonly IVendasContext _vendasContext;

		#endregion

		#region Construtores

		public ClienteValidator(IVendasContext vendasContext)
		{
			_vendasContext = vendasContext;
		}

		#endregion

		#region Métodos

		public bool PodeIncluir(Cliente cliente, out string mensagem)
		{
			if (ClienteJaCadastrado(cliente))
			{
				mensagem = "Cliente já cadastrado com este nome";
				return false;
			}

			mensagem = null;
			return true;
		}

		private bool ClienteJaCadastrado(Cliente cliente)
		{
			return _vendasContext.ClienteSet.Any(p => p.Nome == cliente.Nome);
		}

		#endregion
	}
}