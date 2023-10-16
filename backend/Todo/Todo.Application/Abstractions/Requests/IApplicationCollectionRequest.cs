using MediatR;
using Todo.Application.ResultPattern;

namespace Todo.Application.Abstractions.Requests;

public interface IApplicationCollectionRequest<TResponse> : IRequest<HandlerResult<IReadOnlyList<TResponse>>> { }