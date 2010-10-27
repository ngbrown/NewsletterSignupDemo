namespace Web.Infrastructure.Storage.Raven
{
    using global::Raven.Client;
    using global::Raven.Client.Document;

    public class RavenDataStorage : IDataStorage
    {
        private readonly IDocumentStore store;

        public RavenDataStorage(IDocumentStore store)
        {
            this.store = store;
        }

        public RavenDataStorage(string url)
        {
            this.store = new DocumentStore { Url = url };
            store.Initialize();
        }

        public ISession NewSession()
        {
            return new RavenSession(this.store.OpenSession());
        }
    }
}