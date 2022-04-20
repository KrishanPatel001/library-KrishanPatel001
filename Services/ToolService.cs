using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class ToolService
    {
        private readonly IMongoCollection<Tool> _tools;

        public ToolService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tools = database.GetCollection<Tool>(settings.BooksCollectionName);
        }

        public List<Tool> Get() =>
            _tools.Find(tool => true).ToList();

        public Tool Get(string id) =>
            _tools.Find<Tool>(tool => tool.Id == id).FirstOrDefault();

        public Tool Create(Tool tool)
        {
            _tools.InsertOne(tool);
            return tool;
        }

        public void Update(string id, Tool toolIn) =>
            _tools.ReplaceOne(tool => tool.Id == id, toolIn);

        public void Remove(Tool toolIn) =>
            _tools.DeleteOne(tool => tool.Id == toolIn.Id);

        public void Remove(string id) =>
            _tools.DeleteOne(tool => tool.Id == id);
    }
}