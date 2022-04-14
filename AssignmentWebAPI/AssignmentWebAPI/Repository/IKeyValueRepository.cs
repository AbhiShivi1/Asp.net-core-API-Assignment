using AssignmentWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace AssignmentWebAPI.Repository
{
    public interface IKeyValueRepository
    {

        Task<KeyValueModel> GetValueByKeyAsync(string key);
        Task<bool> AddKeyValueAsync(KeyValueModel keyValueModel);
        Task<bool> UpdateKeyPatchAsync(string key, string value);
        Task<bool> DeleteKeyValueAsync(string key);
    }
        
}
