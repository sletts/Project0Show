using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class AdminMenu : IMenus
    {
        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Admin Menu");
            Console.WriteLine("Enter <4> to search for a user");
            Console.WriteLine("Enter <3> to display all users");
            Console.WriteLine("Enter <2> to proceed to the default menu");
            Console.WriteLine("Enter <1> to return to the login page.");
            Console.WriteLine("Enter <0> to exit the program.");
            return MainUserChoice();
        }
        public string MainUserChoice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return "FullExit";
                case "1":
                    return "Exit";
                case "2":
                    return "NormalMenu";
                case "3":
                    return "ShowAll";
                case "4":
                    return "Search";
                default:
                    Console.WriteLine("Please input a valid response");
                    return MainUserChoice();
            }
        }
    }
}
