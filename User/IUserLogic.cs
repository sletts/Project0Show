using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public interface IUserLogic
    {
        /// <summary>
        /// Add a new user to the database
        /// </summary>
        /// <param name="newuser"></param>
        void addNewUser(UserInfo newuser);
        /// <summary>
        /// Checks to see if the user logging in, is an exisiting user in the database
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns> returns true if exisiting user, false if they are not.</returns>
        bool validateUser(UserInfo loginUser);
        /// <summary>
        /// Gathers all of the users from the database.
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetAllUsers();
        /// <summary>
        /// Displays all user details
        /// </summary>
        public void showAllUsers();
        /// <summary>
        /// searches for a user
        /// displays that user's details
        /// </summary>
        public void searchForUser();
    }
}
