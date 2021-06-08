using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.API.Provider.Contracts;
using Employee.DataAccessLayer.Repositories;

namespace Employee.Provider
{
    public class TaskProvider : ITaskProvider
    {
        private readonly ITaskRepository taskRepository;

        public TaskProvider(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        public void AddTask(API.DataAccess.DomainModel.Task task)
        {
            taskRepository.AddTask(task);
        }

        public IEnumerable<API.DataAccess.DomainModel.Task> GetTasks()
        {
            return taskRepository.GetTask();
        }

        public API.DataAccess.DomainModel.Task Task(string taskId)
        {
            return taskRepository.GetTask(taskId);
        }
    }
}
