using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class DirectionalMenu : IMenus
    {
        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Enter <6> to write a review");
            Console.WriteLine("Enter <5> to look at reviews");
            Console.WriteLine("Enter <4> to add a new resturants");
            Console.WriteLine("Enter <3> to view all resturants");
            Console.WriteLine("Enter <2> to search for a resturant");
            Console.WriteLine("Enter <1> to return to the Login Menu");
            Console.WriteLine("Enter <0> to exit the program");
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
                    return "Search";
                case "3":
                    return "ViewAll";
                case "4":
                    return "AddNew";
                case "5":
                    return "LookReview";
                case "6":
                    return "AddReview";
                default:
                    Console.WriteLine("Please input a valid response");
                    return MainUserChoice();
            }
        }
    }
}
