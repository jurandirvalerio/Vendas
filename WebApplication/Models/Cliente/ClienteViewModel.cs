using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Cliente
{
	public class ClienteViewModel
	{
		#region Propriedades
		
		public int Codigo { get; set; }
		public string Nome { get; set; }
		[Display(Name = "Data de nascimento")]
		public DateTime DataNascimento { get; set; } = DateTime.Now.AddYears(-18).Date;
		public string Telefone { get; set; }
		[Display(Name = "E-mail")]
		public string Email { get; set; } 

		#endregion
	}
}