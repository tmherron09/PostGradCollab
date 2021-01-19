using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetDemo.Models
{
    public class PostModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Author_Name")]
        [JsonProperty("authorName")]
        public string Author { get; set; }
        [BsonElement("Author_Email")]
        [JsonProperty("authorEmail")]
        public string AuthorEmail { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        [BsonElement("View_Count")]
        [JsonProperty("viewCount")]
        public int ViewCount { get; set; }
        public int Groupies { get; set; }
        [BsonElement("GitHub_Link")]
        [JsonProperty("githubLink")]
        public string GitHubLink { get; set; }
        [BsonElement("LinkedIn_Link")]
        [JsonProperty("linkedinLink")]
        public string LinkedInLink { get; set; }

    }
}
