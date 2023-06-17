using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Controllers
{
    [Route("api/contentmanagement")]
    [ApiController]
    public class ContentManagementController : ControllerBase
    {
        private readonly IContentManagementRepository contentManagementRepository;

        public ContentManagementController(IContentManagementRepository contentManagementRepository)
        {
            this.contentManagementRepository = contentManagementRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ContentManagementDto>> Get()
        {
            try
            {
                ContentManagementDto contentManagementDto = await contentManagementRepository.Get();
                return Ok(contentManagementDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            } 
        }

        [HttpPost]
        public async Task<ActionResult> CreateorUpdate([FromForm] ContentManagementRequest entityModel)
        {
            try
            {
                await contentManagementRepository.CreateorUpdate(entityModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
