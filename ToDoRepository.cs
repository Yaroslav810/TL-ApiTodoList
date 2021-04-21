﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList
{
    public class ToDoRepository
    {
        private static List<ToDo> DataBase = new List<ToDo>();

        private class ToDo
        {
            public int Id { get; }
            public string Name { get; set; }
            public bool Done { get; set; }

            public DateTime creationDate { get; }

            public ToDo(int id, string name, bool done)
            {
                Id = id;
                Name = name;
                Done = done;
                creationDate = DateTime.Now;
            }
        }

        private int GetId() => DataBase.Count > 0 ? DataBase.Max(x => x.Id) + 1 : 1;

        public List<ToDoDto> GetAll()
        {
            return DataBase.ConvertAll(x => new ToDoDto
            {
                Id = x.Id,
                Name = x.Name,
                Done = x.Done,
            });
        }

        public int Create(ToDoDto toDoDto)
        {
            int id = GetId();
            ToDo todo = new ToDo(id, toDoDto.Name, false);
            DataBase.Add(todo);

            return id;
        }

        public void Update(int id, ToDoDto toDoDto)
        {
            ToDo finded = DataBase.FirstOrDefault(x => x.Id == id);
            if (finded == null) return;
            finded.Name = toDoDto.Name;
            finded.Done = toDoDto.Done;
        }
    }
}
