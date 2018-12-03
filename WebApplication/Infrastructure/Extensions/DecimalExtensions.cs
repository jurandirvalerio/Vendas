using System.Globalization;

namespace WebApplication.Infrastructure.Extensions
{
	public static class DecimalExtensions
	{
		public static string ToMoneyMask(this decimal valor)
		{
			return valor.ToString("C2", CultureInfo.CreateSpecificCulture("pt-Br"));
		}
	}
}