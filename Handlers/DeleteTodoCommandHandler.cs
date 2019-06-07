using System.Threading;
using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Commands;
using ApiCrudPaginationMediatR.Infrastructure.Services;
using MediatR;

namespace ApiCrudPaginationMediatR.Handlers
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly TodoService _todoService;

        public DeleteTodoCommandHandler(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await _todoService.Delete(request.Id);
            return true;
        }
    }
}