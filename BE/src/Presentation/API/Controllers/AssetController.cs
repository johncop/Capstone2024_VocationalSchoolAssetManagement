using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Asset;
using ASM.Core.DTOs.Asset;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AssetController : BaseApi
    {
        private readonly IBaseService<Asset> _baseService;
        private readonly IBlobService _blobService;

        public AssetController(IBaseService<Asset> baseService, IMapper mapper, IBlobService blobService) : base(mapper)
        {
            _baseService = baseService;
            _blobService = blobService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return Success(data: await _baseService.GetAllAsync<AssetResponseDTO>());
        }

        [HttpGet("{id:int}")]
        public async Task<IResponse> Get(int id)
        {
            return Success(
                data: _mapper.Map<AssetResponseDTO>(await _baseService.Find(id).FirstOrDefaultAsync()));
        }

        [HttpPost]
        public async Task<IResponse> Create([FromForm] CreateAssetBindingModel createAssetBindingModel)
        {
            if (createAssetBindingModel is null) return Error("The input is null", HttpStatusCode.BadRequest);

            try
            {
                var asset = _mapper.Map<Asset>(createAssetBindingModel);
                if (createAssetBindingModel.Files is not null && createAssetBindingModel.Files.Count > 0)
                {
                    asset.Images = new List<AssetImage>();
                    var uploadTask = createAssetBindingModel.Files.Select(async file =>
                    {
                        var imageUrl = await _blobService.UploadImage(file);
                        return new AssetImage
                        {
                            ImageUrl = imageUrl,
                            ImageName = file.Name
                        };
                    });
                    asset.Images = (await Task.WhenAll(uploadTask)).ToList();
                }

                var result = await _baseService.Crete(asset);
                return Success(data: _mapper.Map<AssetResponseDTO>(result));
            }
            catch (Exception ex)
            {
                return Error(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateAssetBindingModel updateAssetBindingModel)
        {
            var asset = await _baseService.Find(id).FirstOrDefaultAsync();
            if (asset is null)
            {
                return Error("Asset not found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateAssetBindingModel, asset);
            if (updateAssetBindingModel.Images is not null && updateAssetBindingModel.Images.Count > 0)
            {
                asset.Images = new List<AssetImage>();

            }
            return Success(data: _mapper.Map<AssetResponseDTO>(await _baseService.Update(asset)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message);
        }
    }
}
