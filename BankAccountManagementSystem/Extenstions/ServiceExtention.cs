using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.Repository;
using BankAccountManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.Extenstions
{
    public static class ServiceExtention
    {
        public static void AddBankAccountServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ContextClass>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddControllers();
            services.AddTransient<IBankAccountService, AccountDetailsService>();
            services.AddTransient<ITransactionService, TransactionDetailsService>();
            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IPostingService, TransactionPostingService>();
            services.AddTransient<IPostngRepository, TransactionPostingRepository>();
            services.AddTransient<IAccountTypeRepository, AccountTypeRepository>();
            services.AddTransient<IAccountTypeService, AccountTypeService>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentService, PaymentService>();
        }
    }
}
