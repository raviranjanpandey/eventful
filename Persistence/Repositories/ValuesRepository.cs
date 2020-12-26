using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly DataContext _dataContext;
        public ValuesRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IEnumerable<Value>> GetAll()
        {
            return await _dataContext.Values.ToListAsync();
        }

        public async Task<int> Save(Value value)
        {
            if (value.Id > 0)
            {
                _dataContext.Values.Update(value);
            }
            else
            {
                _dataContext.Values.Add(value);
            }
            await _dataContext.SaveChangesAsync();
            return value.Id;
        }

        public async Task<bool> Delete(int idToDelete)
        {
            var delete = await _dataContext.Values.FindAsync(idToDelete);
            _dataContext.Remove(delete);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
