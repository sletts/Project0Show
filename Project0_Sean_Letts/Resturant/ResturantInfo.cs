namespace Resturant
{
    public class ResturantInfo
    {
        public string name { get; set; } = "";
        public string address { get; set; } = "";
        public string city { get; set; } = "";
        public string state { get; set; } = "";
        public int zipcode { get; set; } = 0;
        public string country { get; set; } = "";

        public decimal rating = 0.0m;

        public int numOfReviews = 0;

        public override string ToString()
        {
            Console.WriteLine("===================");
            return $"Name: {name}\nAddress: {address}\nCity: {city}\nState: {state}\nZipcode: {zipcode}\nCountry: {country}\nRating: {rating} / 5 stars from {numOfReviews} Reviews";
        }
    }
}