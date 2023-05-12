using E_Commerce_API.Data;
using E_Commerce_API.Interfaces;
using System.Collections;

namespace E_Commerce_API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext context)
        {
                _context = context; 
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
           if(_repositories == null)  _repositories = new Hashtable();  
           var type  = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var instance  = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, instance);
            }

            return (IGenericRepository <T>) _repositories[type];
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
