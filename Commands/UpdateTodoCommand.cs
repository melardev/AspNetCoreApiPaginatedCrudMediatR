using ApiCrudPaginationMediatR.Entities;
using MediatR;

namespace ApiCrudPaginationMediatR.Commands
{
    public class UpdateTodoCommand : IRequest<Todo>
    {
        public Todo TodoFromDb { get; set; }
        public Todo UpdatedTodo { get; set; }
    }
}