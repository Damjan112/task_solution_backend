using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Immutable;
using TaskWebApp.Context;
using TaskWebApp.Models;
using TaskWebApp.Services.IServices;

namespace TaskWebApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApiContext _dbContext;
        
        public TaskService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Zadaca> CreateTask(Zadaca zadaca)
        {
            _dbContext.tasks.Add(zadaca);
            await _dbContext.SaveChangesAsync();
            return zadaca;
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            var existingTask = await _dbContext.tasks.FindAsync(taskId);
            if(existingTask == null)
            {
                return false;
            }

            _dbContext.tasks.Remove(existingTask);
            await _dbContext.SaveChangesAsync();
            return true; 
        }

        public async Task<List<Zadaca>> GetAllTasks()
        {
            return await _dbContext.tasks.ToListAsync();
        }

        public async Task<Zadaca> GetTaskById(int taskId)
        {
            return await _dbContext.tasks.FindAsync(taskId);
        }

        public async Task<Zadaca> UpdateTask(int taskId, Zadaca updatedZadaca)
        {

            var existingTask = await _dbContext.tasks.FindAsync(taskId);
            if(existingTask == null )
            {
                return null;
            }

            existingTask.DueDate = updatedZadaca.DueDate;
            existingTask.TaskName = updatedZadaca.TaskName;
            existingTask.Status = updatedZadaca.Status;
            existingTask.Description = updatedZadaca.Description;

            await _dbContext.SaveChangesAsync();

            return existingTask;

        }
    }
}
