using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class AccountController : Controller
    {
        private static List<AccountViewModel> accountViewModels = new List<AccountViewModel>(); // Temporary storage for registered users

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(accountViewModel);
            }

            // Check if username already exists
            if (accountViewModels.Any(u => u.Username == accountViewModel.Username))
            {
                ModelState.AddModelError("", "Username already exists.");
                return View(accountViewModel);
            }

            accountViewModels.Add(accountViewModel); // Save user (in-memory for now)
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountViewModel accountViewModel)
        {
            var existingUser = accountViewModels.FirstOrDefault(u => u.Username == accountViewModel.Username && u.Password == accountViewModel.Password);

            if (existingUser == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(accountViewModel);
            }

            // Simulate authentication (For now, we just redirect)
            return RedirectToAction("Index", "Home");
        }
    }
}