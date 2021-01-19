using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetDemo.Models
{
    public class CommentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Comment_Author_Name")]
        [JsonProperty("commentAuthorName")]
        public string CommentAuthor { get; set; }
        [BsonElement("Comment_Author_Email")]
        [JsonProperty("commentAuthorEmail")]
        public string CommentAuthorEmail { get; set; }
        [BsonElement("Email_Visible")]
        [JsonProperty("emailVisible")]
        public bool EmailVisible { get; set; }
        [BsonElement("Comment_Text")]
        [JsonProperty("commentText")]
        public string CommentText { get; set; }

    }
}
