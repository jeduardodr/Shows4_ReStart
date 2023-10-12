using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Shows4.App.Controllers;


public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task CreateAdminUser()
    {
        // Verifique se o papel de administrador já existe, se não, crie
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Crie um novo usuário administrador
        var adminUser = new ApplicationUser { UserName = "admin", Email = "admin@shows4.com" };
        var result = await _userManager.CreateAsync(adminUser, "Admin@123"); // substitua "Admin@123" pela senha desejada

        // Se o usuário foi criado com sucesso, adicione-o ao papel de administrador
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
