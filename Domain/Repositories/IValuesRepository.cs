using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IValuesRepository
    {
        Task<IEnumerable<Value>> GetAll();
        Task<int> Save(Value value);
        Task<bool> Delete(int idToDelete);
    }
}
