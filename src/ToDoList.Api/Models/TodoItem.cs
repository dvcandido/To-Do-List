using System;

namespace ToDoList.Api.Models
{
    public class TodoItem
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime DoneDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}