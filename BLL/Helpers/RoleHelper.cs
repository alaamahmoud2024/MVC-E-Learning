using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
	public static class RoleHelper
	{
		public static async Task<IdentityResult> ChangeUserRoleAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, string userId, string newRole)
		{
			// Find the user by their ID
			var user = await userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "User not found" });
			}

			// Check if the role exists
			if (!await roleManager.RoleExistsAsync(newRole))
			{
				return IdentityResult.Failed(new IdentityError { Description = "Role does not exist" });
			}

			// Remove user from all roles
			var currentRoles = await userManager.GetRolesAsync(user);
			var removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
			if (!removeResult.Succeeded)
			{
				return removeResult;
			}

			// Add user to the new role
			var addResult = await userManager.AddToRoleAsync(user, newRole);
			return addResult;
		}
	}

}
