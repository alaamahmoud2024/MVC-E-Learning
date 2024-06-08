using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.ViewModels;
using System.Linq.Expressions;

namespace MVC_E_Learning.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _userRepository;

        public UsersController(UserManager<AppUser> userManager, IMapper mapper, 
			RoleManager<IdentityRole> roleManager,
			IUserRepository userRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
			_roleManager = roleManager;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index(string? userType)
        {
			if(userType == null)
			{
                var users = await _userRepository.GetUsers(null, null);
                var userViewModels = _mapper.Map<List<AppUser>, List<UserViewModel>>(users);
                return View(userViewModels);

            }
            Expression<Func<AppUser, bool>> filter = u => u.Discriminator == userType;
            Expression<Func<AppUser, AppUser>> selector = u => new AppUser
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.FirstName + u.LastName,
                Email = u.Email,
                Discriminator = u.Discriminator
            };
			var FilteredUsers = await _userRepository.GetUsers(filter, selector);
			var FilteredUsersViewModels = _mapper.Map<List<AppUser>, List<UserViewModel>>(FilteredUsers);
            return View(FilteredUsersViewModels);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserType == "Student")
                {

                    var user = new Student { UserName = model.Email, Email = model.Email, FirstName = model.FName, LastName = model.LName, Discriminator = model.UserType };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        if (!await _userManager.IsInRoleAsync(user, "Student"))
                        {
                            await _userManager.AddToRoleAsync(user, "Student");
                        }
                        return RedirectToAction("Index");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    var user = new Instructor { UserName = model.Email, Email = model.Email, FirstName = model.FName, LastName = model.LName, Discriminator = model.UserType };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        if (!await _userManager.IsInRoleAsync(user, "Instructor"))
                        {
                            await _userManager.AddToRoleAsync(user, "Instructor");
                        }
						return RedirectToAction("Index");

					}
					foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Details(string id, string viewname = "Details")
        {
			try
			{
				if (string.IsNullOrWhiteSpace(id)) return BadRequest();
				var user = await _userManager.FindByIdAsync(id);
				if (user is null) return NotFound();
				var mappedUser = _mapper.Map<AppUser, UserViewModel>(user);
				return View(viewname, mappedUser);
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
				return RedirectToAction("Index");
			}
		}
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(id);
				if (user is null) return NotFound();
				//var mappedUser = _mapper.Map<AppUser, UserViewModel>(user);
				return View(user);
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AppUser model)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(model.Id);
				if (user is null) return NotFound();
                model.UserName = model.FirstName + model.LastName;
				user.FirstName = model.FirstName;
				user.LastName = model.LastName;
				user.UserName = model.UserName;
				//var mappedUser = _mapper.Map<UserViewModel,AppUser>(model);
				var result = await _userManager.UpdateAsync(user);
				 return RedirectToAction("Index", "Users");
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
				return View(model);
			}

		}
		public async Task<IActionResult> Delete(string id)
		{
			return await Details(id, nameof(Delete));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id, UserViewModel model)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(id);
				if (user is null) return NotFound();

				await _userManager.DeleteAsync(user);
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}
			return View();
		}

	}
}
