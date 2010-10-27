namespace Web.Infrastructure.Storage.NHibernate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using global::NHibernate.Linq;

    public class NHibernateSession : ISession
    {
        private readonly global::NHibernate.ISession session;
        private global::NHibernate.ITransaction transaction;

        public NHibernateSession(global::NHibernate.ISession session)
        {
            this.session = session;
        }

        private void BeginTransaction()
        {
            if (this.transaction == null)
            {
                this.transaction = this.session.BeginTransaction();
            }
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
            }

            this.session.Dispose();
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            this.BeginTransaction();

            return this.session.Linq<T>().SingleOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T : class
        {
            this.BeginTransaction();

            return this.session.Linq<T>();
        }

        public void CommitChanges()
        {
            this.BeginTransaction();

            this.transaction.Commit();
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class
        {
            this.BeginTransaction();

            var items = this.All<T>().Where(expression).ToList();
            items.ForEach(this.Delete);
        }

        public void Delete<T>(T item) where T : class
        {
            this.BeginTransaction();

            this.session.Delete(item);
        }

        public void DeleteAll<T>() where T : class
        {
            this.BeginTransaction();

            var items = this.All<T>().ToList();
            items.ForEach(this.Delete);
        }

        public void Add<T>(T item) where T : class
        {
            this.BeginTransaction();

            this.session.Save(item);
        }

        public void Add<T>(IEnumerable<T> items) where T : class
        {
            this.BeginTransaction();

            foreach (var item in items)
            {
                this.session.Save(item);
            }
        }

        public void Update<T>(T item) where T : class
        {
            this.BeginTransaction();

            this.session.Update(item);
        }
    }
}