namespace Web.Reporting
{
    using System;

    public class UserActivity
    {
        protected UserActivity()
        {
        }

        public static UserActivity New(string userName, string activity)
        {
            return new UserActivity
                {
                    UserName = userName,
                    Activity = activity,
                    CreatedOn = DateTime.Now
                };
        }

        public virtual int Id { get; private set; }

        public virtual string UserName { get; set; }

        public virtual string Activity { get; set; }

        public virtual DateTime CreatedOn { get; set; }
    }
}