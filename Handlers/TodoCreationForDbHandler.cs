using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Commands;
using ApiCrudPaginationMediatR.Entities;
using ApiCrudPaginationMediatR.Infrastructure.Services;
using MediatR;

namespace ApiCrudPaginationMediatR.Handlers
{
    public class TodoCreationForDbHandler : IRequestHandler<CreateTodoCommand, Todo>
    {
        private readonly TodoService _todoService;

        public TodoCreationForDbHandler(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo {Title = request.Title, Description = request.Description};
            await _todoService.CreateTodo(todo);
            Debug.WriteLine("Todo added successfully");
            return todo;
        }
    }
}