using JedAcademyApp.Services.Implementations;
using JedAcademyApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Use Task.Run to run an async method in a non-async Main.
            Task.Run(async () =>
            {
                MenuService menuService = new MenuService();
                await menuService.ShowMenuAsync();
                IMenuService menuService2 = new MenuService();
                menuService2.ShowMenuAsync();
            }).GetAwaiter().GetResult();
        }
    }
}
