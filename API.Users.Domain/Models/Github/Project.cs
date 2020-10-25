using System.Text.Json.Serialization;

namespace API.Users.Domain.Models.Github
{
    public class Project
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
    }
}
