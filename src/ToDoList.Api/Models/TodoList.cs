using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoList.Api.Models
{

    public class ToDoList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public List<ToDoItem> Items { get; set; }

    }

    public class ToDoItem
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime DoneDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}