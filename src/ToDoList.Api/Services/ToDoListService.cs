using ToDoList.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;



namespace ToDoList.Api.Services
{
    public class ToDoListService
    {
        private readonly IMongoCollection<ToDoList.Api.Models.ToDoList> _toDoLists;

        public ToDoListService(ITodoListDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);

            _toDoLists = dataBase.GetCollection<ToDoList.Api.Models.ToDoList>(settings.ToDoListCollectionName);
        }

        public List<ToDoList.Api.Models.ToDoList> Get() =>
            _toDoLists.Find(todo => true).ToList();
        public List<ToDoList.Api.Models.ToDoList> Get(string id) =>
            _toDoLists.Find(todo => todo.Id == id).ToList();

        public ToDoList.Api.Models.ToDoList Create(ToDoList.Api.Models.ToDoList toDoList)
        {
            _toDoLists.InsertOne(toDoList);
            return toDoList;
        }

        public void Update(string id, ToDoList.Api.Models.ToDoList toDoList) =>
            _toDoLists.ReplaceOne(todo => todo.Id == id, toDoList);

        public void Remove(ToDoList.Api.Models.ToDoList toDoList) =>
            _toDoLists.DeleteOne(todo => todo.Id == toDoList.Id);

        public void Remove(string id) =>
            _toDoLists.DeleteOne(todo => todo.Id == id);

    }

}