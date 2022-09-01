

using BlazorOne.DbOjects;
using BlazorOne.Models;

namespace BlazorOne.Services
{
    public interface IEmpServices
    {
        List<Employee> GetEmployees();
        ResponseModel AddNewEmployee(Employee info);
        ResponseModel UpdateEmployee(Employee info);
        ResponseModel DeleteNewEmployee(int employeeId);

    }
}
