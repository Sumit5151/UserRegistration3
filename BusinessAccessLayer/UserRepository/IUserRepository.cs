using UserRegistration3.Models;

namespace UserRegistration3.BusinessAccessLayer.UserRepository
{
    public interface IUserRepository
    {
        //abstarct method
        void Registration(UserViewModel userViewModel);
        List<UserViewModel> GetAllUser();
        void Update(UserViewModel userViewModel);
        void Delete(int id);
        UserViewModel GetUserById(int id);

        
    }
}
