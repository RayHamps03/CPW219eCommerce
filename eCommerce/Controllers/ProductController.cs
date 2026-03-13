using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers;

public class ProductController : Controller
{
    private readonly ProductDbContext _context;

    public ProductController(ProductDbContext context)
    {
         _context = context;
    }
    public async Task<IActionResult> Index()
    {
        List<Product> products = await _context.Products.ToListAsync();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            // Add and save the product to the database
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Used to pass data to persist over redirect
            TempData["Message"] = $"{product.Title} was created successfully.";

            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
}
