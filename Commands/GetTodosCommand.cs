using System;
using System.Collections.Generic;
using ApiCrudPaginationMediatR.Entities;
using MediatR;

namespace ApiCrudPaginationMediatR.Commands
{
    public class GetTodosCommand : IRequest<Tuple<int, List<Todo>>>
    {
        public bool? Completed { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}