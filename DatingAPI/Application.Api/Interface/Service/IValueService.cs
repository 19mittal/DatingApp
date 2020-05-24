using Domain.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Api.Interface.Service
{
    public interface IValueService
    {
        Task<IEnumerable<Value>> GetValue();
        Task<Value> GetValueById(int id);
        Task InsertValue(Value entity);
        Task UpdateValue(Value entity);
        Task DeleteValue(Value entity);
    }
}
