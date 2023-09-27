using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Packages.Storage.AWS3.Services;

namespace Workneering.Geteway.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/files")]
    public class FilesController : BaseController
    {
        private readonly IStorageService _storageService;

        public FilesController(ISender mediator, IStorageService storageService) : base(mediator)
        {
            _storageService = storageService;
        }
        [HttpGet("{id}/download")]
        public async Task<ActionResult> DownloadFile([FromRoute] string id)
        {
            var result = await _storageService.DownloadFile(id);
            return File(result.Contents, result.ContentType, result.FileName);
        }
    }
}