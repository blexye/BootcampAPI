using BootcampAPI.Api.Domain.Enums;
using BootcampAPI.Domain.Enums;

namespace BootcampAPI.Domain.Entities
{
	public class Account
	{
		public Guid Id { get; set; }
		public int AccountNumber { get; set; }
		public TiposCuenta AccountType { get; set; } = TiposCuenta.CuentaCorriente;
		public decimal Balance { get; set; }
		public Monedas Currency { get; set; } = Monedas.PYG;
		public bool IsActive { get; set; } = true;
		public DateTime CreatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
