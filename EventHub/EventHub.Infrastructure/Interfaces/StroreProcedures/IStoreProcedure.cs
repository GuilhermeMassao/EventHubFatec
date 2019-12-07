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
        string UpdateUserInformation { get; }
        string UpdateUserPassword { get; }

        string InsertEvent { get; }

        string InsertAdress { get; }
        string InactivateAdress { get; }
        string DeleteAdress { get; }

        string SelectAllPublicPlaces { get; }
        string SelectPublicPlaceById { get; }

        string InsertTwitterSocialMarketing { get; }

        string InsertGoogleCalendarSocialMarketing { get; }
    }
}