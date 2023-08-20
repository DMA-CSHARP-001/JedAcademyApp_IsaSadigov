using JedAcademyApp.Entities;
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
    public class StudentService : IStudentService
    {
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        public async Task<string> CreateAsync(int groupId, string FirstName, string LastName)
        {
            Group group = await _groupRepository.GetAsync(x=>x.Id == groupId);
            if(group == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Group is not found. Please try again");
                return null;
            }

            Student student = new Student(FirstName,LastName,group);
            group.Students.Add(student);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Student is created succesfully";
        }

        public async Task<List<Student>> GetAllAsync()
        {
            List<Group> groups = await _groupRepository.GetAllAsync();

            List<Student> students = new List<Student>();
            foreach(var item in groups)
            {
                students.AddRange(item.Students);
            }
            return students;
      }

        public async Task<Student> GetAsync(int id)
        {
            List<Group> groups = await _groupRepository.GetAllAsync();
            List<Student> students = new List<Student>();
            foreach (var item in groups)
            {
                Student student = item.Students.Find(x => x.Id == id);
                if(student != null)
                {
                    return student;
                }
            }
            return null;
        }

        public async Task<string> RemoveAsync(int id)
        {
            List<Group> groups = await _groupRepository.GetAllAsync();
            List<Student> students = new List<Student>();
            foreach (var item in groups)
            {
                Student student = item.Students.Find(x => x.Id == id);
                if (student != null)
                {
                    item.Students.Remove(student); ;
                    await _groupRepository.UpdateAsync(item);
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Student is removed succesfully";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Student is not found. Please try again!";
        }

        public async Task<string> UpdateAsync(int id, string FirstName, string LastName)
        {

            List<Group> groups = await _groupRepository.GetAllAsync();
            List<Student> students = new List<Student>();
            foreach (var item in groups)
            {
                Student student = item.Students.Find(x => x.Id == id);
                if (student != null)
                {
                    Console.WriteLine("Please enter student firstname");
                    string firstname = Console.ReadLine();

                    Console.WriteLine("Please enter student lastname");
                    string lastname = Console.ReadLine();

                    Group group = await _groupRepository.GetAsync(x=>x.Id == id);
                    student.FirstName = firstname;
                    student.LastName = lastname;
                    student.UpdatedAt = DateTime.Now;
                    await _groupRepository.UpdateAsync(item);
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Student is updateed succesfully";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Student is not found. Please try again!";
        }
    }
}
