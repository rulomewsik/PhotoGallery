using Newtonsoft.Json;

namespace PhotoGallery.Core.Models
{
    public class ProfileData
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("firstName")] public string FirstName { get; set; }

        [JsonProperty("lastName")] public string LastName { get; set; }

        [JsonProperty("maidenName")] public string MaidenName { get; set; }

        [JsonProperty("age")] public int Age { get; set; }

        [JsonProperty("gender")] public string Gender { get; set; }

        [JsonProperty("email")] public string Email { get; set; }

        [JsonProperty("phone")] public string Phone { get; set; }

        [JsonProperty("username")] public string Username { get; set; }

        [JsonProperty("password")] public string Password { get; set; }

        [JsonProperty("birthDate")] public string BirthDate { get; set; }

        [JsonProperty("image")] public string Image { get; set; }

        [JsonProperty("bloodGroup")] public string BloodGroup { get; set; }

        [JsonProperty("height")] public int Height { get; set; }

        [JsonProperty("weight")] public double Weight { get; set; }

        [JsonProperty("domain")] public string Domain { get; set; }

        [JsonProperty("ip")] public string Ip { get; set; }

        [JsonProperty("address")] public Address Address { get; set; }

        [JsonProperty("macAddress")] public string MacAddress { get; set; }

        [JsonProperty("university")] public string University { get; set; }

        [JsonProperty("company")] public Company Company { get; set; }

        [JsonProperty("ein")] public string Ein { get; set; }

        [JsonProperty("ssn")] public string Ssn { get; set; }

        [JsonProperty("userAgent")] public string UserAgent { get; set; }
    }

    public class Address
    {
        [JsonProperty("address")] public string ProfileAddress { get; set; }

        [JsonProperty("city")] public string City { get; set; }

        public Coordinates Coordinates { get; set; }

        [JsonProperty("postalCode")] public string PostalCode { get; set; }

        [JsonProperty("state")] public string State { get; set; }
    }

    public class Company
    {
        [JsonProperty("address")] public Address Address { get; set; }

        [JsonProperty("department")] public string Department { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("title")] public string Title { get; set; }
    }

    public class Coordinates
    {
        public double Lat { get; set; }

        public double Lng { get; set; }

        public double Alt { get; set; }
    }
}