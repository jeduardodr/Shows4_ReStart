using Microsoft.AspNetCore.Identity;
namespace Shows4.App.Repositories;

public class UserApplicationRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public UserApplicationRepository(
        UserManager<ApplicationUser> userManager,
        ILogger<UserManager<ApplicationUser>> logger, ApplicationDbContext context)

    {
        _context = context;
        _userManager = userManager;
    }
    //Receber o Cartao de credito da base de dados

    public async Task<string> GetCreditCardAsync(ApplicationUser user)
    {
        var userWithCreditCard = await _userManager.FindByIdAsync(user.Id);
        return userWithCreditCard?.CreditCard;
    }
    public async Task<IdentityResult> SetCreditCardAsync(ApplicationUser user, string creditCard)
    {
        // Atualize o campo CreditCard do usuário
        user.CreditCard = creditCard;

        // Salve as alterações no banco de dados
        var result = await _userManager.UpdateAsync(user);

        return result;
    }
}
