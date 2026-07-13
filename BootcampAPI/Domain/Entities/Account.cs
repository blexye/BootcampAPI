namespace BootcampAPI.Domain.Entities
{
	public class Account
	{
		public Guid Id { get; set; }
		public int AccountNumber { get; set; }
		public string AccountType { get; set; } = string.Empty;
		public decimal Balance { get; set; }
		public string Currency { get; set; } = string.Empty;
		public bool IsActive { get; set; } = true;
	}
}
