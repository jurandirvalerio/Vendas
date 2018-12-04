using System.Web.Mvc;
using Servicos.Contratos;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Models.Venda;

namespace WebApplication.Controllers
{
	public class VendaController : Controller
	{
		#region Ações

		public ActionResult Listar()
		{
			return View(_vendaMapper.Map(_vendaService.Listar()));
		}

		public ActionResult Incluir()
		{
			return View(new VendaViewModel());
		}

		[HttpPost]
		public JsonResult Incluir(VendaViewModel vendaViewModel)
		{
			return Json(new
			{
				resultado = _vendaService.Incluir(_vendaMapper.Map(vendaViewModel), out var mensagem),
				mensagem
			});
		}

		public ActionResult Alterar(int codigo)
		{
			return View(_vendaMapper.Map(_vendaService.Obter(codigo)));
		}

		[HttpPost]
		public JsonResult Alterar(VendaViewModel vendaViewModel)
		{
			return Json(new
			{
				resultado = _vendaService.Alterar(_vendaMapper.Map(vendaViewModel), out var mensagem),
				mensagem
			});
		}

		[HttpPost]
		public JsonResult Excluir(int codigo)
		{
			return Json(new
			{
				resultado = _vendaService.Excluir(codigo, out var mensagem),
				mensagem
			});
		}

		#endregion

		#region Campos

		private readonly IVendaMapper _vendaMapper;
		private readonly IVendaService _vendaService;

		#endregion

		#region Construtores

		public VendaController(IVendaMapper vendaMapper, IVendaService vendaService)
		{
			_vendaMapper = vendaMapper;
			_vendaService = vendaService;
		}

		#endregion
	}
}