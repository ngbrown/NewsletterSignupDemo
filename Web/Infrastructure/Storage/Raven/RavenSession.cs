namespace Web.Infrastructure.Storage.Raven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using global::Raven.Client;

    public class RavenSession : ISession
    {
        private readonly IDocumentSession session;

        public RavenSession(IDocumentSession session)
        {
            this.session = session;
        }

        public void Dispose()
        {
            this.session.Dispose();
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return this.session.Query<T>().SingleOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return this.session.Query<T>();
        }

        public void CommitChanges()
        {
            this.session.SaveChanges();
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class
        {
            var items = this.All<T>().Where(expression).ToList();
            items.ForEach(this.Delete);
        }

        public void Delete<T>(T item) where T : class
        {
            this.session.Delete(item);
        }

        public void DeleteAll<T>() where T : class
        {
            var items = this.All<T>().ToList();
            items.ForEach(this.Delete);
        }

        public void Add<T>(T item) where T : class
        {
            this.session.Store(item);
        }

        public void Add<T>(IEnumerable<T> items) where T : class
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Update<T>(T item) where T : class
        {
            this.session.Store(item);
        }
    }
}