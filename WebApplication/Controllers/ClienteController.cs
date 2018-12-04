using System.Web.Mvc;
using Servicos.Contratos;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Models.Cliente;

namespace WebApplication.Controllers
{
	public class ClienteController : Controller
	{
		#region Ações

		public ActionResult Listar()
		{
			return View(_clienteMapper.Map(_clienteService.Listar()));
		}

		public ActionResult Incluir()
		{
			return View(new ClienteViewModel());
		}
		
		[HttpPost]
		public JsonResult Incluir(ClienteViewModel clienteViewModel)
		{
			return Json(new
			{
				resultado = _clienteService.Incluir(_clienteMapper.Map(clienteViewModel), out var mensagem),
				mensagem
			});
		}

		public ActionResult Alterar(int codigo)
		{
			return View(_clienteMapper.Map(_clienteService.Obter(codigo)));
		}

		[HttpPost]
		public JsonResult Alterar(ClienteViewModel clienteViewModel)
		{
			return Json(new
			{
				resultado = _clienteService.Alterar(_clienteMapper.Map(clienteViewModel), out var mensagem),
				mensagem
			});
		}

		[HttpPost]
		public JsonResult Excluir(int codigo)
		{
			return Json(new
			{
				resultado = _clienteService.Excluir(codigo, out var mensagem),
				mensagem
			});
		}

		#endregion

		#region Campos

		private readonly IClienteMapper _clienteMapper;
		private readonly IClienteService _clienteService;

		#endregion

		#region Construtores

		public ClienteController(IClienteMapper clienteMapper, IClienteService clienteService)
		{
			_clienteMapper = clienteMapper;
			_clienteService = clienteService;
		}

		#endregion
	}
}