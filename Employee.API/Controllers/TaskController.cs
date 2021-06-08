using System;
using System.Collections.Generic;
using System.Linq;
using Employee.API.DataAccess.DomainModel;
using Employee.API.Provider.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskProvider taskProvider;

        public TaskController(ITaskProvider taskProvider)
        {
            this.taskProvider= taskProvider;
        }


        [HttpGet()]
        public ActionResult<IEnumerable<Task>> GetTask()
        {
            return taskProvider.GetTasks().ToList();
        }

        [HttpGet("{taskId}")]
        public ActionResult<Task> GetTask(string taskId)
        {
            return taskProvider.Task(taskId);
        }

        [HttpPost]
        public void AddTask(Task task)
        {
            taskProvider.AddTask(task);
        }
    }
}
