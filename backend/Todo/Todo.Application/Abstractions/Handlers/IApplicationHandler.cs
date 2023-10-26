using MediatR;
using Todo.Application.Abstractions.Requests;
using Todo.Application.ResultPattern;

namespace Todo.Application.Abstractions.Handlers;

public interface IApplicationHandler<in TRequest, TResponse> : IRequestHandler<TRequest, HandlerResult<TResponse>>
    where TRequest : IApplicationRequest<TResponse> { }