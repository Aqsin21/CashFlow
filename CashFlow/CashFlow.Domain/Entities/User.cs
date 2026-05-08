using Microsoft.AspNetCore.Identity;
namespace CashFlow.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
