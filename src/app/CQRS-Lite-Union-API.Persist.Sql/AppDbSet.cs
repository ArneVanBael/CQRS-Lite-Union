using CQRS_Lite_Union_API.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CQRS_Lite_Union_API.Persist.Sql
{
    public class AppDbSet<T> : IAppDbSet<T> where T: class
    {
        private readonly DbSet<T> _dbSet;

        public AppDbSet(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public IAppDbSet<T> Include<U>(Expression<Func<T, U>> navigationPropertyPath)
        {
            _dbSet.Include(navigationPropertyPath);
            return this;
        }
    }

    public static class AppDbSetExtensions
    {
        public static IAppDbSet<T> AsIAppDbSet<T>(this DbSet<T> dbSet) where T : class
        {
            return new AppDbSet<T>(dbSet);
        }
    }
}
