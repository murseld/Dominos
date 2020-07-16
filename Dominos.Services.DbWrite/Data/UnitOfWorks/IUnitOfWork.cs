using System;
using Dominos.Core.Data;

namespace Dominos.Services.DbWrite.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository GetRepository();
        int SaveChanges();
    }
}
