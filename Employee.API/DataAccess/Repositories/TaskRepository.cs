using System;
using System.Collections.Generic;
using System.Linq;
using Employee.API.DataAccess.DomainModel;
using Employee.DataAccessLayer.DBContexts;

namespace Employee.DataAccessLayer.Repositories
{
    public class TaskRepository : ITaskRepository, IDisposable
    {
        private readonly EmployeeContext _context;

        public TaskRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Task> GetTask()
        {
            return _context.Tasks;
        }

        public Task GetTask(string TaskId)
        {
            return _context.Tasks.SingleOrDefault(a => a.Id == TaskId);
        }

        public void AddTask(Task Task)
        {
            if (Task == null)
            {
                throw new ArgumentNullException(nameof(Task));
            }

            _context.Tasks.Add(Task);
            Save();
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
