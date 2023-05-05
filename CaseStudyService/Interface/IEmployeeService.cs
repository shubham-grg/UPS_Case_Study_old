using CaseStudyService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyService.Interface
{   
    public interface IEmployeeService
    {
        string SaveEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        Task<string> DeleteEmployee(int employeeid);
        Task<string> GetEmployees();        
    }
}
