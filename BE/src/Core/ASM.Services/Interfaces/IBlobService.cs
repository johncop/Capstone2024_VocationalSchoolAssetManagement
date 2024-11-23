using Microsoft.AspNetCore.Http;

namespace ASM.Services.Interfaces;

public interface IBlobService
{
    public Task<string> UploadImage(IFormFile file);
    public Task<bool> DeleteASync(IFormFile file);
}
