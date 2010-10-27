namespace Web.Infrastructure.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface ISession : IDisposable
    {
        T Single<T>(Expression<Func<T, bool>> expression) where T : class;

        IQueryable<T> All<T>() where T : class;

        void CommitChanges();

        void Delete<T>(Expression<Func<T, bool>> expression) where T : class;

        void Delete<T>(T item) where T : class;

        void DeleteAll<T>() where T : class;

        void Add<T>(T item) where T : class;

        void Add<T>(IEnumerable<T> items) where T : class;

        void Update<T>(T item) where T : class;
    }
}