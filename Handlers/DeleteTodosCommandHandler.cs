using System.Threading;
using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Commands;
using ApiCrudPaginationMediatR.Infrastructure.Services;
using MediatR;

namespace ApiCrudPaginationMediatR.Handlers
{
    public class DeleteTodosCommandHandler : IRequestHandler<DeleteAllTodosCommand, bool>
    {
        private readonly TodoService _todoService;

        public DeleteTodosCommandHandler(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<bool> Handle(DeleteAllTodosCommand request, CancellationToken cancellationToken)
        {
            await _todoService.DeleteAll();
            return true;
        }
    }
}