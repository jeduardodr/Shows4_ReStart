// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Shows4.App.Areas.Identity.Pages.Account.Manage;

public class UserCardModel : PageModel
{
    private readonly UserApplicationRepository _userApplicationRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public UserCardModel
        (UserApplicationRepository userApplicationRepository,
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager)

    {
        _userManager= userManager;
        _signInManager = signInManager;
        _userApplicationRepository = userApplicationRepository;
            }
    public string Username { get; set; }
    
    [BindProperty]
    public InputModel Input { get; set; }
    public class InputModel
    {
        [Display(Name = "Credit Card")]
        [RegularExpression(@"^\d{21}$", ErrorMessage = "O cartão de crédito deve conter exatamente 21 números.")]
        public string CreditCard { get; set; }
    }


    private async Task LoadAsync(ApplicationUser user)
    {
        var userName = await _userManager.GetUserNameAsync(user);
        var creditCard = await _userApplicationRepository.GetCreditCardAsync(user);
        Username = userName;

        Input = new InputModel
        {
           
            CreditCard  = creditCard
        };
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        await LoadAsync(user);
        ViewData["CreditCard"] = Input.CreditCard; // Passa a string para a View
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        if (!ModelState.IsValid)
        {
            await LoadAsync(user);
            return Page();
        }
        
        //Receber o numero de cartao de credito 
        var creditCard = await _userApplicationRepository.GetCreditCardAsync(user);
        if (Input.CreditCard != creditCard)
        {
            var setCreditCardResult = await _userApplicationRepository.SetCreditCardAsync(user, Input.CreditCard);
            if (!setCreditCardResult.Succeeded)
            {

                return RedirectToPage("./Index");
            }
        }
        await _signInManager.RefreshSignInAsync(user);
      
        return RedirectToPage();
    }
   
}

