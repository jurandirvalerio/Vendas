namespace ObjetosNegocio
{
	public class VendaItem
	{
		#region Propriedades

		public int CodigoVenda { get; set; }
		public Venda Venda { get; set; }
		public int CodigoProduto { get; set; }
		public Produto Produto { get; set; }
		public decimal PrecoUnitario { get; set; }
		public int Quantidade { get; set; }
		#endregion
	}
}