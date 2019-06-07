using MediatR;

namespace ApiCrudPaginationMediatR.Commands
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}