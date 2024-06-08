using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RolesController(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {

            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var roles = await _roleManager.Roles.Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,

                }).ToListAsync();
                return View(roles);
            }
            var role = await _roleManager.FindByNameAsync(name);

            if (role == null) return View(Enumerable.Empty<RoleViewModel>());

            var mappedRole = _mapper.Map<IdentityRole, RoleViewModel>(role);

            return View(new List<RoleViewModel> { mappedRole });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedRole = _mapper.Map<IdentityRole>(model);
                var result = await _roleManager.CreateAsync(mappedRole);
                if (result.Succeeded) return RedirectToAction("Index");

                foreach (var role in result.Errors)
                {
                    ModelState.AddModelError("", role.Description);
                }

            }
            return View(model);
        }


        public async Task<IActionResult> Details(string id, string viewname = "Details")
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null) return NotFound();

            var mappedRole = _mapper.Map<IdentityRole, RoleViewModel>(role);
            return View(viewname, mappedRole);
        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, nameof(Edit));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, RoleViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role is null) return NotFound();
                role.Name = model.Name;

                await _roleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View(model);

        }

        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, nameof(Delete));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id, RoleViewModel model)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role is null) return NotFound();

                await _roleManager.DeleteAsync(role);
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
