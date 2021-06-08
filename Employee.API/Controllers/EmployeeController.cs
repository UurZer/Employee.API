using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/employee")]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProvider employeeProvider;

        public EmployeeController(IEmployeeProvider employeeProvider)
        {
            this.employeeProvider = employeeProvider;
        }

        [HttpGet("getemployees")]
        public ActionResult<IEnumerable<DataAccessLayer.Employee>> GetEmployees()
        {
            return employeeProvider.GetEmployees().ToList();
        }

        [HttpGet("getemployeebyid")]
        public ActionResult<DataAccessLayer.Employee> GetEmployee(string employeeId)
        {
            return employeeProvider.GetEmployee(employeeId);
        }

        [HttpPost("addemployee")]
        public void AddEmployee(DataAccessLayer.Employee employee)
        {
            employeeProvider.AddEmployee(employee);
        }
    }
}
