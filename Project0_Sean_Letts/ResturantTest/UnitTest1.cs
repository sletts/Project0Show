using Xunit;
using User;
using UserInterface;
using System;
using System.IO;
using Resturant;

namespace ResturantTest
{
    public class UserTest
    {
        [Fact]
        public void UserInfoTests()
        {
            var user = new UserInfo();
            user.UserName = "Bob";
            user.Password = "Password";
            user.IsAdmin = true;

            Assert.Equal(user.UserName,"Bob");
            Assert.Equal(user.Password,"Password");
            Assert.Equal(user.IsAdmin,true);
            Assert.Equal(user.ToString(), $"Username: Bob\nPassword: Password\nIs an Admin User: Yes");
        }
        [Fact]
        public void ReviewsInfoTests()
        {
            var reviews = new ReviewsInfo();
            reviews.ResturantId = 1;
            reviews.rating = 1.01m;
            reviews.reviewtext = "TEST TEST TEST";

            Assert.Equal(reviews.ResturantId, 1);
            Assert.Equal(reviews.rating, 1.01m);
            Assert.Equal(reviews.reviewtext, "TEST TEST TEST");
        }

        [Fact]
        public void ResturantInfoTests()
        {
            var resturant = new ResturantInfo();
            resturant.name = "Name";
            resturant.address = "Address";
            resturant.city = "City";

            Assert.Equal(resturant.name, "Name");
            Assert.Equal(resturant.address, "Address");
            Assert.Equal(resturant.city, "City");
        }
    }
}