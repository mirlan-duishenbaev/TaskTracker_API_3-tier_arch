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
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TaskLogic taskLogic = new TaskLogic();

        [Route("add")]
        [HttpGet]
        public async Task<Boolean> AddTask(string name, string description, int projectId)
        {
            bool result = await taskLogic.CreateNewTask(name, description, projectId);
            return result;
        }

        [Route("show_all")]
        [HttpGet]
        public async Task<List<TaskViewModel>> GetAllTasks()
        {
            List<TaskViewModel> taskList = new List<TaskViewModel>();
            var tasks = await taskLogic.GetAllTasks();
            if(tasks.Count > 0)
            {
                foreach(var task in tasks)
                {
                    TaskViewModel currentTask = new TaskViewModel
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        Status = task.Status.ToString(),
                        Priority = task.Priority,
                        ProjectId = task.ProjectId,
                    };
                    taskList.Add(currentTask);
                }
            }
            return taskList;
        }

        [Route("delete")]
        [HttpGet]
        public async Task<Boolean> DeleteTask(int id)
        {
            bool result = await taskLogic.DeleteTask(id);
            return result;
        }

        [Route("update")]
        [HttpGet]
        public async Task<Boolean> UpdateTask(int id, string name, string description, int priority)
        {
            bool result = await taskLogic.UpdateTask(id, name, description, priority);
            return result;
        }

        [Route("show")]
        [HttpGet]
        public async Task<TaskViewModel> GetTask(int id)
        {
            var task = await taskLogic.GetTaskById(id);
            TaskViewModel currentTask = new TaskViewModel
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status.ToString(),
                Priority = task.Priority
            };
            return currentTask;
        }
    }
}
