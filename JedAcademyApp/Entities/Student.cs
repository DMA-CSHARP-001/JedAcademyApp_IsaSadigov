using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Entities
{
    public class Student:BaseModel
    {
        private static int _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Group Group { get; set; }
        public Student(string firstName, string lastName, Group group)
        {
            _id++;
            Id = _id;
            FirstName = firstName;
            LastName = lastName;
            Group = group;
        }
    }
}
