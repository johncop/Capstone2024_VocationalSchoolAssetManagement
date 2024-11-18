using ASM.Core.BindingModels.Asset;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.BindingModels.Category;
using ASM.Core.BindingModels.Depreciation;
using ASM.Core.BindingModels.Inventory;
using ASM.Core.DTOs.Asset;
using ASM.Core.DTOs.Category;
using ASM.Core.DTOs.Depreciation;
using ASM.Core.DTOs.Inventory;
using ASM.Core.Entities;
using AutoMapper;

namespace ASM.WebApi.Helper;

public class ConfigMapper : Profile
{
    public ConfigMapper()
    {
        AssetConfiguration();
        AssetTypeConfiguration();
        CategoryConfiguration();
        DepreciationConfiguration();
        InventoryConfiguration();
    }

    private void AssetConfiguration()
    {
        CreateMap<Asset, AssetBindingModel>();
        CreateMap<CreateAssetBindingModel, Asset>();
        CreateMap<UpdateAssetBindingModel, Asset>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src,dest) => src.Name ?? dest.Name))
            .ForMember(x => x.SerialNumber, opt => opt.MapFrom((src, dest) => src.SerialNumber ?? dest.SerialNumber))
            .ForMember(x => x.Condition, opt => opt.MapFrom((src, dest) => src.Condition ?? dest.Condition))
            .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status))
            .ForMember(x => x.AssetTypeId, opt => opt.MapFrom((src, dest) => src.AssetTypeId ?? dest.AssetTypeId));
        CreateMap<Asset, AssetResponseDTO>();
    }

    private void AssetTypeConfiguration()
    {
        CreateMap<CreateAssetTypeBindingModel, AssetType>();
        CreateMap<UpdateAssetTypeBindingModel, AssetType>()
            .ForMember(x => x.Id, opt => opt.MapFrom((src, dest) => dest.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description))
            .ForMember(x => x.Quantity, opt => opt.MapFrom((src, dest) => src.Quantity ?? dest.Quantity));
        CreateMap<AssetType, AssetTypeResponseDTO>()
            .ForMember(x => x.Category, opt => opt.MapFrom(src => new CategoryResponseDTO()
            {
                Id = src.CategoryId,
                Name = src.Category.Name,
                Description =  src.Category.Description,
            }))
            .ReverseMap();
    }

    private void CategoryConfiguration()
    {
        CreateMap<AddCategoryBindingModel, Category>();
        CreateMap<UpdateCategoryBindingModel, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest)=> src.Name ?? dest.Name));
        CreateMap<Category, CategoryResponseDTO>();
    }

    private void DepreciationConfiguration()
    {
        CreateMap<UpdateDepreciationBindingModel, Depreciation>();
        CreateMap<Depreciation, DepreciationResponseDTO>();
    }

    private void InventoryConfiguration()
    {
        CreateMap<Inventory, InventoryResponseDTO>().ReverseMap();
        CreateMap<UpdateInventoryBindingModel, Inventory>();
    }
}
