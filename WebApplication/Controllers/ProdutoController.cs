using System.Web.Mvc;
using Servicos.Contratos;
using WebApplication.Infrastructure.Mappers.Contratos;
using WebApplication.Models.Produto;

namespace WebApplication.Controllers
{
	public class ProdutoController : Controller
	{
		#region Ações

		public ActionResult Listar()
		{
			return View(_produtoMapper.Map(_produtoService.Listar()));
		}

		public ActionResult Incluir()
		{
			return View(new ProdutoViewModel());
		}
		
		[HttpPost]
		public JsonResult Incluir(ProdutoViewModel produtoViewModel)
		{
			return Json(new
			{
				resultado = _produtoService.Incluir(_produtoMapper.Map(produtoViewModel), out var mensagem),
				mensagem
			});
		}

		public ActionResult Alterar(int codigo)
		{
			return View(_produtoMapper.Map(_produtoService.Obter(codigo)));
		}

		[HttpPost]
		public JsonResult Alterar(ProdutoViewModel produtoViewModel)
		{
			return Json(new
			{
				resultado = _produtoService.Alterar(_produtoMapper.Map(produtoViewModel), out var mensagem),
				mensagem
			});
		}

		[HttpPost]
		public JsonResult Excluir(int codigo)
		{
			return Json(new
			{
				resultado = _produtoService.Excluir(codigo, out var mensagem),
				mensagem
			});
		}

		#endregion

		#region Campos

		private readonly IProdutoMapper _produtoMapper;
		private readonly IProdutoService _produtoService;

		#endregion

		#region Construtores

		public ProdutoController(IProdutoMapper produtoMapper, IProdutoService produtoService)
		{
			_produtoMapper = produtoMapper;
			_produtoService = produtoService;
		}

		#endregion
	}
}