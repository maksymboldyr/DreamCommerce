using BusinessLogic.DTO;
using BusinessLogic.DTO.Catalogue;

namespace BusinessLogic.Interfaces
{
    public interface ITagService
    {
        Task CreateTag(TagDto tagDto);
        Task CreateTagValue(TagValueDto tagValueDto);
        Task DeleteTag(string id);
        Task DeleteTagValue(string id);
        Task<TagDto> GetTagById(string id);
        Task<IEnumerable<TagDto>> GetTags();
        Task<(IEnumerable<TagDto>, int)> GetTagsWithCount(string filter, int page, int pageSize, string sortField, string sortOrder);
        Task<TagValueDto> GetTagValueById(string id);
        Task<IEnumerable<TagValueDto>> GetTagValues();
        Task<(IEnumerable<TagValueDto>, int)> GetTagValuesWithCount(string filter, int page, int pageSize, string sortField, string sortOrder);
        Task UpdateTag(TagDto tagDto);
        Task UpdateTagValue(TagValueDto tagValueDto);
    }
}