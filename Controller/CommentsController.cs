using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _service;

        public CommentsController(CommentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Comment comment)
        {
            await _service.AddAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _service.GetByIdAsync(id);
            if (comment == null)
                return NotFound();

            return Ok(comment);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            await _service.UpdateCommentAsync(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _service.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
