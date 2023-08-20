using JedAcademyApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Entities
{
    public class Group:BaseModel
    {
        private static int _id { get; set; }
        public string GroupName { get; set; }
        public int StudentCount { get; set; }
        public GroupEnum groupEnums { get; set; }
        public List<Student> Students;
        public Student Student { get; set; }

        public Group(string GroupName, GroupEnum groupEnum) 
        {
            _id++;
            Id= _id;
            Students= new List<Student>();
            this.GroupName = GroupName;
            groupEnums = groupEnum;
        }
        
    }
}
