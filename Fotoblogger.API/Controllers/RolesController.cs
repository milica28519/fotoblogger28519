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
    public class RolesController : ControllerBase
    {
        public readonly UseCaseExecutor _executor;

        public RolesController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<RoleController>d
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search, [FromServices] IGetRolesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
        
        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRoleQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoleDto request, [FromServices] ICreateRoleCommand command)
        {
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditRoleDto request, [FromServices] IEditRoleCommand command)
        {
            request.Id = id;
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
