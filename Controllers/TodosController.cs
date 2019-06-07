using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Commands;
using ApiCrudPaginationMediatR.Dtos.Responses.Todos;
using ApiCrudPaginationMediatR.Entities;
using ApiCrudPaginationMediatR.Enums;
using ApiCrudPaginationMediatR.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudPaginationMediatR.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _mediator.Send(new GetTodosCommand
            {
                Page = page, PageSize = pageSize
            });
            return StatusCodeAndDtoWrapper.BuildSuccess(TodoListResponse.Build(result.Item2, Request.Path, page,
                pageSize, result.Item1));
        }

        [HttpGet]
        [Route("pending")]
        public async Task<IActionResult> GetPending([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _mediator.Send(new GetTodosCommand
            {
                Page = page,
                PageSize = pageSize,
                Completed = false
            });
            return StatusCodeAndDtoWrapper.BuildSuccess(TodoListResponse.Build(result.Item2, Request.Path, page,
                pageSize, result.Item1));
        }

        [HttpGet]
        [Route("completed")]
        public async Task<IActionResult> GetCompleted([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _mediator.Send(new GetTodosCommand
            {
                Page = page,
                PageSize = pageSize,
                Completed = true
            });
            return StatusCodeAndDtoWrapper.BuildSuccess(TodoListResponse.Build(result.Item2, Request.Path, page,
                pageSize, result.Item1));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTodoDetails(int id)
        {
            var todo = await _mediator.Send(new GetTodoCommand {Id = id});
            if (todo == null)
                return StatusCodeAndDtoWrapper.BuildNotFound(id);

            return StatusCodeAndDtoWrapper.BuildSuccess(TodoDetailsDto.Build(todo));
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
        {
            var command = new CreateTodoCommand
            {
                Title = todo.Title,
                Description = todo.Description
            };

            var persistedTodo = await _mediator.Send(command);

            return StatusCodeAndDtoWrapper.BuildSuccess(TodoDetailsDto.Build(persistedTodo),
                "Todo Created Successfully");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] Todo todo)
        {
            var todoFromDb = await _mediator.Send(new GetTodoCommand {Id = id});
            if (todoFromDb == null)
                return StatusCodeAndDtoWrapper.BuildNotFound(id);

            var updatedTodo = await _mediator.Send(new UpdateTodoCommand
                {TodoFromDb = todoFromDb, UpdatedTodo = todo});

            return StatusCodeAndDtoWrapper.BuildSuccess(TodoDetailsDto.Build(updatedTodo),
                "Todo Updated Successfully");
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todoFromDb = await _mediator.Send(new GetTodoCommand {Id = id});
            if (todoFromDb == null)
                return StatusCodeAndDtoWrapper.BuildNotFound(id);

            var success = await _mediator.Send(new DeleteTodoCommand {Id = id});

            return StatusCodeAndDtoWrapper.BuildSuccess("Todo Deleted Successfully");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            var success = await _mediator.Send(new DeleteAllTodosCommand());
            return StatusCodeAndDtoWrapper.BuildSuccess("Todos Deleted Successfully");
        }
    }
}