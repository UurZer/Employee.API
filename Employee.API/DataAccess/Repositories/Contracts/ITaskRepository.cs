using System;
using System.Collections.Generic;
using System.Linq;
using Employee.API.DataAccess.DomainModel;

namespace Employee.DataAccessLayer.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTask();
        Task GetTask(string taskId);
        void AddTask(Task task);
        bool Save();
    }
}
