using ToDoList.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Api.Services
{
    public class ToDoListService
    {
        private readonly IMongoCollection<TodoList> _toDoLists;

        public ToDoListService(ITodoListDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);

            _toDoLists = dataBase.GetCollection<TodoList>(settings.ToDoListCollectionName);
        }

        public List<TodoList> Get() =>
            _toDoLists.Find(todo => true).ToList();
        public List<TodoList> Get(string id) =>
            _toDoLists.Find(todo => todo.Id == id).ToList();

        public TodoList Create(TodoList toDoList)
        {
            _toDoLists.InsertOne(toDoList);
            return toDoList;
        }

        public void Update(string id, TodoList toDoList) =>
            _toDoLists.ReplaceOne(todo => todo.Id == id, toDoList);

        public void Remove(TodoList toDoList) =>
            _toDoLists.DeleteOne(todo => todo.Id == toDoList.Id);

        public void Remove(string id) =>
            _toDoLists.DeleteOne(todo => todo.Id == id);

    }

}