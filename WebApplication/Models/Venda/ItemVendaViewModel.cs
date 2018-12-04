namespace WebApplication.Models.Venda
{
	public class ItemVendaViewModel
	{
		#region Propriedades

		public int CodigoProduto { get; set; }
		public decimal PrecoUnitario { get; set; }
		public int Quantidade { get; set; }
		public string DescricaoProduto { get; set; }

		#endregion
	}
}