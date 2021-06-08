using System;
using System.Collections.Generic;
using System.Linq;
using Employee.API.DataAccess.DomainModel;

namespace Employee.API.Provider.Contracts
{
    public interface ITaskProvider
    {
        IEnumerable<Task> GetTasks();
        Task Task(string taskId);
        void AddTask(Task task);
    }
}
