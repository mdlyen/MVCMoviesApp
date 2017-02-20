using System;
using System.Data.Entity;

namespace Movies.Web.Models
{
    public interface IDbSession
    {
        IDbSet<T> Set<T>() where T : class;

        void SaveChanges();
    }
}