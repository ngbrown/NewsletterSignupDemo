namespace Web.Infrastructure.Storage.NHibernate
{
    using global::NHibernate;

    using ISession = Storage.ISession;

    public class NHibernateDataStorage : IDataStorage
    {
        private readonly ISessionFactory sessionFactory;

        public NHibernateDataStorage(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public ISession NewSession()
        {
            return new NHibernateSession(this.sessionFactory.OpenSession());
        }
    }
}