using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee.API.DataAccess.DomainModel
{
    public class EmployeeModel
    {
        public DataAccessLayer.Employee Employee { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }
    }
}
