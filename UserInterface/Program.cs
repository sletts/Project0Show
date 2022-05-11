global using Serilog;
using UserInterface;
using User;
using Resturant;
using Resturant.Resturant;

Menus menu = new Menus();
string connectionStringFilePath = "C:/Users/Owner/Desktop/Revature/Sean-Letts/Project0_Sean_Letts/User/UserDatabase/SQLinfo.txt";
string connectionString = File.ReadAllText(connectionStringFilePath);
IUserLogic userinfo = new UserLogic(connectionString);
ResturantLogic resLogic = new ResturantLogic(connectionString);
ReviewLogic revLogic = new ReviewLogic(connectionString);
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("C:/Users/Owner/Desktop/Revature/Sean-Letts/Project0_Sean_Letts/UserInterface/Logs/LogInfo.txt").MinimumLevel.Information().MinimumLevel.Information()// we want to save the ;ogs in this file
    .CreateLogger();

bool repeat = true;
while (repeat)
{
    string input = menu.MainMenu();
    Log.Information("Displaying Main Menu to the user");
    switch (input)
    {
        case "Exit": //exits the program
            repeat = false;
            Log.CloseAndFlush();
            break;
        case "Register": //brings user to register screen
            UserInfo newUser = menu.RegisterMenu();
            Log.Information("Displaying Register Menu to the user");
            userinfo.addNewUser(newUser);
            Log.Information("Adding a new user");
            //returns user to main menu after registering them
            break;
        case "NormalLogin":
        case "AdminLogin":
            //brings user to login menu
            UserInfo loginUser = menu.LoginMenu();
            Log.Information("Displaying Login Menu to the user");
            if (input == "AdminLogin")
            {
                loginUser.IsAdmin = true;
            }
            bool isRealUser = userinfo.validateUser(loginUser);
            Log.Information("Validates user");
            bool indrMenu = true;
            if (!isRealUser)
            {
                //if the data entered is wrong, return to menu screen
                indrMenu = false;
                Console.WriteLine("Your username or password is incorrect. Try again.");
                Console.WriteLine("You could also be trying to log in as an admin when you are not.");
                Console.WriteLine("Please press enter to go back to the login page.");
                Console.ReadLine();
                Log.Information("Incorrect details added for login.");
            }
            if(loginUser.IsAdmin == true && isRealUser)
            {
                bool inAdminMenu = true;
                while (inAdminMenu)
                {
                    //Admin Menu
                    Console.WriteLine("Welcome to the admin menu.");
                    AdminMenu adMenu = new AdminMenu();
                    string adInput = adMenu.MainMenu();
                    Log.Information("Displaying Admin Menu to the user");
                    switch (adInput)
                    {
                        case "FullExit":
                            inAdminMenu = false;
                            indrMenu = false;
                            repeat = false;
                            Log.CloseAndFlush();
                            break;
                        case "Exit":
                            inAdminMenu = false;
                            indrMenu = false;
                            break;
                        case "NormalMenu":
                            inAdminMenu=false;
                            break;
                        case "ShowAll":
                            userinfo.showAllUsers();
                            Log.Information("Displaying all users to the admin user");
                            break;
                        case "Search":
                            userinfo.searchForUser();
                            Log.Information("Searching for a user for the admin user");
                            break;
                        default:
                            Log.Information("ERROR IN ADMIN LOGIC");
                            break;
                    }
                }
            }
            DirectionalMenu drMenu = new DirectionalMenu();
            while (indrMenu)
            {
                string drInput = drMenu.MainMenu();
                Log.Information("Displaying Directional Menu to the user");
                switch (drInput)
                {
                    case "FullExit":
                        indrMenu = false;
                        repeat = false;
                        Log.CloseAndFlush();
                        break;
                    case "Exit":
                        indrMenu = false;
                        break;
                    case "AddNew":
                        ResturantInfo newResturant = resLogic.getResturantInfo();
                        resLogic.addNewResturant(newResturant);
                        //Add a new resturant. Gonna need a lot of details.
                        Console.WriteLine("You have added a new resturant to the database!");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Log.Information("Adding New Resturant");
                        break;
                    case "ViewAll":
                        var resturants = resLogic.GetAllResturants();
                        foreach (var resturant in resturants)
                            Console.WriteLine(resturant); 
                        Console.WriteLine("Press enter to exit");
                        Console.ReadLine(); 
                        Log.Information("Displaying All Resturants to the user");
                        break;
                    case "Search":
                        bool inReview = true;
                        while (inReview)
                        {
                            SearchMenu reviewMenu = new SearchMenu();
                            string reviewInput = reviewMenu.MainMenu();
                            Log.Information("Displaying Search Resturant Menu to the user");
                            switch (reviewInput)
                            {
                                case "FullExit":
                                    inReview = false;
                                    indrMenu = false;
                                    repeat = false;
                                    Log.CloseAndFlush();
                                    break;
                                case "Exit":
                                    inReview = false;
                                    break;
                                case "Name":
                                    resLogic.searchByName();
                                    Log.Information("Searching Resturants by Name");
                                    break;
                                case "Address":
                                    resLogic.searchByAddress();
                                    Log.Information("Searching Resturants by Address");
                                    break;
                                case "Zip Code":
                                    resLogic.searchByZipCode();
                                    Log.Information("Searching Resturants by Zip Code");
                                    break;
                                default:
                                    Log.Information("ERROR IN SEARCH MENU LOGIC");
                                    break;
                            }
                        }
                        break;
                    case "LookReview":
                        revLogic.LookAtAllReviews();
                        Log.Information("Displaying All Reviws to the user");
                        break;
                    case "AddReview":
                        revLogic.AddNewReview();
                        Log.Information("Adding a new review");
                        break;
                    default:
                        Log.Information("ERROR IN DIRECTIONAL MENU LOGIC");
                        break;
                }
            }
            break;
        default:
            Log.Information("ERROR IN MAIN MENU LOGIC");
            break;
    }

}
Console.WriteLine("Thank you for using our service.");