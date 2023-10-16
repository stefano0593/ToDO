﻿namespace Todo.Application.ResultPattern;

public class FailureReason
{
    private readonly List<string> _errors = new();
    private FailureReason(FailureType errorType, string? errorMessage)
    {
        FailureType = errorType;
        ApplicationErrorMessage = errorMessage;
    }

    private FailureReason(FailureType errorType, List<string> errors)
    {
        FailureType = errorType;
        errors.ForEach(error => _errors.Add(error));
    }
    
    public FailureType FailureType { get; private set; }
    public IReadOnlyCollection<string> Errors => _errors;
    public string? ApplicationErrorMessage { get; private set; }

    public static FailureReason AddError(FailureType errorType, string errorMessage) 
        => new(errorType, errorMessage);

    public static FailureReason AddErrors(FailureType errorType, List<string> errors)
        => new(errorType, errors);

    public static FailureReason NotFoundFailure(string errorMessage)
        => new(errorType: FailureType.ResourceNotFoundFailure, errorMessage: errorMessage);
    
    public static FailureReason InternalServerFailure(string errorMessage)
        => new(errorType: FailureType.InternalServerFailure, errorMessage: errorMessage);

    public static FailureReason TransactionFailure(string errorMessage)
        => new(errorType: FailureType.TransactionFailure, errorMessage: errorMessage);

    public static FailureReason IdentityFailure(string errorMessage)
        => new(errorType: FailureType.IdentityFailure, errorMessage: errorMessage);
    
    public static FailureReason DomainValidationFailure(string errorMessage)
        => new(errorType: FailureType.IdentityFailure, errorMessage: errorMessage);
}