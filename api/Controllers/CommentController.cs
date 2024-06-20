using api.Dto.Comments;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController(ICommentRepository commentRepository, IStockRepository stockRepository) : ControllerBase
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IStockRepository _stockRepository = stockRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(x => x.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetById(id);
            return Ok(comment?.ToCommentDto());

        }

        [HttpPost("{StockId}")]
        public async Task<IActionResult> CreateComment([FromRoute] int StockId, CreateCommentDto createCommentDto)
        {
            if (!await _stockRepository.StockExists(StockId))
            {
                return BadRequest("stock does not exists");
            }
            var commentModel = createCommentDto.ToCommentFromCreate(StockId);
            await _commentRepository.CreateComment(commentModel);
            return CreatedAtAction(nameof(GetCommentById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateCommentRequestDto)
        {
            var comment = await _commentRepository.UpdateComment(id, updateCommentRequestDto.ToCommentFromUpdate());
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleComment([FromRoute]int id)
        {
            var comment = await _commentRepository.DeleteComment(id);
            if(comment == null){
                return NotFound();
            }
            return Ok(comment);
        }
    }
}