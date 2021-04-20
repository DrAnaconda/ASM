using System.Threading.Tasks;
using ASM.ApiServices.FilesService.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _filesService;

        public FilesController(
            IFilesService filesService)
        {
            _filesService = filesService;
        }

        [HttpGet("random")]
        public async Task<ActionResult> GetRandomFile()
        {
            var fileBytes = await _filesService.GetRandomFileAsync();
            return base.File(fileBytes, "image/png");
        }

        [HttpGet("levenshtein")]
        public async Task<ActionResult> GetFileByDateWithLevenshteinCurrentDate()
        {
            var fileBytes = await _filesService.GetFileClosestToStringTimeAsync();
            return base.File(fileBytes, "image/png");
        }
    }
}