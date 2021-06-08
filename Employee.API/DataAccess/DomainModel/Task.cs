using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.DataAccess.DomainModel
{
    public class Task
    {
        [Key]
        public string Id { get; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompleteTime { get; set; }
    }
}
