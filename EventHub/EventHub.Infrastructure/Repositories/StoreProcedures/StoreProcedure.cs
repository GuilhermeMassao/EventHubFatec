using EventHub.Infrastructure.Interfaces.StroreProcedures;

namespace EventHub.Infrastructure.Repositories.StoreProcedures
{
    internal class StoreProcedure : IStoreProcedure
    {
        #region User
        public string InactivateUser => "InactivateUser";
        public string InsertUser => "InsertUser";
        public string SelectUserByEmail => "SelectUserByEmail";
        public string SelectUserByEmailAndPassword => "SelectUserByEmailAndPassword";
        public string SelectUserById => "SelectUserById";
        public string SelectGoogleTokenByUserId => "SelectGoogleTokenByUserId";
        public string SelectTwitterTokensByUserId => "SelectTwitterTokensByUserId";
        public string UpdateUserTwitterToken => "UpdateUserTwitterToken";
        public string UpdateUserGoogleToken => "UpdateUserGoogleToken";
        public string UpdateUser => "UpdateUser";
        public string UpdateUserInformation => "UpdateUserInformation";
        public string UpdateUserPassword => "UpdateUserPassword";
        #endregion

        #region Event
        public string InsertEvent => "InsertEvent";
        public string UpdateEvent => "UpdateEvent";
        public string SelectEventsById => "SelectEventsById";
        public string SelectAllActiveEvents => "SelectAllActiveEvents";
        public string GetAllEvents => "SelectAllEvents";
        public string CancelEvent => "CancelEvent";
        #endregion

        #region Adress
        public string InsertAdress => "InsertAdress";
        public string UpdateAdress => "UpdateAdress";
        public string InactivateAdress => "InactivateAdress";
        public string DeleteAdress => "DeleteAdress";
        #endregion

        #region PublicPlace
        public string SelectAllPublicPlaces => "SelectAllPublicPlaces";
        public string SelectPublicPlaceById => "SelectPublicPlaceById";
        #endregion

        #region TwitterSocialMarketing
        public string InsertTwitterSocialMarketing => "InsertTwitterSocialMarketing";
        #endregion

        #region GoogleCalendarSocialMarketing
        public string InsertGoogleCalendarSocialMarketing => "InsertGoogleCalendarSocialMarketing";
        public string SelectGoogleCalendarSocialMarketingByEventId => "SelectGoogleCalendarSocialMarketingByEventId";
        #endregion

        #region Event Subscriptions
        public string InsertInscription => "InsertInscription";
        public string SelectAllCurrentEventsByUserSubscribed => "SelectAllCurrentEventsByUserSubscribed";
        public string SelectAllCurrentEventsByOwnerId => "SelectAllCurrentEventsByOwnerId";
        public string SelectEventSubscriptionById => "SelectEventSubscriptionById";
        public string DeleteInscriptionByUserId => "DeleteInscriptionByUserId";
        #endregion
    }
}
