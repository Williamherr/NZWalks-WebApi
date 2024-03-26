using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Image;
using NZWalks.API.Repository.ImageRepository;

namespace NZWalks.API.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
          
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {

                // convert DTO to domain model
               var imageDomainModel = new Image
               {
                   File = request.File,
                   FileExtension = Path.GetExtension(request.File.FileName),
                   FileName = request.FileName,
                   FileDescription = request.FileDescription,
                   FileSizeInBytes = request.File.Length,
               };

                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtenstions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtenstions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more than 10MB. Please upload a smaller image.");

            }
        }
    }
}
