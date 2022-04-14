using AssignmentWebAPI.Data;
using AssignmentWebAPI.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace AssignmentWebAPI.Repository
{
    public class KeyValueRepository : IKeyValueRepository
    {
        
        private readonly KeyValueContext _context;

        public KeyValueRepository(KeyValueContext context)
        {
            
            _context = context;
        }


        public async Task<KeyValueModel> GetValueByKeyAsync(string key)
        {
            var value = await _context.KeyValue.Where(x => x.Key == key).Select(x => new KeyValueModel()
            {
                Key = x.Key,
                Value = x.Value
            }).FirstOrDefaultAsync();
            return value;

        }

        public async Task<bool> AddKeyValueAsync(KeyValueModel keyValueModel)
        {
            var available = await _context.KeyValue.FindAsync(keyValueModel.Key);

            if(available!=null)
            {
                return false;
            }
            var result = new KeyValue()
            {
                Key = keyValueModel.Key,
                Value = keyValueModel.Value
            };
            _context.KeyValue.Add(result);
            await _context.SaveChangesAsync();
            return true;

            

        }

        public async Task<bool> UpdateKeyPatchAsync(string key, string value)
        {
            var available = await _context.KeyValue.FindAsync(key);
            if(available==null)
            {
                return false;
            }
            available.Value = value;
            _context.KeyValue.Update(available);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> DeleteKeyValueAsync(string key)
        {
            var available = await _context.KeyValue.FindAsync(key);
            if (available == null)
            {
                return false;
            }
            _context.Remove(available);
            await _context.SaveChangesAsync();
            return true;
        }




    }
}
