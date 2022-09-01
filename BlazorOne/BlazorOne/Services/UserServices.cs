
using BlazorOne.DbOjects;
using BlazorOne.Models;

namespace BlazorOne.Services
{
    public class UserServices : IUserServices
    {
        private readonly EmployeeDBContext _dbContext;

        public UserServices(EmployeeDBContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var array = users.ToArray();
            var data = _dbContext.UserInfos.ToList();
            foreach (var u in data)
            {
                User user = new User();

                users.Add(user);
                user.Id = u.Id;
                user.UserName = u.Username;
                user.Password = u.Password;
            }
            return users;
        }

       /* public ResponseModel CheckUser(User u)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbContext.UserInfos.Where(x => x.Id == info.Id).FirstOrDefault();
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
        }*/
    }
}
