using API.Models;
using BusinessLogic.DTO;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TagsController(ITagService tagService) : ControllerBase
    {
        // GET: api/Tags/All
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetTags()
        {
            try
            {
                var tags = await tagService.GetTags();
                return Ok(tags);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<TableViewModel<TagDto>>> GetTags([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Name", [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var tags = await tagService.GetTagsWithCount(filter, page, pageSize, sortField, sortOrder);
                var tableViewModel = new TableViewModel<TagDto>
                {
                    Data = tags.Item1,
                    TotalCount = tags.Item2,
                };
                return Ok(tableViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Tags/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(string id)
        {
            try
            {
                var tag = await tagService.GetTagById(id);

                if (tag == null)
                {
                    return NotFound("Tag not found.");
                }

                return Ok(tag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Tags
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTag([FromBody] TagDto tag)
        {
            try
            {
                await tagService.CreateTag(tag);
                return StatusCode(201, "Tag created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Tags
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTag([FromBody] TagDto tag)
        {
            try
            {
                await tagService.UpdateTag(tag);
                return Ok("Tag updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Tags/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTag(string id)
        {
            try
            {
                await tagService.DeleteTag(id);
                return Ok("Tag deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
