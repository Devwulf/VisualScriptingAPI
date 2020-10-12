using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisualScripting.Services.Model;

namespace VisualScripting.Services.Contracts
{
    public interface IScripletService
    {
        Task<Scriplet> CreateAsync(Scriplet scriplet);

        Task<bool> UpdateAsync(Scriplet scriplet);

        Task<bool> UpdateSetAsync(string id, Dictionary<string, object> changes);

        Task<bool> UpdateUnsetAsync(string id, Dictionary<string, object> changes);

        Task<bool> DeleteAsync(string id);

        Task<Scriplet> GetAsync(string id);
    }
}
