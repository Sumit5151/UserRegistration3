using UserRegistration3.DataAccessLayer;
using UserRegistration3.Models;

namespace UserRegistration3.BusinessAccessLayer.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly BrightDb2Context db;

        public UserRepository(BrightDb2Context _db)
        {
            this.db = _db;
        }

        public List<UserViewModel> GetAllUser()
        {
            List<User> users = db.Users.ToList();
            List<UserViewModel> userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                UserViewModel userViewModel = new UserViewModel();

                userViewModel.Id = user.Id;
                userViewModel.UserName = user.UserName;
                userViewModel.EmailId = user.EmailId;
                userViewModel.MobileNumber = user.MobileNumber;
                userViewModel.Address = user.Address;
                userViewModel.Age = user.Age;
                userViewModel.Gender = user.Gender;
                userViewModel.Password = user.Password;

                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }

        public UserViewModel GetUserById(int id)
        {
          var user= db.Users.FirstOrDefault(x=>x.Id == id); 

            UserViewModel userViewModel = new UserViewModel();

            userViewModel.Id = user.Id;
            userViewModel.UserName = user.UserName;
            userViewModel.EmailId = user.EmailId;
            userViewModel.MobileNumber = user.MobileNumber;
            userViewModel.Address = user.Address;
            userViewModel.Age = user.Age;
            userViewModel.Gender = user.Gender;
            userViewModel.Password = user.Password;

            return userViewModel;
        }

        public void Registration(UserViewModel userViewModel)
        {
            User user = new User();

            user.UserName = userViewModel.UserName;
            user.EmailId = userViewModel.EmailId;
            user.Password = userViewModel.Password;
            user.MobileNumber = userViewModel.MobileNumber;
            user.Address = userViewModel.Address;
            user.Gender= userViewModel.Gender;
            user.Age = userViewModel.Age;
           

            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(UserViewModel userViewModel)
        {
          var user =  db.Users.FirstOrDefault(x => x.Id == userViewModel.Id);

            user.UserName = userViewModel.UserName;
            user.EmailId = userViewModel.EmailId;            
            user.MobileNumber = userViewModel.MobileNumber;
            user.Address = userViewModel.Address;
            user.Gender = userViewModel.Gender;
            user.Age = userViewModel.Age;

            db.SaveChanges();



        }
        public void Delete(int id)
        {
            var user = db.Users.FirstOrDefault(x=>x.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        

    }
}
