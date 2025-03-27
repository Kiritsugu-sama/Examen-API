using Examen_AlvaroReyes.DB.Examen;
using Examen_AlvaroReyes.DB.Examen.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examen_AlvaroReyes.Services
{
    public class TaskService
    {
        private readonly ExamenEntities _context;

        public TaskService(ExamenEntities context)
        {
            _context = context;
        }

        public async Task<List<TblTask>> GetAllTasks()
        {
            return await _context.TblTasks
                .Where(u => !u.TaskDelete)
                .ToListAsync();
        }

        public async Task<TblTask> GetTaskById(int id)
        {
            var task = await _context.TblTasks
                .FirstOrDefaultAsync(u => u.TaskId == id && !u.TaskDelete);

            if (task == null)
                return null;

            return task;
        }

        public async Task<TblTask> CreateTask(TblTask task)
        {
            task.TaskCreatedAt = DateTime.Now;
            task.TaskUpdatedAt = DateTime.Now;
            task.TaskActive = true;
            task.TaskDelete = false;

            _context.TblTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TblTask> UpdateTask(int id, TblTask task)
        {
            var existingTask = await GetTaskById(id);

            if (existingTask == null)
                return null;

            existingTask.TaskName = task.TaskName;
            existingTask.TaskDescription = task.TaskDescription;
            existingTask.TaskActive = task.TaskActive;
            existingTask.TaskUpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<string> DeleteTask(int id)
        {
            var task = await GetTaskById(id);
            if (task == null)
                return "";
            task.TaskDelete = true;
            task.TaskUpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return "Sucess";

        }
    }
}
