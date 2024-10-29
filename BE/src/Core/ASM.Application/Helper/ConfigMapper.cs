using ASM.Core.BindingModels.Category;
using ASM.Core.DTOs.Category;
using ASM.Core.Entities;
using AutoMapper;

namespace ASM.WebApi.Helper;

public class ConfigMapper : Profile
{
    public ConfigMapper()
    {
        
    }

    private void CategoryConfiguration()
    {
        CreateMap<AddCategoryBindingModel, Category>();
        CreateMap<UpdateCategoryBindingModel, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest)=> src.Name ?? dest.Name));
        CreateMap<Category, CategoryResponseDTO>();
    }
}
