using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //ViewBag.GenderOptions = userRepository.GetGenderOptions();
            //28 Nov 2022
            //var genders = userRepository.GetGenderOptionsFromDB();
            //ViewBag.GenderOptions = new SelectList(genders, "Id", "Text");

            ViewBag.GenderOptions = userRepository.GetGenderOptionsSimpleWay();

            ViewBag.PhysicallyChallangedOptions = userRepository.GetPhysicallyChallangedOptions();



            ViewData["Title"] = "Registration";
            UserViewModel userViewModel = new UserViewModel();

            //userViewModel.GenderOpitons= userRepository.GetGenderOptions();


            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Registration(UserViewModel userViewModel)
        {

            //25 Nov 2022
            if(userViewModel.IsTermsAndConditionsChecked == false)
            {
                ModelState.AddModelError("IsTermsAndConditionsChecked", "Please accept terms and condions");
            }


            if (ModelState.IsValid == true)
            {
                userRepository.Registration(userViewModel);
                return RedirectToAction(nameof(Index));
            }
            //25 Nov 2022
            //ViewBag.GenderOptions = userRepository.GetGenderOptions();
            //28 Nov 2022
            var genders = userRepository.GetGenderOptionsFromDB();
            ViewBag.GenderOptions = new SelectList(genders, "Id", "Text");
            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {//25 Nov 2022
            //ViewBag.GenderOptions = userRepository.GetGenderOptions();
            var genders = userRepository.GetGenderOptionsFromDB();

            //28 Nov 2022
            ViewBag.GenderOptions = new SelectList(genders, "Id", "Text");
            UserViewModel userViewModel = userRepository.GetUserById(id);

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Update(UserViewModel userViewModel)
        {//25 Nov 2022
            ViewBag.GenderOptions = userRepository.GetGenderOptions();
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
