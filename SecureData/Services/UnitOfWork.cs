using SecureData.Data;
using SecureData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace SecureData.Services
{
    
    public class UnitOfWork : IDisposable
    {
        private SecureDataContext _secureDataContext;
        private GenericRepository<Order> orderRepo;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _secureDataContext = serviceProvider.GetService<SecureDataContext>();
        }
        public GenericRepository<Order> OrderRepository
        {
            get {

                if (this.orderRepo == null)
                {
                    this.orderRepo = new GenericRepository<Order>(_secureDataContext);
                }
                return orderRepo;
            } 
        }
        public void Save()
        {
            _secureDataContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _secureDataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
