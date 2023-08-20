using JedAcademyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Services.Interfaces
{
     public interface IStudentService
    {
        Task<string> CreateAsync(int groupId, string FirstName, string LastName);
        Task<string> UpdateAsync(int id, string FirstName, string LastName);
        Task <string> RemoveAsync(int id);
        Task<Student> GetAsync(int id);
        Task<List<Student>> GetAllAsync();
    }
}
