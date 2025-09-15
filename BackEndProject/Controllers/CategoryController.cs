using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BackEndProject.Models;
using BackEndProject.Services;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var category = await _categoryService.GetOneAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetOneAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.UpdateAsync(category);
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}