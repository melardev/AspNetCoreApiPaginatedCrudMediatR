using ApiCrudPaginationMediatR.Entities;
using MediatR;

namespace ApiCrudPaginationMediatR.Commands
{
    public class GetTodoCommand : IRequest<Todo>
    {
        public long Id { get; set; }
    }
}