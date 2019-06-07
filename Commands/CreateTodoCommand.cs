using ApiCrudPaginationMediatR.Entities;
using MediatR;

namespace ApiCrudPaginationMediatR.Commands
{
    public class CreateTodoCommand : IRequest<Todo>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}