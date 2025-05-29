using DAL.Data;
using DAL.UserModel;
using Microsoft.AspNetCore.Identity;

namespace UI.Services
{
	public class ContextConfig
	{
		private readonly AppDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		private static readonly string seedAdminEmail = "admin@gmail.com";

		public ContextConfig(AppDbContext context,
							 UserManager<ApplicationUser> userManager,
							 RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task SeedDataAsync()
		{
			await SeedUserAsync();
		}

		private async Task SeedUserAsync()
		{
			if (!await _roleManager.RoleExistsAsync("Admin"))
			{
				await _roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			if (!await _roleManager.RoleExistsAsync("User"))
			{
				await _roleManager.CreateAsync(new IdentityRole("User"));
			}

			var adminUser = await _userManager.FindByEmailAsync(seedAdminEmail);
			if (adminUser == null)
			{
				var newAdmin = new ApplicationUser
				{
					Id = Guid.NewGuid().ToString(),
					UserName = seedAdminEmail,
					Email = seedAdminEmail,
					EmailConfirmed = true
				};

				var result = await _userManager.CreateAsync(newAdmin, "@aA12345");
				if (result.Succeeded)
					await _userManager.AddToRoleAsync(newAdmin, "Admin");
			}
		}
	}


	//public class ContextConfig
	//{


	//       private static readonly string seedAdminEmail = "admin@gmail.com";

	//	public static async Task seedDataAsync(AppDbContext context,
	//		UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager)
	//	{
	//		await seedUserAsync( userManager, roleManager);
	//	}
	//	public static async Task seedUserAsync(UserManager<ApplicationUser> userManager , 
	//		RoleManager<IdentityRole> roleManager)
	//	{
	//		if(!await roleManager.RoleExistsAsync("Admin"))
	//		{
	//			await roleManager.CreateAsync(new IdentityRole("Admin"));
	//		}
	//		if (!await roleManager.RoleExistsAsync("User"))
	//		{
	//			await roleManager.CreateAsync(new IdentityRole("User"));
	//		}

	//		var adminEmail = seedAdminEmail;
	//		var adminUser = await userManager.FindByEmailAsync(adminEmail);
	//		if(adminUser == null)
	//		{
	//			var id = Guid.NewGuid().ToString();
	//			adminUser = new ApplicationUser
	//			{
	//				Id = id,
	//				UserName = adminEmail,
	//				Email = adminEmail,
	//				EmailConfirmed = true,
	//			};

	//			var result = await userManager.CreateAsync(adminUser,"@aA12345");
	//			await userManager.AddToRoleAsync(adminUser, "Admin");
	//		}




	//	}


	//}
}
