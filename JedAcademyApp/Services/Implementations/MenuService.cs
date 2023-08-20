using JedAcademyApp.Enums;
using JedAcademyApp.Services.Interfaces;
using JedAcademyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace JedAcademyApp.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private  readonly IStudentService _studentService = new StudentService();
        private readonly IGroupService _groupService = new GroupService();

        public void AnimatedWriteline(string message, ConsoleColor color)
        {
            int delay = 10;
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public async Task ShowMenuAsync()
        {
            AnimatedWriteline("Welcome to Jed Academy console application", ConsoleColor.Magenta);
            AnimatedWriteline("App is developed by Isa Sadigov", ConsoleColor.Magenta);
            AnimatedWriteline("Please select one of theese options", ConsoleColor.Magenta);

            show();

            int.TryParse(Console.ReadLine(), out int request);

            while (request != 0)
            {
                switch (request)
                {
                    case 1:
                        Console.Clear();
                        await CreateGroup();
                        break;
                    case 2:
                        Console.Clear();
                        await ShowAllGroups();
                        break;
                    case 3:
                        Console.Clear();
                        await GetGroup();    
                        break;
                    case 4:
                        Console.Clear();
                        await UpdateGroup();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveGroup();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateStudent();
                        break;
                    case 7:
                        Console.Clear();
                        await ShowAllStudents();
                        break;
                    case 8:
                        Console.Clear();
                        await GetStudent();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateStudent();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveStudent();
                        break;

                    default:
                        Console.Clear();
                        AnimatedWriteline("Please select option number correctly", ConsoleColor.Red);
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                show();
                int.TryParse(Console.ReadLine(), out request);
            }
        }

        private void show()
        {
            AnimatedWriteline("1.Create a group", ConsoleColor.Yellow);
            AnimatedWriteline("2.Show all group", ConsoleColor.Yellow);
            AnimatedWriteline("3.Get a group", ConsoleColor.Yellow);
            AnimatedWriteline("4.Update a group", ConsoleColor.Yellow);
            AnimatedWriteline("5.Remove a group", ConsoleColor.Yellow);
            AnimatedWriteline("-----------------------", ConsoleColor.Yellow);
            AnimatedWriteline("6.Create a student", ConsoleColor.Yellow);
            AnimatedWriteline("7.Show all students", ConsoleColor.Yellow);
            AnimatedWriteline("8.Get a student", ConsoleColor.Yellow);
            AnimatedWriteline("9.Update a student", ConsoleColor.Yellow);
            AnimatedWriteline("10.Remove a student", ConsoleColor.Yellow);
        }


        private async Task CreateGroup()
        {
            Console.WriteLine("Please add a group name");
            string name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                AnimatedWriteline("Name can not be space!!!", ConsoleColor.Red);
                return;
            }

            Console.WriteLine("Please choose group category");

            var Enums = Enum.GetValues(typeof(GroupEnum));
            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." +item);
            }
            int.TryParse(Console.ReadLine(), out int groupEnumCategory);

            try
            {
                Enums.GetValue(groupEnumCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please choose correct option!!!");
                return;
            }


            string message = await _groupService.CreateAsync(name, (GroupEnum)groupEnumCategory);
            Console.WriteLine(message);
        }

        private async Task ShowAllGroups()
        {
            List<JedAcademyApp.Entities.Group> groups = await _groupService.GetAllAsync();
            foreach (var group in groups)
            {
                AnimatedWriteline($"Group ID: {group.Id} Group Name: {group.GroupName}" +
                    $"Group Categroy: {group.groupEnums}", ConsoleColor.Green);
            }
        }

        private async Task GetGroup()
        {
            AnimatedWriteline("Please enter id to get a group", ConsoleColor.Cyan);
            int.TryParse(Console.ReadLine(), out int id);

            JedAcademyApp.Entities.Group  group = await _groupService.GetAsync(id);
            AnimatedWriteline($"Group ID: {group.Id} Group Name: {group.GroupName}" +
                   $"Group Categroy: {group.groupEnums}", ConsoleColor.Green);

        }

        private async Task UpdateGroup()
        {
            Console.WriteLine("Please enter group id to update");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Please enter new group name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please Add name");
                return;
            }

            string message = await _groupService.UpdateAsync(id,name);
            Console.WriteLine(message);

        }


        private async Task RemoveGroup()
        {
            AnimatedWriteline("Enter id number to remove group",ConsoleColor.Yellow);
            int.TryParse(Console.ReadLine(), out int id);

            string message = await _groupService.DeleteAsync(id);
            AnimatedWriteline(message,ConsoleColor.Green);
        }

        //-----------------------------------------------

       

        private async Task CreateStudent()
        {
            Console.WriteLine("Please enter Group Id");
            int groupId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter student's first name");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter student's last name");
            string surname = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name)) 
            {
                AnimatedWriteline("Name can not be empty", ConsoleColor.Red);
                return;
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                AnimatedWriteline("Surname can not be empty", ConsoleColor.Red);
                return;
            }

            string message = await _studentService.CreateAsync(groupId, name, surname);
            AnimatedWriteline($"{message}", ConsoleColor.Green);
        }

        private async Task ShowAllStudents()
        {
            List<Student> students = await _studentService.GetAllAsync();
            foreach (Student student in students) 
            {
                AnimatedWriteline($"Student Id: {student.Id} Student first name: {student.FirstName} Student last name {student.LastName}  ", ConsoleColor.Cyan);
            }
        }

        private async Task GetStudent()
        {
            AnimatedWriteline("Please enter student id", ConsoleColor.Magenta);
            int.TryParse(Console.ReadLine(), out int id);

            Student student = await _studentService.GetAsync(id);
            AnimatedWriteline($"Student Name: {student.FirstName} Student Lastname {student.Group.GroupName}", ConsoleColor.Green);

        }

        private async Task UpdateStudent()
        {
            Console.WriteLine("Please enter Group Id");
            int groupId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter student's first name");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter student's last name");
            string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                AnimatedWriteline("Name can not be empty", ConsoleColor.Red);
                return;
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                AnimatedWriteline("Surname can not be empty", ConsoleColor.Red);
                return;
            }

            string message = await _studentService.UpdateAsync(groupId, name,surname);
            AnimatedWriteline(message,ConsoleColor.Green);  

        }

        private async Task RemoveStudent()
        {
            AnimatedWriteline("Please enter student id to delete", ConsoleColor.Red);
            int.TryParse(Console.ReadLine(), out int id);

            string message = await _studentService.RemoveAsync(id);
            AnimatedWriteline(message, ConsoleColor.Blue);
        }
    }
}
