using MediatR;
using Todo.Application.ResultPattern;

namespace Todo.Application.Abstractions.Requests;

public interface IApplicationRequest<TResponse> :  IRequest<HandlerResult<TResponse>> { }