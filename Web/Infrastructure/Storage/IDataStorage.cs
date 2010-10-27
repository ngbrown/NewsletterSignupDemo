namespace Web.Infrastructure.Storage
{
    public interface IDataStorage
    {
        ISession NewSession();
    }
}