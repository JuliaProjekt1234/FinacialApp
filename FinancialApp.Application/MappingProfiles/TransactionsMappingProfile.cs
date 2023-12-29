using AutoMapper;
using FinancialApp.Application.Queries.Dtos;
using FinancialApp.Domain;

namespace FinancialApp.Application.MappingProfiles;

public class TransactionsMappingProfile : Profile
{
    public TransactionsMappingProfile()
    {
        CreateMap<Transaction, TransactionToAddDto>();
        CreateMap<TransactionToAddDto, Transaction>()
            .ForMember(dst => dst.TransationDate, opt => opt.MapFrom(src => DateTime.Now));


        CreateMap<Transaction, TransactionDto>().ReverseMap();

    }
}
