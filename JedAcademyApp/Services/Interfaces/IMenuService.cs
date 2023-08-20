using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Services.Interfaces
{
    public interface IMenuService
    {
         Task ShowMenuAsync();
         void AnimatedWriteline(string message, ConsoleColor color);

    }
}
