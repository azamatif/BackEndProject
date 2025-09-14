using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BackEndProject.Models;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        // Create, Update, Delete
    }
}