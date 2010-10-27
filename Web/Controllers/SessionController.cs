namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    using Infrastructure.Authentication;

    public class SessionController : Controller
    {
        private readonly IAuthenticationService authService;

        public SessionController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            var login = collection["username"];
            var password = collection["password"];
            if (string.IsNullOrEmpty(login) == false &&
                string.IsNullOrEmpty(password) == false)
            {
                if (this.authService.IsValidLogin(login, password))
                {
                    FormsAuthentication.SetAuthCookie(login, true);
                    return this.Redirect("/");
                }
            }

            return this.View();
        }
    }
}
