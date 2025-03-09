using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Interfaces.Repositories;
using UserAPI.Infra.Context;

namespace UserAPI.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(T entity)
        {
            _appDbContext.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _appDbContext.Update(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _appDbContext.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _appDbContext.Set<T>().ToList(); 
        }

        public T GetById(Guid id)
        {
            return _appDbContext.Set<T>().Find(id);
        }
    }
}
