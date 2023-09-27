using Microsoft.EntityFrameworkCore;
using OnlineShop.Lib.Migrations;
using OnlineShop.Lib.Repositories.Interfaces;

namespace OnlineShop.Lib.Repositories
{
    public abstract class BaseRepo<T> : IRepos<T> where T : class, IIdentifiable, new()
    {
        public OrdersDbContext Context { get; init; }
        protected DbSet<T> Table { get; set; }

        public BaseRepo(OrdersDbContext context)
        {
            Context = context;
        }

        public virtual async Task<T> GetOneAsync(Guid id)
            => await Task.Run(() => Table.FirstOrDefault(t => t.Id == id));

        public virtual async Task<IEnumerable<T>> GetAllAsync()
            => await Table.ToListAsync();

        public async Task<Guid> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entries)
        {
            Table.AddRangeAsync(entries);
            await SaveChangesAsync();

            var result = new List<Guid>(entries.Select(e => e.Id));
            return result;
        }

        public async Task<int> SaveAsync(T entry)
        {
            Context.Entry(entry).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Guid>> SaveChangeRengeAsync(IEnumerable<T> enttiers)
        {
            await Table.AddRangeAsync(enttiers);
            await SaveChangesAsync();
            var result = new List<Guid>(enttiers.Select(e => e.Id));
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entry = await GetOneAsync(id);

            if (entry != null)
            {
                Context.Entry(entry).State = EntityState.Deleted;
                return await SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<Guid> ids)
        {
            int result = 0;
            foreach (var id in ids)
            {
                var res = await DeleteAsync(id);
                result += res;
            }

            return result;
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
