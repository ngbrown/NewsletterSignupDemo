namespace Web.Infrastructure.Authentication
{
    using System;

    /// <summary>
    /// This is just a temporary demo method.  Don't use in a production environment.
    /// Instead use <see cref="AspMembershipAuthenticationService"/> or similar.
    /// </summary>
    public class DefaultLoginAuthenticationService : IAuthenticationService
    {
        public bool IsValidLogin(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }

            if (username.Equals("Admin", StringComparison.InvariantCultureIgnoreCase) && 
                password == "admin")
            {
                return true;
            }

            return false;
        }
    }
}