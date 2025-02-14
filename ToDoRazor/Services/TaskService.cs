using ToDoRazor.Data;
using ToDoRazor.Models;

namespace ToDoRazor.Services
{
    public class TaskService
    {
        private readonly TaskContext _context = default!;

        public TaskService(TaskContext context)
        {
            _context = context;
        }

        public IList<ToDoRazor.Models.Task> GetTasks()
        {
            if (_context.Tasks != null) return _context.Tasks.ToList();
            return new List<ToDoRazor.Models.Task>();
        }

        public void AddTask(ToDoRazor.Models.Task task)
        {
            if (_context.Tasks != null)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            if (_context.Tasks != null)
            {
                var task = _context.Tasks.Find(id);
                if (task != null)
                {
                    _context.Tasks.Remove(task);
                    _context.SaveChanges();
                }
            }
        }
    }
}