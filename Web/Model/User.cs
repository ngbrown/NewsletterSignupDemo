namespace Web.Model
{
    using System;

    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public override int GetHashCode()
        {
            int result = 1;

            result = (result * 397) ^ (this.UserName.GetHashCode());

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(User))
            {
                var comp = (User)obj;
                return comp.UserName.Equals(this.UserName, StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}