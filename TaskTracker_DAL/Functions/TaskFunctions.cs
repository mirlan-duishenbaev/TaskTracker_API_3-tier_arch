using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.DataContext;
using TaskTracker_DAL.Interfaces;
using TaskTracker_DAL.Models;

namespace TaskTracker_DAL.Functions
{
    public class TaskFunctions : ITask
    {
        public async Task<ProjectTask> AddTask(string name, string description, int projectId)
        {
            ProjectTask newTask = new()
            {
                Name = name,
                Description = description,
                ProjectId = projectId
            };

            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.Tasks.AddAsync(newTask);
                await context.SaveChangesAsync();
            }

            return newTask;
        }

        public async Task<List<ProjectTask>> GetAllTasks()
        {
            List<ProjectTask> tasks = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                tasks = await context.Tasks.ToListAsync();
            }
            return tasks;
        }

        public async Task<ProjectTask> DeleteTask(int id)
        {
            var obj = new ProjectTask();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                obj = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (obj != null) context.Tasks.Remove(obj);
                await context.SaveChangesAsync();
            }
            return obj;
        }

        public async Task<ProjectTask> UpdateTask(int id, string name, string description, int priority)
        {
            var task = new ProjectTask();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                task = context.Tasks.FirstOrDefault(x => x.Id == id);
                if (task != null)
                {
                    task.Name = name;
                    task.Description = description;
                    task.Priority = priority;
                    context.Entry(task).State = EntityState.Modified;
                }

                await context.SaveChangesAsync();
            }
            return task;
        }

        public async Task<ProjectTask> GetTaskById(int id)
        {
            var obj = new ProjectTask();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                obj = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            }
            if (obj != null) return obj;
            else return null;
        }
    }
}
