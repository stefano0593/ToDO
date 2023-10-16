using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.API.API.Contracts.ApiErrorResponse;
using Todo.Application.ResultPattern;

namespace Todo.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected IActionResult HandleApiErrorResponse(FailureReason failureReason)
    {
        var apiErrorResponse = new ApiErrorResponse();
        if (failureReason.Errors.Count > 0)
        {
            failureReason.Errors
                .ToList()
                .ForEach(error => apiErrorResponse.AddErrorMessage(error));
        }
        else
        {
            apiErrorResponse.AddErrorMessage(failureReason.ApplicationErrorMessage);
        }

        if (failureReason.FailureType is FailureType.ResourceNotFoundFailure)
        {
            apiErrorResponse.StatusCode = HttpStatusCode.NotFound;
            return NotFound(apiErrorResponse);
        }

        apiErrorResponse.StatusCode = HttpStatusCode.BadRequest;
        return BadRequest(apiErrorResponse);
    }
}