using ASM.Core.BindingModels.Asset;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.BindingModels.Category;
using ASM.Core.BindingModels.Department;
using ASM.Core.BindingModels.Depreciation;
using ASM.Core.BindingModels.Location;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Asset;
using ASM.Core.DTOs.Category;
using ASM.Core.DTOs.Department;
using ASM.Core.DTOs.Depreciation;
using ASM.Core.DTOs.Image;
using ASM.Core.DTOs.Location;
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
            LocationConfiguration();
            DeparmentConfiguration();
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
                .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status))
                .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description))
                .ForMember(x => x.AssetTypeId, opt => opt.MapFrom((src, dest) => src.AssetTypeId ?? dest.AssetTypeId))
            .ForMember(x => x.LocationId, opt => opt.MapFrom((src, dest) => src.LocationId ?? dest.LocationId))
            .ForMember(x => x.DepartmentId, opt => opt.MapFrom((src, dest) => src.DepartmentId ?? dest.DepartmentId));
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
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description));
            CreateMap<Category, CategoryResponseDTO>();
        }
        private void LocationConfiguration()
        {
            CreateMap<AddLocationBindingModel, Location>();
            CreateMap<UpdateLocationBindingModel, Location>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description))
            .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status));
            CreateMap<Location, LocationResponseDTO>();
        }
        private void DeparmentConfiguration()
        {
            CreateMap<AddDepartmentBindingModel, Department>();
            CreateMap<UpdateDepartmentBindingModel, Department>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description))
            .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status));
            CreateMap<Department, DepartmentResponseDTO>();
        }
        private void DepreciationConfiguration()
        {
            CreateMap<UpdateDepreciationBindingModel, Depreciation>();
            CreateMap<Depreciation, DepreciationResponseDTO>();
        }

        private void LoanRequestConfiguration()
        {
            CreateMap<Request, RequestResponseDTO>()
                .ForMember(x => x.Details, opt => opt.MapFrom(src => src.RequestDetails.Select(x => new RequestDetailResponseDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    AssetName = x.Asset.Name,
                    ReturnDate = x.ReturnDate,
                    ActualReturnDate = x.ActualReturnDate,
                }).ToList()));
            CreateMap<RequestDetail, RequestDetailResponseDTO>();

            CreateMap<CreateRequestBindingModel, Request>();
            CreateMap<CreateRequestDetailBindingModel, RequestDetail>();
            CreateMap<UpdateRequestBindingModel, Request>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => dest.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom((src, dest) => src.Status ?? dest.Status));
        }

        private void UserConfiguration()
        {
            CreateMap<ApplicationUser, UserResponseDTO>().ReverseMap();
        }
    }
}
