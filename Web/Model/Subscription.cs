namespace Web.Model
{
    using System;

    public class Subscription
    {
        public virtual string EMail { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public override int GetHashCode()
        {
            int result = 1;

            result = (result * 397) ^ (this.EMail != null ? this.EMail.GetHashCode() : 0);
            result = (result * 397) ^ (this.FirstName != null ? this.FirstName.GetHashCode() : 0);
            result = (result * 397) ^ (this.LastName != null ? this.LastName.GetHashCode() : 0);

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Subscription))
            {
                var comp = (Subscription)obj;
                return comp.EMail.Equals(this.EMail, StringComparison.InvariantCultureIgnoreCase) &&
                       comp.FirstName.Equals(this.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                       comp.LastName.Equals(this.LastName, StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override string ToString()
        {
            return string.Format("\"{0}, {1}\" <{2}>", this.LastName, this.FirstName, this.EMail);
        }
    }
}