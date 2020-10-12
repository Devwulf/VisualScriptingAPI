using VisualScripting.Services.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VisualScripting.Services.Contracts
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> UpdateFieldsAsync(string id, Dictionary<string, object> changes);

        Task<bool> DeleteAsync(string id);

        Task<User> GetAsync(string id);
    }
}
