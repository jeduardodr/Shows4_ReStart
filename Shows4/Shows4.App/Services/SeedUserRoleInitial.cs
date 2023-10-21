using Microsoft.AspNetCore.Identity;

namespace Shows4.App.Services;
public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    //Criar a Role de Administrador
    public async Task SeedRolesAsync()
    {
        if(!await _roleManager.RoleExistsAsync("Admin")) 
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();
            IdentityResult roleResult = await _roleManager.CreateAsync(role);
        }
    }
    //Criar o Administraddor
    public async Task SeedUserAsync() 
    {
        if (await _userManager.FindByEmailAsync("admin@shows4.com") == null) 
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = "admin@shows4.com";
            user.Email = "admin@shows4.com";
            user.NormalizedUserName = "ADMIN@SHOWS4.COM";
            user.NormalizedEmail = "ADMIN@SHOWS4.COM";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(user, "Password!1");
            //Caso consigo criar o utilizador , registalo como administrador
            if(result.Succeeded) 
            { 
                await _userManager.AddToRoleAsync(user, "Admin");
            }

        }
    }
}


//Comentario do Site Youtube onde aprendi/Copiei a utilizar o AdminRoles
//https://www.youtube.com/watch?v=h8gf4xhZe8g&list=PLJ4k1IC8GhW0bOvBC4Z4hTvn1fVKGE7or&index=3