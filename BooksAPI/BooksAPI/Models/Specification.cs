using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BooksAPI.Models
{
    public class Specification
    {
        [JsonProperty("Originally published")]
        public DateTime OriginallyPublished { get; set; }
        [JsonProperty("Author")]
        public string Author { get; set; }
        [JsonProperty("Page count")]
        public int PageCount { get; set; }
        [JsonProperty("Illustrator")]
        public List<string> Illustrators { get; set; }
        [JsonProperty("Genres")]
        public List<string> Genres { get; set; }
    }
}
