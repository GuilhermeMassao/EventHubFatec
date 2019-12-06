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
        #endregion

        #region Event
        public string InsertEvent => "InsertEvent";
        #endregion

        #region Adress
        public string InsertAdress => "InsertAdress";
        public string InactivateAdress => "InactivateAdress";
        public string DeleteAdress => "DeleteAdress";
        #endregion

        #region PublicPlace
        public string SelectAllPublicPlaces => "SelectAllPublicPlaces";
        #endregion

        #region TwitterSocialMarketing
        public string InsertTwitterSocialMarketing => "InsertTwitterSocialMarketing";
        #endregion
    }
}
