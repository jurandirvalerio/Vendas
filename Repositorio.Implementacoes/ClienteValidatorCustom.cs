using System.Linq;
using AcessoDados.Contratos;
using ObjetosNegocio;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ClienteValidatorCustom : IClienteValidator
	{
		#region Campos

		private readonly IVendasContext _vendasContext;

		#endregion

		#region Construtores

		public ClienteValidatorCustom(IVendasContext vendasContext)
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

			if (ClienteNaoTemSobrenome(cliente))
			{
				mensagem = "Cliente deve ter um sobrenome";
				return false;
			}

			mensagem = null;
			return true;
		}

		private static bool ClienteNaoTemSobrenome(Cliente cliente)
		{
			return string.IsNullOrWhiteSpace(cliente.Nome) || cliente.Nome.Split(' ').Count() < 2;
		}

		private bool ClienteJaCadastrado(Cliente cliente)
		{
			return _vendasContext.ClienteSet.Any(p => p.Nome == cliente.Nome);
		}

		#endregion
	}
}