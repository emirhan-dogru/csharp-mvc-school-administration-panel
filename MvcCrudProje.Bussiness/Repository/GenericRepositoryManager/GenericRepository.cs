using System;
using System.Collections.Generic;
using System.Data.Entity;
using MvcCrudProje.Models.Context;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrudProje.Bussiness.Repository.GenericRepositoryManager
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        CrudDbContext db;
        DbSet<T> dbSet;
        public GenericRepository()
        {
            db = new CrudDbContext();
            this.dbSet = db.Set<T>();
        }

        public void create(T entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public void update(T entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<T> get()
        {
            return dbSet.ToList();
        }

        public void delete(int id)
        {
            var silinecekVeri = dbSet.Find(id);
            dbSet.Remove(silinecekVeri);
            db.SaveChanges();
        }


    }
}
