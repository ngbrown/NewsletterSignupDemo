namespace Web.Infrastructure.Reporting
{
    using NHibernate;

    public class ReportingDataStorage : Storage.NHibernate.NHibernateDataStorage, IReporting
    {
        public ReportingDataStorage(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
        }
    }
}