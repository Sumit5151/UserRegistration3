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
            @ViewData["Title"] = "Index";

            return View(userViewModels);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            UserViewModel userViewModel = new UserViewModel();
            @ViewData["Title"] = "Registration";
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Registration(UserViewModel userViewModel)
        {

            if (ModelState.IsValid == true)
            {
                userRepository.Registration(userViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
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
            userRepository.Update(userViewModel);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            userRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
