using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MealPlannerContext _context;

        public EfRepository(MealPlannerContext context)
        {
            _context = context;
        }
                
        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.Entry(entity).State = EntityState.Modified; this causes tests to fail because there's a null object, I think I'm not setting up something correctly
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetSingleBySpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        
        public async Task<IReadOnlyList<T>> List(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        
        public async Task<IReadOnlyList<T>> ListAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> Count(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        // Not using synchronous operations, but keeping these for posterity 
        #region Synchronous operations
        //public T Add(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //    _context.SaveChanges();

        //    return entity;
        //}
        //public int Count(ISpecification<T> spec)
        //{
        //    return ApplySpecification(spec).Count();
        //}
        //public void Delete(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //    _context.SaveChanges();
        //}
        //public T GetById(int id)
        //{
        //    return _context.Set<T>().Find(id);
        //}
        //public T GetSingleBySpec(ISpecification<T> spec)
        //{
        //    return List(spec).FirstOrDefault();
        //}
        //public IEnumerable<T> List(ISpecification<T> spec)
        //{
        //    return ApplySpecification(spec).AsEnumerable();
        //}
        //public IEnumerable<T> ListAll()
        //{
        //    return _context.Set<T>().AsEnumerable();
        //}
        //public void Update(T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //    //_context.Entry(entity).State = EntityState.Modified; this causes tests to fail because there's a null object, I think I'm not setting up something correctly
        //    _context.SaveChanges();
        //}
        #endregion
    }
}
