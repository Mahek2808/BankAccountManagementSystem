using BankAccountManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.DBContext
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options) : base(options) { }
        
        public DbSet<BankAccount> BankAccountsDetails { get; set; }
        public DbSet<Payment> PaymentDetails { get; set; }
        public DbSet<AccountType> AccountTypesDetails { get; set; }
        public DbSet<BankTransaction> BankTransactionDetails { get; set; }
        public DbSet<BankAccountPostingDetails> BankAccountPostingDetails { get; set; }
    }
}
