using System;
using MongoDB.Driver;
using System.Collections.Generic;
using ReactNetDemo.Models;
using ReactNetDemo.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetDemo.Services
{
    public class ProfileService
    {
        private readonly IMongoCollection<Profile> _profiles;

        public ProfileService(ICollabHubDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _profiles = database.GetCollection<Profile>("ProfilesExample");
        }

        public List<Profile> Get() =>
            _profiles.Find(profile => true).ToList();

        public Profile Get(string id) =>
            _profiles.Find<Profile>(profile => profile.Id == id).FirstOrDefault();

        public Profile Create(Profile profile)
        {
            _profiles.InsertOne(profile);
            return profile;
        }

        public void Update(string id, Profile profileUpdate) =>
            _profiles.ReplaceOne(profile => profile.Id == id, profileUpdate);

        public void Remove(Profile profileRemove) =>
            _profiles.DeleteOne(profile => profile.Id == profileRemove.Id);

        public void Remove(string id) =>
            _profiles.DeleteOne(profile => profile.Id == id);
    }
}
