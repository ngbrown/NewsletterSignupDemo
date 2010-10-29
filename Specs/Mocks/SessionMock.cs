namespace Specs.Mocks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Web.Infrastructure.Storage;

    public class SessionMock : ISession
    {
        private readonly ArrayList store;

        public SessionMock()
        {
            this.store = new ArrayList();
            this.Dirty = false;
        }

        public bool Dirty { get; private set; }

        public void Dispose()
        {
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return this.store.OfType<T>().SingleOrDefault(expression.Compile());
        }

        public IQueryable<T> All<T>() where T : class
        {
            return this.store.OfType<T>().AsQueryable();
        }

        public void CommitChanges()
        {
            this.Dirty = false;
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class
        {
            var items = this.store.OfType<T>().Where(expression.Compile());
            foreach (var item in items)
            {
                this.store.Remove(item);
                this.Dirty = true;
            }
        }

        public void Delete<T>(T item) where T : class
        {
            this.store.Remove(item);
            this.Dirty = true;
        }

        public void DeleteAll<T>() where T : class
        {
            this.Delete<T>(x => true);
        }

        public void Add<T>(T item) where T : class
        {
            this.store.Add(item);
            this.Dirty = true;
        }

        public void Add<T>(IEnumerable<T> items) where T : class
        {
            this.store.AddRange(items.ToList());
            this.Dirty = true;
        }

        public void Update<T>(T item) where T : class
        {
            throw new NotImplementedException("Don't need it right now for the demo, so I'm not going to think about it.");
        }
    }
}