using JedAcademyApp.Entities;
using JedAcademyApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Services.Interfaces
{
    public interface IGroupService
    {
        Task<string> CreateAsync(string groupname, GroupEnum groupEnum);
        Task<string> UpdateAsync(int id, string groupname);
        Task<string> DeleteAsync(int id);
        Task<Group> GetAsync(int id);
        Task<List<Group>> GetAllAsync(); 

    }
}
