using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Lot, LotDTO>();
            CreateMap<CarBrand, CarBrandDTO>();
            CreateMap<CarModel, CarModelDTO>();
            CreateMap<CarBrandForCreationDTO,CarBrand >();
            CreateMap<CarModelForCreationDTO, CarModel>();
            CreateMap<CarModelForUpdateDTO, CarModel>();
            CreateMap<CarModelForUpdateDTO, CarModel>().ReverseMap();
            CreateMap<CarBrandForUpdateDTO, CarBrand>();
        }
    }
}
