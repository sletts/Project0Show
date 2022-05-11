using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Resturant;
using Resturant.Resturant;

namespace Resturant
{
    public class ResturantLogic
    {
        private const string filepath = "C:/Users/Owner/Desktop/Revature/Sean-Letts/Project0_Sean_Letts/User/UserDatabase/";
        private readonly string connectionString;
        public ResturantLogic(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Gathers all of the resturant information from the user, storing it in a new object.
        /// </summary>
        /// <returns>new resturant to be added to the db</returns>
        public ResturantInfo getResturantInfo()
        {
            bool inloop = true;
            ResturantInfo newResturant = new ResturantInfo();
            while (inloop)
            {
                Console.WriteLine("Please enter the information needed to add a new resturant!");
                Console.WriteLine("We would prefer if you entered in all the information, but ");
                Console.WriteLine("Only the name, address, and Zipcode are must haves.");
                Console.WriteLine();
                Console.WriteLine($"Select <6> to change the Name. Currently: {newResturant.name}");
                Console.WriteLine($"Select <5> to change the Address. Currently: {newResturant.address}");
                Console.WriteLine($"Select <4> to change the City. Currently: {newResturant.city}");
                Console.WriteLine($"Select <3> to change the State. Currently: {newResturant.state}");
                Console.WriteLine($"Select <2> to change the zipcode. Currently: {newResturant.zipcode}");
                Console.WriteLine($"Select <1> to change the country. Currently: {newResturant.country}");
                Console.WriteLine("Select <0> to exit when done");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "0":
                        if(newResturant.name != "" & newResturant.address != "" & newResturant.zipcode != 0)
                        {
                            inloop = false;
                        }
                        else
                        {
                            Console.WriteLine("You have not written enough information in. You are missing the Zipcode, Name, or Address.");
                        }
                        break;
                    case "1":
                        Console.WriteLine("Please enter in the new country.");
                        string country = Console.ReadLine();
                        newResturant.country = country;
                        break;
                    case "2":
                        Console.WriteLine("Please enter in the new zipcode.");
                        string zipcode = Console.ReadLine();
                        int zipcodeDigits;
                        bool isParsable = Int32.TryParse(zipcode, out zipcodeDigits);
                        if (isParsable)
                            newResturant.zipcode = zipcodeDigits;
                        else
                            Console.WriteLine("You did not enter in numbers. Please select a different response.");
                        break;
                    case "3":
                        Console.WriteLine("Please enter in the new state.");
                        string state = Console.ReadLine();
                        newResturant.state = state;
                        break;
                    case "4":
                        Console.WriteLine("Please enter in the new city.");
                        string city = Console.ReadLine();
                        newResturant.address = city;
                        break;
                    case "5":
                        Console.WriteLine("Please enter in the new address.");
                        string address = Console.ReadLine();
                        newResturant.address = address;
                        break;
                    case "6":
                        Console.WriteLine("Please enter in the new name.");
                        string newName = Console.ReadLine();
                        newResturant.name = newName;
                        break;
                    default:
                        Console.WriteLine("You've entered in a response that does not work. Please try again.");
                        break;
                }
            }
            return newResturant;
        }
        /// <summary>
        /// Add a new resturant to the db
        /// </summary>
        /// <param name="newResturant"></param>
        public void addNewResturant(ResturantInfo newResturant)
        {
            var allResturants = GetAllResturants();
            allResturants.Add(newResturant);

            string commandString = "INSERT INTO Resturants (Name, Address, City, State, Zipcode, Country) " +
                "VALUES (@Name, @Address, @City, @State, @Zipcode, @Country);";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            command.Parameters.AddWithValue("@Name", newResturant.name);
            command.Parameters.AddWithValue("@Address", newResturant.address);
            command.Parameters.AddWithValue("@City", newResturant.city);
            command.Parameters.AddWithValue("@State", newResturant.state);
            command.Parameters.AddWithValue("@Zipcode", newResturant.zipcode);
            command.Parameters.AddWithValue("@Country", newResturant.country);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Get all of the resturants in the DB
        /// </summary>
        /// <returns>List of all resturants</returns>
        public List<ResturantInfo> GetAllResturants()
        {
            string commandString = "SELECT * FROM Resturants;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet); // this sends the query. DataAdapter uses a DataReader to read.
            connection.Close();

            var resturants = new List<ResturantInfo>();

            DataColumn levelColumn = dataSet.Tables[0].Columns[2];

            ReviewLogic RVL = new ReviewLogic(connectionString);
            var reviews = RVL.GetAllReviews();
            int count = 0;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                decimal rating = 0.0m;
                int numOfReviews = 0;
                count++;
                foreach(ReviewsInfo review in reviews)
                {
                    if(count == review.ResturantId)
                    {
                        rating += review.rating;
                        numOfReviews++;
                    }
                }
                if(numOfReviews != 0)
                    rating = (rating / (decimal)numOfReviews);

                resturants.Add(new ResturantInfo
                {
                    name = (string)row["Name"],
                    address = (string)row["Address"],
                    city = (string)row["City"],
                    state = (string)row["state"],
                    zipcode = (int)row["zipcode"],
                    country = (string)row["country"],
                    rating = rating,
                    numOfReviews = numOfReviews
                });

            }
            return resturants;
        }
        /// <summary>
        /// Search and display any resturants with the Name you enter
        /// </summary>
        public void searchByName()
        {
            Console.Write("Please enter the name ");
            string name = Console.ReadLine();
            var nameSearchRes = GetAllResturants();
            var filteredNameSearchRes = nameSearchRes.Where(r => r.name.Contains(name)).ToList();
            foreach (var res in filteredNameSearchRes)
            {
                Console.WriteLine(res);
            }
            Console.WriteLine("All the results are displayed. Hit enter to exit.");
            Console.ReadLine();
        }
        /// <summary>
        /// Search and display any resturants with the address you enter
        /// </summary>
        public void searchByAddress()
        {
            Console.Write("Please enter the Address ");
            string address = Console.ReadLine();
            var reses = GetAllResturants();
            var filteredRes = reses.Where(r => r.address.Contains(address)).ToList();
            foreach (var res in filteredRes)
            {
                Console.WriteLine(res);
            }
            Console.WriteLine("All the results are displayed. Hit enter to return to menu.");
            Console.ReadLine();
        }
        /// <summary>
        /// Search and display any resturants with the zipcode you enter
        /// </summary>
        public void searchByZipCode()
        {
            Console.Write("Please enter the Zip Code");
            string zipcode = Console.ReadLine();
            int zipCodeDigits;
            bool isParsable = Int32.TryParse(zipcode, out zipCodeDigits);
            if (isParsable)
            {
                var zips = GetAllResturants();
                var filteredZip = zips.Where(r => r.zipcode.Equals(zipCodeDigits)).ToList();
                foreach (var zip in filteredZip)
                {
                    Console.WriteLine(zip);
                }
                Console.WriteLine($"All the results are displayed where the zipcode is {zipcode}");
            }
            else
                Console.WriteLine("You did not enter in numbers. Please select a different response.");
            Console.WriteLine("Hit enter to return to menu.");
            Console.ReadLine();
        }

    }
}
