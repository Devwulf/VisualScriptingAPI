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

        Task<bool> UpdateFieldsAsync(string id, Dictionary<string, string> changes);

        Task<bool> DeleteAsync(string id);

        Task<Scriplet> GetAsync(string id);
    }
}
