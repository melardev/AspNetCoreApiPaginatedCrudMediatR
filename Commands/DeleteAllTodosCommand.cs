using MediatR;

namespace ApiCrudPaginationMediatR.Commands
{
    public class DeleteAllTodosCommand : IRequest<bool>
    {
    }
}