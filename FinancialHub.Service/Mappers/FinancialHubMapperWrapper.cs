using AutoMapper;
using FinancialHub.Domain.Interfaces.Mappers;

namespace FinancialHub.Service.Mappers
{
    public class FinancialHubMapperWrapper : IMapperWrapper
    {
        private readonly IMapper _mapper;

        public FinancialHubMapperWrapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Y Map<T, Y>(T ent)
        {
            return _mapper.Map<T, Y>(ent);
        }

        public Y Map<Y>(object ent)
        {
            return _mapper.Map<Y>(ent);
        }
    }
}
