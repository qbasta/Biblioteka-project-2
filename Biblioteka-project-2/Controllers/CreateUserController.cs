using Biblioteka_project_2.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka_project_2.Controllers
{
    public class CreateUserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public CreateUserController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            IList<IdentityRole> roleList = await Task.Run(() => _roleManager.Roles.ToList());

            var roleNames = new string[roleList.Count()];
            for (int i = 0; i < roleList.Count(); i++)
            {
                roleNames[i] = roleList[i].Name;
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(User createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User user;
               
                user = UserStore<User>.CreateUser();
                

                user.UserName = createUserViewModel.Email;
                user.Email = createUserViewModel.Email;
                user.PhoneNumber = createUserViewModel.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(user, createUserViewModel.PasswordHash);

                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(user, createUserViewModel.Role);
                    if (!result.Succeeded)
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return await CreateUser();
        }
        private static class UserStore<T>
        {
            public static T CreateUser()
            {
                try
                {
                    return Activator.CreateInstance<T>();
                }
                catch
                {
                    throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. ");
                }
            }
        }
    }
}
