namespace Todo.Application.ResultPattern;

public static class FailureMessages
{
    public const string EmailAlreadyRegistered = "An user with this email was already registered.";
    public const string IdentityCannotBeCreated = "The identity for user could not be created due to errors.";
    public const string EmailNotFound = "Email was not found";
    public const string PasswordIncorrect = "Password is incorect.";
    public const string AccountNotFound = "Account was not found";
}