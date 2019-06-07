using ApiCrudPaginationMediatR.Models;

namespace ApiCrudPaginationMediatR.Dtos.Responses.Shared
{
    public abstract class PagedDto : SuccessResponse
    {
        public PageMeta PageMeta { get; set; }
    }
}