using System.Security.Claims;
using AutoMapper;
using AMS.Core._Repositories.Interfaces;

namespace AMS.Core._Services
{
    public class BaseServices
    {
        protected readonly IRepositoryAccessor _accessorServices;
        protected readonly MapperConfiguration _mapperConfiguration;
        protected readonly IMapper _mapper;
        public BaseServices(IRepositoryAccessor accessorServices, MapperConfiguration mapperConfiguration, IMapper mapper)
        {
            _accessorServices = accessorServices;
            _mapperConfiguration = mapperConfiguration;
            _mapper = mapper;
        }
    }
}