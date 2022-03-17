using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Models;

namespace TaskTracker_DAL.Interfaces
{
    public interface ITask
    {
        Task<ProjectTask> AddTask(string name, string description, int projectId);
        Task<List<ProjectTask>> GetAllTasks();
        Task<ProjectTask> DeleteTask(int id);
        Task<ProjectTask> UpdateTask(int id, string name, string description, int priority);
        Task<ProjectTask> GetTaskById(int id);
    }
}
