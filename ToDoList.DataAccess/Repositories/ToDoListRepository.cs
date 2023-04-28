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
        private readonly ToDoListDBContext _dbContext;

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
            ToDoListModels existingTask = _dbContext.ToDoListContext.Find(task.TaskID)!; 

            existingTask.TaskName = task.TaskName;
            existingTask.TaskDescription = task.TaskDescription;
            
            _dbContext.SaveChanges();   

            return existingTask.TaskID;
        }

        public bool CompleteTask(int taskID)
        {
            ToDoListModels task = _dbContext.ToDoListContext.Find(taskID)!;

            task.IsCompleted = true;
            task.CompletedDate = DateTime.UtcNow;

            _dbContext.SaveChanges();

            return true; 
        }

        public bool UnCompleteTask(int taskID)
        {
            ToDoListModels task = _dbContext.ToDoListContext.Find(taskID)!;

            task.IsCompleted = false; 

            _dbContext.SaveChanges();

            return true; 
        }

        public bool ArchiveTask(int taskID)
        {
            ToDoListModels task = _dbContext.ToDoListContext.Find(taskID)!; 

            task.IsArchived = true;
            
            _dbContext.SaveChanges();

            return true; 
        }

        public bool UnArchiveTask(int taskID)
        {
            ToDoListModels task = _dbContext.ToDoListContext.Find(taskID)!;

            task.IsArchived = false;

            _dbContext.SaveChanges();

            return true; 
        }

        public IQueryable<ToDoListModels> GetAllTasks(ToDoListModels newModel)
        {
            return (IQueryable<ToDoListModels>)_dbContext.ToDoListContext.ToHashSet<ToDoListModels>()
                .Where(x =>
                                x.IsCompleted == newModel.IsCompleted &&
                                x.IsArchived == newModel.IsArchived);
        }

        public ToDoListModels GetTaskById(int taskID) 
        {
            ToDoListModels task = _dbContext.ToDoListContext.Find(taskID)!;

            return task; 
        }
    }
}
