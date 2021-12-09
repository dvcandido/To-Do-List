namespace ToDoList.Api.Models
{
    public class TodoListDatabaseSettings : ITodoListDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ToDoListCollectionName { get; set; }

    }

    public interface ITodoListDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ToDoListCollectionName { get; set; }
    }

}