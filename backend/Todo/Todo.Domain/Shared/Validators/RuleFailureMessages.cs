namespace Todo.Domain.Shared.Validators;

public static class RuleFailureMessages
{
    public const string PropertyRequired = "{PropertyName} is required and must be valid";
    public const string PropertyMaxLengthExceeded = "{PropertyName} must be {MaxLength} characters in length.";
}