using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Models;

namespace TaskTracker_DAL.Interfaces
{
    public interface IProject
    {
        Task<Project> AddProject(string name, int priority);
        Task<List<Project>> GetAllProjects();
        Task<Project> DeleteProject(int id);
        Task<Project> UpdateProject(int id, string name, int priority);
        Task<Project> GetProjectById(int id);
    }
}
