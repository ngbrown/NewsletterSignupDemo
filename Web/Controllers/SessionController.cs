namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    using Infrastructure.Authentication;
    using Infrastructure.Reporting;

    public class SessionController : Controller
    {
        private readonly IAuthenticationService authService;
        private readonly IReporting reporting;

        private readonly UserActivityLogger userActivityLogger;

        public SessionController(
            IAuthenticationService authService,
            IReporting reporting)
        {
            this.authService = authService;
            this.reporting = reporting;

            this.userActivityLogger = new UserActivityLogger(this.reporting);
        }

        //
        // GET: /Session/Create
        // Kind of like "login"
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
                string.IsNullOrEmpty(password) == false &&
                this.authService.IsValidLogin(login, password))
            {
                this.userActivityLogger.LogIt(login, "Logged in");
                FormsAuthentication.SetAuthCookie(login, true);
                return this.Redirect("/");
            }
            else
            {
                this.FlashWarning("Invalid Login");
            }

            return this.View();
        }

        // Logout
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            this.userActivityLogger.LogIt(User.Identity.Name, "Logged out");
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}
