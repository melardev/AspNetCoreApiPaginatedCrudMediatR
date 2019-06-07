using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Commands;
using ApiCrudPaginationMediatR.Entities;
using ApiCrudPaginationMediatR.Enums;
using ApiCrudPaginationMediatR.Infrastructure.Services;
using MediatR;

namespace ApiCrudPaginationMediatR.Handlers
{
    public class GetTodosCommandHandler : IRequestHandler<GetTodosCommand, Tuple<int, List<Todo>>>
    {
        private readonly TodoService _todoService;

        public GetTodosCommandHandler(TodoService todosService)
        {
            _todoService = todosService;
        }

        public async Task<Tuple<int, List<Todo>>> Handle(GetTodosCommand request, CancellationToken cancellationToken)
        {
            TodoShow which;

            if (request.Completed != null && request.Completed.Value)
                which = TodoShow.Completed;
            else if (request.Completed != null && !request.Completed.Value)
                which = TodoShow.Pending;
            else
                which = TodoShow.All;

            return await _todoService.FetchMany(request.Page, request.PageSize, which);
        }
    }
}