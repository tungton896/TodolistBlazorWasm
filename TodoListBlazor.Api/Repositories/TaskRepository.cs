using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListBlazor.Api.Data;
using Task = TodoListBlazor.Api.Entities.Task;

namespace TodoListBlazor.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _context;
        public TaskRepository(TodoListDbContext context)
        {
            _context = context;

        }
        public async Task<Task> Create(Task task)
        {
            _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> Delete(Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<IEnumerable<Task>> GetTaskList()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Task> Update(Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

    }
}
