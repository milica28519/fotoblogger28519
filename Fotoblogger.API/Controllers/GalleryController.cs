using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Queries;
using Fotoblogger.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fotoblogger.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        public readonly UseCaseExecutor _executor;

        public GalleryController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<GalleryController>d
        [HttpGet]
        public IActionResult Get([FromQuery] PhotoSearch search, [FromServices] IGetPhotosQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<GalleryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPhotoQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // PATCH api/<GalleryController>/scorePhoto
        [HttpPatch("{photoId}/score")]
        public IActionResult ScorePhoto(int photoId, [FromBody] ScorePhotoDto dto, [FromServices] IScorePhotoCommand command)
        {
            dto.PhotoId = photoId;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // PATCH api/<GalleryController>/scorePhoto
        [HttpPatch("{photoId}/removeScore")]
        public IActionResult ScorePhoto(int photoId, [FromServices] IRemovePhotoScoreCommand command)
        {
            _executor.ExecuteCommand(command, photoId);
            return NoContent();
        }
    }
}
