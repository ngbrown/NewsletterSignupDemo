namespace Web.Infrastructure.Reporting
{
    using Web.Reporting;

    public class UserActivityLogger
    {
        private readonly IReporting reporting;

        public UserActivityLogger(IReporting reporting)
        {
            this.reporting = reporting;
        }

        public UserActivity LogIt(string userName, string activity)
        {
            using (var session = this.reporting.NewSession())
            {
                var userActivity = UserActivity.New(userName, activity);
                session.Add(userActivity);
                session.CommitChanges();
                return userActivity;
            }
        }
    }
}