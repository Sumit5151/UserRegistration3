using Microsoft.AspNetCore.Mvc;
using UserRegistration3.BusinessAccessLayer.UserRepository;
using UserRegistration3.Models;

namespace UserRegistration3.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;  
        }

        public IActionResult Index()
        {
            List<UserViewModel> userViewModels = userRepository.GetAllUser();

            return View(userViewModels);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            UserViewModel userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Registration(UserViewModel userViewModel)
        {
            userRepository.Registration(userViewModel);
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            UserViewModel userViewModel = userRepository.GetUserById(id);
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Update(UserViewModel userViewModel)
        {
            
            return View();
        }
    }
}
