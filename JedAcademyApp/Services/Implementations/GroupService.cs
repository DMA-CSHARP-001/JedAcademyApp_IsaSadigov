using JedAcademyApp.Entities;
using JedAcademyApp.Enums;
using JedAcademyApp.Repositories.Implementations;
using JedAcademyApp.Repositories.Interfaces;
using JedAcademyApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        public async Task<string> CreateAsync(string groupname, GroupEnum groupEnum)
        {
            Group group = new Group(nameof(groupname), groupEnum);

            Console.ForegroundColor= ConsoleColor.Green;
            await _groupRepository.AddAsync(group);
            return "Succesfully Created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            Group group = await _groupRepository.GetAsync(x => x.Id == id);

            if (group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Group is not found!");
            }
            await _groupRepository.DeleteAsync(group);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Group is removed succesfully";
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            Group group = await _groupRepository.GetAsync(x=>x.Id==id);

            if (group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Group is not found. Please add a group then check again!");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return group;
        }

        public async Task<string> UpdateAsync(int id, string groupname)
        {
            Group group = await _groupRepository.GetAsync(x => x.Id == id);

            if (group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Group is not found. Please add a group then check again!");
            }

            group.GroupName = groupname;
            await _groupRepository.UpdateAsync(group);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Group is updated succesfully";
        }
    }
}
