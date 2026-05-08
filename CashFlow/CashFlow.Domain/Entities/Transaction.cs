using CashFlow.Domain.Enums;
namespace CashFlow.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
