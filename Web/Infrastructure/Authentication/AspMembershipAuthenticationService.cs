namespace Web.Infrastructure.Authentication
{
    using System.Web.Security;

    public class AspMembershipAuthenticationService : IAuthenticationService
    {
        public bool IsValidLogin(string username, string password)
        {
            return Membership.ValidateUser(username, password);
        }
    }
}