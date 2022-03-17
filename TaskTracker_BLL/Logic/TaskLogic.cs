using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Interfaces;
using TaskTracker_DAL.Models;

namespace TaskTracker_BLL.Logic
{
    public class TaskLogic
    {
        private ITask _task = new TaskTracker_DAL.Functions.TaskFunctions();

        public async Task<Boolean> CreateNewTask(string name, string description, int projectId)
        {
            try
            {
                var result = await _task.AddTask(name, description, projectId);

                if(result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                return false;
            }
        }

        public async Task<List<ProjectTask>> GetAllTasks()
        {
            List<ProjectTask> tasks = await _task.GetAllTasks();
            return tasks;
        }

        public async Task<Boolean> DeleteTask(int id)
        {
            try
            {
                var result = await _task.DeleteTask(id);

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

        public async Task<Boolean> UpdateTask(int id, string name, string description, int priority)
        {
            try
            {
                var result = await _task.UpdateTask(id, name, description, priority);

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

        public async Task<ProjectTask> GetTaskById(int id)
        {
            ProjectTask task = await _task.GetTaskById(id);
            return task;
        }
    }
}
