using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndProject.Models;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<Category> GetOneAsync(int id);
    Task CreateAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}