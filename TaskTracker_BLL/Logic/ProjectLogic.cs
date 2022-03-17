using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Interfaces;
using TaskTracker_DAL.Models;

namespace TaskTracker_BLL.Logic
{
    public class ProjectLogic
    {
        private IProject _project = new TaskTracker_DAL.Functions.ProjectFunctions();

        public async Task<Boolean> CreateNewProject(string name, int priority)
        {
            try
            {
                var result = await _project.AddProject(name, priority);

                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Project>> GetAllProjects()
        {
            List<Project> projects = await _project.GetAllProjects();
            return projects;
        }

        public async Task<Boolean> DeleteProject(int id)
        {
            try
            {
                var result = await _project.DeleteProject(id);

                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<Boolean> UpdateProject(int id, string name, int priority)
        {
            try
            {
                var result = await _project.UpdateProject(id, name, priority);

                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Project> GetProjectById(int id)
        {
            Project project = await _project.GetProjectById(id);
            return project;
        }
    }
}
