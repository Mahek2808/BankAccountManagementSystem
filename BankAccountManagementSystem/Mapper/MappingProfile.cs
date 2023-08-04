using AutoMapper;
using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BankAccount, BankAccountResponse>().ReverseMap();
            CreateMap<AccountType, AccountTypeResponse>().ReverseMap();
            CreateMap<BankAccountPostingDetail,BankAccountPostingDetailResponse>().ReverseMap();
            CreateMap<BankTransaction, BankTransactionResponse>().ReverseMap();
            CreateMap<BaseModelId, BaseModelIdResponse>().ReverseMap();
            CreateMap<BaseModelName, BaseModelNameResponse>().ReverseMap();
            CreateMap<BaseModelUserFullName, BaseModelUseFullNameResponse>().ReverseMap();
            CreateMap<Payment, PaymentResponse>().ReverseMap();
        }
    }
}
