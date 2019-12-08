namespace EventHub.Infrastructure.Interfaces.StroreProcedures
{
    internal interface IStoreProcedure
    {
        #region User
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
        #endregion

        #region Event
        string InsertEvent { get; }
        string UpdateEvent { get; }
        string SelectEventsById { get; }
        string SelectEventsByUserId { get; }
        string SelectAllActiveEvents { get; }
        string CancelEvent { get; }
        #endregion

        #region Adress
        string InsertAdress { get; }
        string UpdateAdress { get; }
        string InactivateAdress { get; }
        string DeleteAdress { get; }
        #endregion

        #region Public Places
        string SelectAllPublicPlaces { get; }
        string SelectPublicPlaceById { get; }
        #endregion

        #region Twitter
        string InsertTwitterSocialMarketing { get; }
        #endregion

        #region Google Calendar
        string InsertGoogleCalendarSocialMarketing { get; }
        string SelectGoogleCalendarSocialMarketingByEventId { get; }
        string GetAllEvents { get; }
        #endregion

        #region Event Subscriptions
        string InsertInscription { get; }
        string SelectAllCurrentEventsByUserSubscribed { get; }
        string SelectAllCurrentEventsByOwnerId { get; }
        string SelectEventSubscriptionById { get; }
        string SelectAllEventSubscriptionsByEventId { get; }
        string DeleteInscriptionByUserId { get; }
        #endregion
    }
}