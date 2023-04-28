using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Context;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Repositories
{
    public class ToDoListRepository
    {
        ToDoListDBContext _dbContext;

        public ToDoListRepository(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public int CreateTask(ToDoListModels task)
        {
            _dbContext.Add(task);
            _dbContext.SaveChanges();

            return task.TaskID; 
        }

        public int UpdateTask(ToDoListModels task)
        {
            ToDoListModels existingTask = _dbContext.ToDoListContext.Find(task.TaskID); 

            existingTask.TaskName = task.TaskName;
            existingTask.TaskDescription = task.TaskDescription;
            existingTask.CreatedDate = task.CreatedDate;
            existingTask.CompletedDate = task.CompletedDate;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.IsArchived = task.IsArchived;
            
            _dbContext.SaveChanges();   

            return existingTask.TaskID;
        }

        public bool CompleteTask(int taskID)
        {
            ToDoListModels task = _dbContext.ToDoListContext.Find(taskID);

            _dbContext.Remove(task);
            _dbContext.SaveChanges();

            return true; 
        }

        public List<ToDoListModels> GetAllTasks()
        {
            List<ToDoListModels> toDoList = _dbContext.ToDoListContext.ToList();

            return toDoList; 
        }

        public ToDoListModels GetTaskById(int taskID) 
        {
            ToDoListModels task = _dbContext.ToDoListContext.Find(taskID);

            return task; 
        }
    }
}
