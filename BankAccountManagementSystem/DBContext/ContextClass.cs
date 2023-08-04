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
        public DbSet<BankAccountPostingDetail> BankAccountPostingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType
                {
                    Id = Guid.NewGuid(),
                    Name = "Liability"
                },
                 new AccountType
                 {
                     Id = Guid.NewGuid(),
                     Name = "Asset"
                 }



            );
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "Cash"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheque"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "NEFT"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "RTGS"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "Other"
                }
             );
            //modelBuilder.Entity<BankTransaction>().HasData(
            //    new BankTransaction
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "A",
            //        MiddleName = "B",
            //        LastName = "C",
            //        TypeOfTransaction = Enum.TransactionType.TransactionTypeDebit,
            //        CatagoryOptions = Enum.CatagoryOptionsForBankAccount.Bank_Charges,
           
            //        DateOfTransaction = default(DateTime),
            //    }
            //    );
        }
    }
}
