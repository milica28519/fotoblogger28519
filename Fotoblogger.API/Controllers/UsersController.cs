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
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fotoblogger.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly UseCaseExecutor _executor;

        public UsersController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}/permissions")]
        public IActionResult GetPermissions(int id, [FromServices] IGetUserPermissionsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUserDto request, [FromServices] IEditUserCommand command)
        {
            request.Id = id;
            _executor.ExecuteCommand(command, request);
            return NoContent();
        }

        // PATCH api/<UsersController>/5/setProfilePhoto
        [HttpPatch("{id}/setProfilePhoto")]
        public IActionResult SetProfilePhoto(int id, [FromBody] SetUserProfilePhotoDto request, [FromServices] ISetUserProfilePhotoCommand command)
        {
            request.Id = id;
            _executor.ExecuteCommand(command, request);
            return NoContent();
        }

        // PATCH api/<UsersController>/5/removeProfilePhoto
        [HttpPatch("{id}/removeProfilePhoto")]
        public IActionResult RemoveProfilePhoto(int id, [FromServices] IRemoveUserProfilePhotoCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

        // PATCH api/<UsersController>/5/deactivate
        [HttpPatch("{id}/deactivate")]
        public IActionResult Deactivate(int id, [FromServices] IDeactivateUserCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

        // PATCH api/<UsersController>/5/deactivate
        [AllowAnonymous]
        [HttpPatch("{id}/activate")]
        public IActionResult Activate(int id, [FromBody] ActivateUserDto request, [FromServices] IActivateUserCommand command)
        {
            request.Id = id;
            _executor.ExecuteCommand(command, request);
            return NoContent();
        }

        // PATCH api/<UsersController>/5/deactivate
        [HttpPatch("{id}/changeRole")]
        public IActionResult ChangeRole(int id, [FromBody] ChangeUserRoleDto request, [FromServices] IChangeUserRoleCommand command)
        {
            request.UserId = id;
            _executor.ExecuteCommand(command, request);
            return NoContent();
        }

        // PATCH api/<UsersController>/5/deactivate
        [HttpPatch("{id}/changePermissions")]
        public IActionResult ChangePermissions(int id, [FromBody] ChangeUserUseCasesDto request, [FromServices] IChangeUserUseCasesCommand command)
        {
            request.UserId = id;
            _executor.ExecuteCommand(command, request);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
