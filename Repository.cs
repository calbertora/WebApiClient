using System;
using System.Text.Json.Serialization;

namespace WebApiClient
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}