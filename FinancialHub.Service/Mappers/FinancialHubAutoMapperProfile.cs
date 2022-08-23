using AutoMapper;
using FinancialHub.Domain.Entities;
using FinancialHub.Domain.Filters;
using FinancialHub.Domain.Models;
using FinancialHub.Domain.Queries;

namespace FinancialHub.Service.Mappers
{
    public class FinancialHubAutoMapperProfile : Profile
    {
        public FinancialHubAutoMapperProfile()
        {
            //map entities
            CreateMap<AccountEntity, AccountModel>().ReverseMap();
            CreateMap<CategoryEntity, CategoryModel>().ReverseMap();
            CreateMap<TransactionEntity, TransactionModel>().ReverseMap();
            CreateMap<BalanceEntity, BalanceModel>().ReverseMap();

            //map da querie
            CreateMap<TransactionFilter, TransactionQuery>().ReverseMap();
        }
    }
}
