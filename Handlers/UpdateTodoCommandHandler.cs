using System.Threading;
using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Commands;
using ApiCrudPaginationMediatR.Entities;
using ApiCrudPaginationMediatR.Infrastructure.Services;
using MediatR;

namespace ApiCrudPaginationMediatR.Handlers
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Todo>
    {
        private readonly TodoService _todoService;

        public UpdateTodoCommandHandler(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<Todo> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            return await _todoService.Update(request.TodoFromDb, request.UpdatedTodo);
        }
    }
}