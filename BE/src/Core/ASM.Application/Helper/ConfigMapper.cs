using ASM.Core.BindingModels.Asset;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.BindingModels.Category;
using ASM.Core.BindingModels.Depreciation;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Asset;
using ASM.Core.DTOs.Category;
using ASM.Core.DTOs.Depreciation;
using ASM.Core.DTOs.Image;
using ASM.Core.DTOs.Request;
using ASM.Core.DTOs.User;
using ASM.Core.Entities;
using AutoMapper;

namespace ASM.WebApi.Helper
{
    public class ConfigMapper : Profile
    {
        public ConfigMapper()
        {
            AssetConfiguration();
            AssetTypeConfiguration();
            CategoryConfiguration();
            DepreciationConfiguration();
            LoanRequestConfiguration();
            UserConfiguration();
        }

        private void AssetConfiguration()
        {
            CreateMap<Asset, AssetBindingModel>();
            CreateMap<CreateAssetBindingModel, Asset>();
            CreateMap<UpdateAssetBindingModel, Asset>()
                .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
                .ForMember(x => x.SerialNumber, opt => opt.MapFrom((src, dest) => src.SerialNumber ?? dest.SerialNumber))
                .ForMember(x => x.Condition, opt => opt.MapFrom((src, dest) => src.Condition ?? dest.Condition))
                .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status))
                .ForMember(x => x.AssetTypeId, opt => opt.MapFrom((src, dest) => src.AssetTypeId ?? dest.AssetTypeId));
            CreateMap<Asset, AssetResponseDTO>()
                .ForMember(x => x.AssetImages, opt => opt.MapFrom(src => src.Images.Select(x => new ImageResponseDTO
                {
                    Id = x.Id,
                    Url = x.ImageUrl
                })));
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
                .ForMember(x => x.Category, opt => opt.MapFrom(src => new CategoryResponseDTO
                {
                    Id = src.CategoryId,
                    Name = src.Category.Name,
                    Description = src.Category.Description
                }))
                .ReverseMap();
        }

        private void CategoryConfiguration()
        {
            CreateMap<AddCategoryBindingModel, Category>();
            CreateMap<UpdateCategoryBindingModel, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name));
            CreateMap<Category, CategoryResponseDTO>();
        }

        private void DepreciationConfiguration()
        {
            CreateMap<UpdateDepreciationBindingModel, Depreciation>();
            CreateMap<Depreciation, DepreciationResponseDTO>();
        }

        private void LoanRequestConfiguration()
        {
            CreateMap<LoanRequest, LoanerRequestReponseDTO>();
            CreateMap<LoanRequestDetail, LoanRequestDetailResponseDTO>();

            CreateMap<CreateLoanRequestBindingModel, LoanRequest>();
            CreateMap<CreateLoanRequestDetailBindingModel, LoanRequestDetail>();
            CreateMap<UpdateLoanerRequestBindingModel, LoanRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => dest.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom((src, dest) => src.Status ?? dest.Status))
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom((src, dest) => src.IsApproved ?? dest.IsApproved));
        }

        private void UserConfiguration()
        {
            CreateMap<ApplicationUser, UserResponseDTO>().ReverseMap();
        }
    }
}
