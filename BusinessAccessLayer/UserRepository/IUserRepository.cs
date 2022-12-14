using UserRegistration3.DataAccessLayer;
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
        //25 Nov 2022
        List<string> GetGenderOptions();

        //28 Nov 2022
        List<DropDownListModel> GetGenderOptionsFromDB();  
        
        List<Gender> GetGenderOptionsSimpleWay();

        List<string> GetPhysicallyChallangedOptions();
    }
}
