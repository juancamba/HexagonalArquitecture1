using BubberDinner.Domain.Entities;

public record AuthenticationResult(
    User User,
    string Token
);