using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MongoDB.Driver;

namespace Rator.Data
{
    public class ToDoService
    {
        private readonly IMongoCollection<ToDo> _ratings;

        public ToDoService(IRatorDatabaseSettings settings)
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("DATABASE_URL"));
            client.Settings.SslSettings.CheckCertificateRevocation = false;

            var database = client.GetDatabase("admin");
            _ratings = database.GetCollection<ToDo>("ToDos");
        }

        public List<ToDo> Get() =>
            _ratings.Find(rating => true).ToList();

        public ToDo Get(string id) =>
            _ratings.Find<ToDo>(rating => rating.Id == id).FirstOrDefault();

        public ToDo Create(ToDo toDo)
        {
            _ratings.InsertOne(toDo);
            return toDo;
        }

        public void Update(string id, ToDo toDoIn) =>
            _ratings.ReplaceOne(rating => rating.Id == id, toDoIn);

        public void Remove(ToDo toDoIn) =>
            _ratings.DeleteOne(rating => rating.Id == toDoIn.Id);

        public void Remove(string id) => 
            _ratings.DeleteOne(rating => rating.Id == id);
    }
}