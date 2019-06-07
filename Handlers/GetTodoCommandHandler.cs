using System.Threading;
using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Commands;
using ApiCrudPaginationMediatR.Entities;
using ApiCrudPaginationMediatR.Infrastructure.Services;
using MediatR;

namespace ApiCrudPaginationMediatR.Handlers
{
    // This handler handles GetTodoCommand and returns a Task<Todo>
    public class GetTodoCommandHandler : IRequestHandler<GetTodoCommand, Todo>
    {
        private readonly TodoService _todoService;

        public GetTodoCommandHandler(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<Todo> Handle(GetTodoCommand request, CancellationToken cancellationToken)
        {
            return await _todoService.GetById((int) request.Id);
        }
    }
}