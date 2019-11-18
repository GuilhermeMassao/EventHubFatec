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
        #endregion
    }
}
