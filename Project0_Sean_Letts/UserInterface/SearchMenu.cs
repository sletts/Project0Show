using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class SearchMenu : IMenus
    {
        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to search by?");
            Console.WriteLine("Enter <4> to search by name");
            Console.WriteLine("Enter <3> to search by address");
            Console.WriteLine("Enter <2> to search by zip code");
            Console.WriteLine("Enter <1> to return to the previous menu.");
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
                    return "Zip Code";
                case "3":
                    return "Address";
                case "4":
                    return "Name";
                default:
                    Console.WriteLine("Please input a valid response");
                    return MainUserChoice();
            }
        }

    }
}
