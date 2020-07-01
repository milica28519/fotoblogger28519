using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Queries;
using Fotoblogger.Application.Searches;
using Fotoblogger.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fotoblogger.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public readonly UseCaseExecutor _executor;

        public PostsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<PostController>d
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearch search, [FromServices] IGetPostsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPostQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<PostController>
        [HttpPost]
        public IActionResult Post([FromForm] CreatePostDto request, [FromServices] ICreatePostCommand command)
        {
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditPostDto request, [FromServices] IEditPostCommand command)
        {
            request.Id = id;
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // COMMENTS for post

        // GET api/<PostController>/5/comments
        [HttpGet("{id}/comments")]
        public IActionResult GetCommentsForPost(int id, PostCommentSearch search, [FromServices] IGetPostCommentsQuery query)
        {
            search.PostId = id;
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<PostController>/5/comments
        [HttpGet("{id}/comments/{commentId}/replies")]
        public IActionResult GetRepliesForComment(int id, int commentId, [FromQuery] PostCommentRepliesSearch search, [FromServices] IGetPostCommentRepliesQuery query)
        {
            search.PostId = id;
            search.CommentId = commentId;
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<PostController>/5/comments/add
        [HttpPost("{id}/comments/add")]
        public IActionResult AddComment(int id, [FromBody] CreatePostCommentDto request, [FromServices] ICreatePostCommentCommand command)
        {
            request.PostId = id;
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}/comments/{commentId}/edit")]
        public IActionResult Put(int id, int commentId, [FromBody] EditPostCommentDto request, [FromServices] IEditPostCommentCommand command)
        {
            request.PostId = id;
            request.Id = commentId;
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}/comments/{commentId}/delete")]
        public IActionResult Delete(int id, int commentId, [FromServices] IDeletePostCommentCommand command)
        {
            _executor.ExecuteCommand(command, new DeletePostCommentDto { PostId = id, Id = commentId });
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // POST api/<PostController>/5/comments/add
        [HttpPost("{id}/comments/{commentId}/upvote")]
        public IActionResult UpvoteComment(int id, int commentId, [FromServices] IAddCommentVoteCommand command)
        {
            var request = new UserCommentVoteDto
            {
                CommentId = commentId,
                CommentVote = CommentVote.Upvote
            };
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST api/<PostController>/5/comments/add
        [HttpPost("{id}/comments/{commentId}/downvote")]
        public IActionResult DownvoteComment(int id, int commentId, [FromServices] IAddCommentVoteCommand command)
        {
            var request = new UserCommentVoteDto
            {
                CommentId = commentId,
                CommentVote = CommentVote.Downvote
            };
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST api/<PostController>/5/comments/add
        [HttpDelete("{id}/comments/{commentId}/undoVote")]
        public IActionResult UndoVoteComment(int commentId, [FromServices] IRemoveCommentVoteCommand command)
        {
            _executor.ExecuteCommand(command, commentId);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
