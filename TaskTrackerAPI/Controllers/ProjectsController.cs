using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker_BLL.Logic;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private ProjectLogic projectLogic = new ProjectLogic();

        [Route("add")]
        [HttpGet]
        public async Task<Boolean> AddProject(string name, int priority)
        {
            bool result = await projectLogic.CreateNewProject(name, priority);
            return result;
        }

        [Route("show_all")]
        [HttpGet]
        public async Task<List<ProjectViewModel>> GetAllProjects()
        {
            List<ProjectViewModel> projectList = new List<ProjectViewModel>();
            var projects = await projectLogic.GetAllProjects();
            if (projects.Count > 0)
            {
                foreach (var project in projects)
                {
                    ProjectViewModel currentProject = new ProjectViewModel
                    {
                        Id = project.Id,
                        Name = project.Name,
                        Status = project.Status.ToString(),
                        Priority = project.Priority,
                    };
                    projectList.Add(currentProject);
                }
            }
            return projectList;
        }

        [Route("delete")]
        [HttpGet]
        public async Task<Boolean> DeleteProject(int id)
        {
            bool result = await projectLogic.DeleteProject(id);
            return result;
        }

        [Route("update")]
        [HttpGet]
        public async Task<Boolean> UpdateProject(int id, string name, int priority)
        {
            bool result = await projectLogic.UpdateProject(id, name, priority);
            return result;
        }

        [Route("show")]
        [HttpGet]
        public async Task<ProjectViewModel> GetProject(int id)
        {
            var project = await projectLogic.GetProjectById(id);
            ProjectViewModel currentProject = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Status = project.Status.ToString(),
                Priority = project.Priority
            };
            return currentProject;
        }
    }
}
