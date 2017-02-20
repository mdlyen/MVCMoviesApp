using System;
using System.Data.Entity;

namespace Movies.Web.Models
{
    public class EntityDbSession : IDbSession, IDisposable
    {
        private readonly DbContext _dbContext;

        public EntityDbSession(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}