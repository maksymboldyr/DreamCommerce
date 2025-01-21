using BusinessLogic.DTO;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Domain
{
    /// <summary>
    /// Service for managing tags and tag values.
    /// </summary>
    public class TagService(
        UnitOfWork unitOfWork,
        FilterBuilderService filterBuilderService,
        SortingService<TagDto> tagSortingService,
        SortingService<TagValueDto> tagValueSortingService) : ITagService
    {
        /// <summary>
        /// Creates a new tag.
        /// </summary>
        /// <param name="tagDto">The tag data transfer object.</param>
        public async Task CreateTag(TagDto tagDto)
        {
            var tag = tagDto.Adapt<Tag>();
            await unitOfWork.TagRepository.InsertAsync(tag);
        }

        /// <summary>
        /// Creates a new tag value.
        /// </summary>
        /// <param name="tagValueDto">The tag value data transfer object.</param>
        public async Task CreateTagValue(TagValueDto tagValueDto)
        {
            var tagValue = tagValueDto.Adapt<TagValue>();
            await unitOfWork.TagValueRepository.InsertAsync(tagValue);
        }

        /// <summary>
        /// Deletes a tag by its identifier.
        /// </summary>
        /// <param name="id">The tag identifier.</param>
        public async Task DeleteTag(string id)
        {
            var tagValues = await unitOfWork.TagValueRepository.GetAsync(filter: tv => tv.TagId == id);
            foreach (var tagValue in tagValues)
            {
                await unitOfWork.TagValueRepository.DeleteAsync(tagValue.Id);
            }
            await unitOfWork.TagRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Deletes a tag value by its identifier.
        /// </summary>
        /// <param name="id">The tag value identifier.</param>
        public async Task DeleteTagValue(string id)
        {
            await unitOfWork.TagValueRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Gets all tags.
        /// </summary>
        /// <returns>Collection of <see cref="TagDto"/> objects.</returns>
        public async Task<IEnumerable<TagDto>> GetTags()
        {
            var tags = await unitOfWork.TagRepository.GetAsync();

            var tagDtos = tags.Adapt<IEnumerable<TagDto>>();

            //TODO: Refactor this to use a join query and configure Mapster to handle it.
            foreach (var tagDto in tagDtos)
            {
                var subcategory = await unitOfWork.SubcategoryRepository.GetByIdAsync(tagDto.SubcategoryId);
                tagDto.SubcategoryName = subcategory.Name;
            }

            return tagDtos;
        }

        /// <summary>
        /// Gets tags by given filter with pagination and sorting.
        /// </summary>
        /// <param name="filter">The filter string.</param>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The field to sort by.</param>
        /// <param name="sortOrder">The sort order (asc/desc).</param>
        /// <returns>Filtered, ordered and paginated collection of <see cref="TagDto"/> objects and total count of filtered out tags, before pagination is applied.</returns>
        public async Task<(IEnumerable<TagDto>, int)> GetTagsWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
        {
            var filterExpression = filterBuilderService.BuildFilter<TagDto>(filter);
            var sortingExpression = tagSortingService.GetSortExpression(sortField, sortOrder);

            var tags = await unitOfWork.TagRepository.GetAsync(includeProperties: "TagValues");

            var filteredTags = tags.Adapt<IEnumerable<TagDto>>()
                .Where(u => filterExpression.Compile().Invoke(u))
                .ToList();

            var sortedTags = sortingExpression(filteredTags.AsQueryable());

            var result = sortedTags
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            //TODO: Refactor this to use a join query and configure Mapster to handle it.
            foreach (var tagDto in result)
            {
                var subcategory = await unitOfWork.SubcategoryRepository.GetByIdAsync(tagDto.SubcategoryId);
                tagDto.SubcategoryName = subcategory.Name;
            }

            return (result, filteredTags.Count());
        }

        /// <summary>
        /// Gets tag by id.
        /// </summary>
        /// <param name="id">The tag identifier.</param>
        /// <returns><see cref="TagDto"/> object.</returns>
        public async Task<TagDto> GetTagById(string id)
        {
            var tag = await unitOfWork.TagRepository.GetByIdAsync(id);
            return tag.Adapt<TagDto>();
        }

        /// <summary>
        /// Gets all tag values.
        /// </summary>
        /// <returns>Collection of <see cref="TagValueDto"/> objects.</returns>
        public async Task<IEnumerable<TagValueDto>> GetTagValues()
        {
            var tagValues = await unitOfWork.TagValueRepository.GetAsync(includeProperties: "Tag");
            return tagValues.Adapt<IEnumerable<TagValueDto>>();
        }

        /// <summary>
        /// Gets tag values by given filter with pagination and sorting.
        /// </summary>
        /// <param name="filter">The filter string.</param>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The field to sort by.</param>
        /// <param name="sortOrder">The sort order (asc/desc).</param>
        /// <returns>Filtered, ordered and paginated collection of <see cref="TagValueDto"/> objects and total count of filtered tag values, before pagination is applied.</returns>
        public async Task<(IEnumerable<TagValueDto>, int)> GetTagValuesWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
        {
            var filterExpression = filterBuilderService.BuildFilter<TagValueDto>(filter);
            var sortingExpression = tagValueSortingService.GetSortExpression(sortField, sortOrder);

            var tagValues = await unitOfWork.TagValueRepository.GetAsync(includeProperties: "Tag");

            var filteredTagValues = tagValues.Adapt<IEnumerable<TagValueDto>>()
                .Where(u => filterExpression.Compile().Invoke(u))
                .ToList();

            var sortedTagValues = sortingExpression(filteredTagValues.AsQueryable());

            var result = sortedTagValues
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            //TODO: Refactor this to use a join query and configure Mapster to handle it.
            foreach (var tagValueDto in result)
            {
                var tag = await unitOfWork.TagRepository.GetByIdAsync(tagValueDto.TagId);
                tagValueDto.TagName = tag.Name;

                var subcategory = await unitOfWork.SubcategoryRepository.GetByIdAsync(tag.SubcategoryId);
                tagValueDto.SubcategoryName = subcategory.Name;
            }

            return (result, filteredTagValues.Count());
        }

        /// <summary>
        /// Gets tag value by id.
        /// </summary>
        /// <param name="id">The tag value identifier.</param>
        /// <returns><see cref="TagValueDto"/> object.</returns>
        public async Task<TagValueDto> GetTagValueById(string id)
        {
            var tagValue = await unitOfWork.TagValueRepository.GetByIdAsync(id);
            return tagValue.Adapt<TagValueDto>();
        }

        /// <summary>
        /// Updates a tag.
        /// </summary>
        /// <param name="tagDto">The tag data transfer object.</param>
        public async Task UpdateTag(TagDto tagDto)
        {
            var tag = tagDto.Adapt<Tag>();
            unitOfWork.TagRepository.Update(tag);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Updates a tag value.
        /// </summary>
        /// <param name="tagValueDto">The tag value data transfer object.</param>
        public Task UpdateTagValue(TagValueDto tagValueDto)
        {
            var tagValue = tagValueDto.Adapt<TagValue>();
            unitOfWork.TagValueRepository.Update(tagValue);
            return Task.CompletedTask;
        }
    }
}
