using API.Models;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TagValuesController(ITagService tagService) : ControllerBase
    {
        // GET: api/TagValues/All
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<TagValueDto>>> GetTagValues()
        {
            try
            {
                var tagValues = await tagService.GetTagValues();
                return Ok(tagValues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/TagValues
        [HttpGet]
        public async Task<ActionResult<TableViewModel<TagValueDto>>> GetTagValues([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Value", [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var tagValues = await tagService.GetTagValuesWithCount(filter, page, pageSize, sortField, sortOrder);
                var tableViewModel = new TableViewModel<TagValueDto>
                {
                    Data = tagValues.Item1,
                    TotalCount = tagValues.Item2,
                };
                return Ok(tableViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/TagValues/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagValue(string id)
        {
            try
            {
                var tagValue = await tagService.GetTagValueById(id);

                if (tagValue == null)
                {
                    return NotFound("Tag value not found.");
                }

                return Ok(tagValue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/TagValues
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTagValue([FromBody] TagValueDto tagValue)
        {
            try
            {
                await tagService.CreateTagValue(tagValue);
                return StatusCode(201, "Tag value created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/TagValues
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTagValue([FromBody] TagValueDto tagValue)
        {
            try
            {
                await tagService.UpdateTagValue(tagValue);
                return Ok("Tag value updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/TagValues/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTagValue(string id)
        {
            try
            {
                await tagService.DeleteTagValue(id);
                return Ok("Tag value deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
