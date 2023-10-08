using System.Diagnostics.Metrics;
using TaskWebApp.Models;

namespace TaskWebApp.Services.IServices
{
    public interface ITaskService
    {
        Task<List<Zadaca>> GetAllTasks();
        Task<Zadaca> GetTaskById(int taskId);
        Task<Zadaca> CreateTask(Zadaca zadaca);
        Task<Zadaca> UpdateTask(int taskId, Zadaca zadaca);
        Task<bool> DeleteTask(int taskId);
    }
}
