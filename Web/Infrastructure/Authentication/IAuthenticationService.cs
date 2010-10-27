namespace Web.Infrastructure.Authentication
{
    using System;

    public interface IAuthenticationService
    {
        bool IsValidLogin(string username, string password);
    }
}