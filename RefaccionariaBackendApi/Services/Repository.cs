using Microsoft.EntityFrameworkCore;
using Refaccionaria.Data;
using Refaccionaria.Data.Maping;
using RefaccionariaBackendApi.Interface;

namespace RefaccionariaBackendApi.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RefaccionariaDBContext context;

        public Repository( RefaccionariaDBContext context){
         this.context = context;
        }
        public async Task<T> Create(T model)
        {
            var entry = await context.Set<T>().AddAsync(model);
            await context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task Delete(T model)
        {
             context.Set<T>().Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<T> Get(object Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> GetAll()
        {
           return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T model)
        {
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return model;
        }
    }
}
