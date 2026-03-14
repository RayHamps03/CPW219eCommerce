using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers;

public class ProductController : Controller
{
    // Dependency injection of the database context
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

    /// <summary>
    /// Creates a new product in the database if the model state is valid.
    /// </summary>
    /// <param name="product">The product to be created.</param>
    /// <returns>
    /// A success message stored in temp data and redirect to Index view if model state is valid. 
    /// </returns>
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

    /// <summary>
    /// Displays an edit form for the specified product. 
    /// </summary>
    /// <param name="id">The ID of the product to be updated</param>
    /// <returns>
    /// A view of the product to be updated. If the product is not found, a 404 response is returned.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        Product? product = await _context.Products.
            Where(p => p.ProductId == id)
            .FirstOrDefaultAsync();

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    /// <summary>
    /// Updates the specified product in the database if the model state is valid. 
    /// </summary>
    /// <param name="product">The product to be updated.</param>
    /// <returns>
    /// A success message stored in TempData and redirects the user to the Index view.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{product.Title} was updated successfully";
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }


    /// <summary>
    /// Displays a confirmation page for deleting a specific product.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>
    /// A view showing the product to be deleted, or a 404 response if the product is not found.
    /// </returns>

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    { 
        Product? product = await _context.Products
            .Where(p => p.ProductId == id)
            .FirstOrDefaultAsync();

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    /// <summary>
    /// Permanently deletes the specified product after user confirmation.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>
    /// A redirect to the product list. If the product does not exist, redirects without performing any action.
    /// </returns>

    [ActionName("Delete")]
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Product? product = _context.Products
            .Where(p => p.ProductId == id)
            .FirstOrDefault();

        if (product == null)
        {
            return RedirectToAction(nameof(Index));
        }

        _context.Remove(product);
        await _context.SaveChangesAsync();

        TempData["Message"] = $"{product.Title} was deleted successfully";
        return RedirectToAction(nameof(Index));
    }
    
}
