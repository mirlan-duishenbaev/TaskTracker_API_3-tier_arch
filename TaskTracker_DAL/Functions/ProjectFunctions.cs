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
    public class ProjectFunctions : IProject
    {
        public async Task<Project> AddProject(string name, int priority)
        {
            Project newProject = new()
            {
                Name = name,
                Priority = priority,
                StartDate = DateTime.Now,
                Status = ProjectStatus.NotStarted
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.Projects.AddAsync(newProject);
                await context.SaveChangesAsync();
            }
            return newProject;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            List<Project> projects = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                projects = await context.Projects.ToListAsync();
            }
            return projects;
        }

        public async Task<Project> DeleteProject(int id)
        {
            var obj = new Project();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                obj = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
                if (obj != null) context.Projects.Remove(obj);
                await context.SaveChangesAsync();
            }              
            return obj;
        }

        public async Task<Project> UpdateProject(int id, string name, int priority)
        {
            var project = new Project();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                project = context.Projects.FirstOrDefault(x => x.Id == id);
                if (project != null)
                {
                    project.Name = name;
                    project.Priority = priority;
                    context.Entry(project).State = EntityState.Modified;
                }
                    
                await context.SaveChangesAsync();
            }
            return project;
        }

        public async Task<Project> GetProjectById(int id)
        {
            var obj = new Project();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                obj = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            }
            if (obj != null) return obj;
            else return null;
        }
    }
}
