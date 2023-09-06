using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Data.Repositories.Commons;

public class Repository<T> : IRepository<T> where T : Auditable
{
    protected readonly AppDbContext appDbContext;
    protected readonly DbSet<T> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }
    
    public async Task<T> CreateAsync(T entity)
    { 
        var temp= (await dbSet.AddAsync(entity)).Entity;
        return temp;
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }        

    public IQueryable<T> GetAll()
        => dbSet.AsQueryable();

    public async Task<T> GetByIdAsync(long id)
        => await dbSet.FindAsync(id);

    public T Update(T entity)
        => dbSet.Update(entity).Entity;

    public async Task<int> SaveAsync()
       => await appDbContext.SaveChangesAsync();
}
