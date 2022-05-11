using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserInterface
{
    public class Menus : IMenus
    {
        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Login Menu.");
            Console.WriteLine("Enter <3> to register as a new user.");
            Console.WriteLine("Enter <2> to login as an admin.");
            Console.WriteLine("Enter <1> to login.");
            Console.WriteLine("Enter <0> to exit the program.");
            return MainUserChoice();
        }
        public string MainUserChoice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "NormalLogin";
                case "2":
                    return "AdminLogin";
                case "3":
                    return "Register";
                default:
                    Console.WriteLine("Please input a valid response");
                    return MainUserChoice();
            }
        }
        public User.UserInfo LoginMenu()
        {
            Console.Clear();
            Console.Write("Please Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please Enter your password: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            User.UserInfo newUser = new User.UserInfo();
            newUser.UserName = username; 
            newUser.Password = password;
            newUser.IsAdmin = false;
            return newUser;
        }
        public User.UserInfo RegisterMenu()
        {
            Console.Write("Please Enter your username: ");
            string username = Console.ReadLine();
            username = ValidateInput("username", username);
            Console.Write("Please Enter your password: ");
            string password = Console.ReadLine();
            password = ValidateInput("password", password);
            //need to add user to the json file
            User.UserInfo newUser = new User.UserInfo();
            newUser.UserName = username;
            newUser.Password = password;
            newUser.IsAdmin = false;
            return newUser;
        }
        public string ValidateInput(string detail, string input)
        {
            while(input.Length < 1)
            {
                Console.WriteLine($"Your input for {detail} is too short. Please enter a new {detail}.");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Is {input} what you would like as your {detail}?");
            string answer = String.Empty;
            while(true)
            {
                Console.WriteLine("Select <y> for yes and <n> for no.");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                if (answer == "y" || answer == "n")
                    break;
            }
            if (answer == "y")
                return input;
            Console.WriteLine($"Please enter your new {detail}.");
            string newInput = Console.ReadLine();
            return ValidateInput(detail, newInput);
        }
    }
}
