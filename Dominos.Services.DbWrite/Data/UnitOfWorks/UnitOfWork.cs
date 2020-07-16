using Dominos.Core.Data;
using System;
using AutoMapper;
using Dominos.Services.DbWrite.Repositories;

namespace Dominos.Services.DbWrite.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LocationDbContext _dbContext;
        private IMapper _mapper;
        private ILocationRepository _locationRepository;
        public UnitOfWork(LocationDbContext dbContext, IMapper mapper, ILocationRepository locationRepository)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        #region IUnitOfWork Members
        public IBaseRepository GetRepository()
        {
            //return new ProductRepository(_dbContext,_mapper);
            return _locationRepository;
        }

        public int SaveChanges()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir
                // veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                Console.Write(exception.Message);
                throw;
            }


        }
        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
