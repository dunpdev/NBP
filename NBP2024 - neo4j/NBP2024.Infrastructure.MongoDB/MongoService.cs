using MongoDB.Bson;
using MongoDB.Driver;
using NBP2024.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Infrastructure.MongoDB
{
    public class MongoService
    {
        IMongoCollection<Course> _courses;
        public MongoService()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("nbp");
            _courses = db.GetCollection<Course>("courses");
        }
        public async Task<Course> Create(Course course)
        {
            _courses.InsertOne(course);
            return course;
        }
        public async Task<List<Course>> GetAll()
        {
            var filter = new BsonDocument();
            return _courses.Find(filter).ToList();
        }
        public async Task<Course> GetById(int id)
        {
            var filter = Builders<Course>.Filter.Eq(q => q.Id, id);
            return _courses.Find(filter).FirstOrDefault();
        }
    }
}
