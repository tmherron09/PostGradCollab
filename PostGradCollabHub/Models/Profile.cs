using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PostGradCollabHub.Models
{
    public class Profile
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("First_Name")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [BsonElement("Last_Name")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonProperty("githubLink")]
        public string GitHubLink { get; set; }
        [JsonProperty("linkedinLink")]
        public string LinkedInLink { get; set; }



    }
}
