using Bank_Data_Layer.DAL;
using Bank_Logic_Layer.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BankDbContext _dataBase;
        public GenericRepository(BankDbContext dataBase)
        {
            _dataBase = dataBase;
        }
        public DbSet<T> Table => _dataBase.Set<T>();
        public async Task Add(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddAndCommit(T entity)
        {
            await Add(entity);
            await Commit();
        }

        public async Task Commit()
        {
            await _dataBase.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            Table.Remove(await Find(id));
        }

        public async Task<T> Find(int id)
        {
            return await Table.FindAsync(id);
        }

        public Task<List<T>> GetAll()
        {
            return Table.ToListAsync();
        }

        public async Task<List<T>> GetTableByExpession(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await Table.Where(expression).ToListAsync();
        }

        public void Update(T entity)
        {
            _dataBase.Entry(entity).State = EntityState.Modified;
        }
    }
}
