

using BlazorOne.DbOjects;
using BlazorOne.Models;

namespace BlazorOne.Services
{
    public class EmpServices : IEmpServices
    {
        private readonly EmployeeDBContext _dbContext;

        public EmpServices(EmployeeDBContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            var array = employees.ToArray();
            var data = _dbContext.EmployeeInfos.ToList();
            foreach (var item in data)
            {
                Employee employee = new Employee();

                employees.Add(employee);
                employee.Id = item.Id;
                employee.Name = item.Name;
                employee.YearsOfExperience = item.YearsOfExperience;
                employee.Company = item.Company;
            }
            return employees;
        }

        public ResponseModel AddNewEmployee(Employee info)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbContext.EmployeeInfos.Where(x => x.Id == info.Id).FirstOrDefault();
                if (data == null)
                {
                    EmployeeInfo employeeInfo = new EmployeeInfo();
                    employeeInfo.Id = info.Id;
                    employeeInfo.Name = info.Name;
                    employeeInfo.YearsOfExperience = info.YearsOfExperience;
                    employeeInfo.Company = info.Company;
                    _dbContext.EmployeeInfos.Add(employeeInfo);
                    _dbContext.SaveChanges();

                }
                response.Status = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel UpdateEmployee(Employee info)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbContext.EmployeeInfos.Where(x => x.Id == info.Id).FirstOrDefault();
                if (data != null)
                {
                    data.Name = info.Name;
                    data.Company = info.Company;
                    data.YearsOfExperience = info.YearsOfExperience;
                    _dbContext.EmployeeInfos.Update(data);
                    _dbContext.SaveChanges();
                    response.Status = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Başarısız";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel DeleteNewEmployee(int employeeId)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbContext.EmployeeInfos.Where(x => x.Id == employeeId).FirstOrDefault();
                if (data != null)
                {
                    _dbContext.EmployeeInfos.Remove(data);
                    _dbContext.SaveChanges();
                    response.Status = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Başarısız";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
