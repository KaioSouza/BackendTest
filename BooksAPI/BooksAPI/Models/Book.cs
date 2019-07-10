using Newtonsoft.Json;

namespace BooksAPI.Models
{
    public class Book
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("specifications")]
        public Specification Specification { get; set; }
    }
}
