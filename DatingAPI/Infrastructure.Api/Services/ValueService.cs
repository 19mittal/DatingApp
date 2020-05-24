using Application.Api.Interface.Repository;
using Application.Api.Interface.Service;
using Domain.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Api.Services
{
    public class ValueService : IValueService
    {
        private readonly IValueRepository _valueRepository;
        public ValueService(IValueRepository valueRepository)
        {
            _valueRepository = valueRepository;
        }
        public async Task DeleteValue(Value entity)
        {
            _valueRepository.Remove(entity);
            await _valueRepository.Complete();
        }

        public async Task<IEnumerable<Value>> GetValue()
        {
            return await _valueRepository.GetAll();
        }

        public async Task<Value> GetValueById(int id)
        {
            return await _valueRepository.Get(id);
        }

        public async Task InsertValue(Value entity)
        {
           await _valueRepository.Add(entity);
        }

        public async Task UpdateValue(Value entity)
        {
            var obj = await _valueRepository.Get(entity.Id);
            obj.Name = entity.Name;
            await _valueRepository.Complete();
        }
    }
}
