using MediatR;
using Todo.Application.Abstractions.Requests;
using Todo.Application.ResultPattern;

namespace Todo.Application.Abstractions.Handlers;

public interface IApplicationCollectionHandler<in TRequest, TResponse> : IRequestHandler<TRequest, HandlerResult<IReadOnlyList<TResponse>>>
    where TRequest : IApplicationCollectionRequest<TResponse> { }    