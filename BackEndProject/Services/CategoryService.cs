using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndProject.Models;
using BackEndProject.Data;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetOneAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task CreateAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cat = await _context.Categories.FindAsync(id);
        if (cat != null)
        {
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
        }
    }
}