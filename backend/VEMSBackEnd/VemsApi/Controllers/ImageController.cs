using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using VemsApi.Dto.ImageDto;

namespace VemsApi.Controllers
{
    [ApiController]
    [Route("api/image")]

    public class ImageController : Controller
    {

        [HttpPost("/delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                var a = ImageExtension.Delete(id);
                return APIResponse.Success(a);
            }

            catch (Exception e)
            {
                return APIResponse.Error(null, e.Message);
            }
        }

        [HttpPost("/edit")]
        public IActionResult Edit(string id, IFormFile file)
        {
            try
            {
                var a = ImageExtension.Edit(id, file);
                return APIResponse.Success(a);
            }

            catch (Exception e)
            {
                return APIResponse.Error(null, e.Message);
            }
        }

        [HttpPost("/upload")]
        public IActionResult UploadMultiple(IFormFile file)
        {
            try
            {
                var a = ImageExtension.UploadFile(file);
                return APIResponse.Success(a);
            }

            catch (Exception e)
            {
                return APIResponse.Error(null, e.Message);
            }
        }
    }
}
