namespace EventHub.Infrastructure.Interfaces.StroreProcedures
{
    internal interface IStoreProcedure
    {
        string InactivateUser { get; }
        string InsertUser { get; }
        string SelectGoogleTokenByUserId { get; }
        string SelectTwitterTokensByUserId { get; }
        string SelectUserByEmail { get; }
        string SelectUserByEmailAndPassword { get; }
        string SelectUserById { get; }
        string UpdateUserTwitterToken { get; }
        string UpdateUserGoogleToken { get; }
        string UpdateUser { get; }
    }
}