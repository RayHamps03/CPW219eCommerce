using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class MemberController : Controller
{
    private readonly ProductDbContext _context;

    public MemberController(ProductDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationViewModel register)
    {
        if (ModelState.IsValid)
        {
            // Map ViewModel to Member model tracked by db
            Member newMember = new()
            {
                Username = register.Username,
                Email = register.Email,
                Password = register.Password,
                DateOfBirth = register.DateOfBirth
            };

            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(register);
    }
}
