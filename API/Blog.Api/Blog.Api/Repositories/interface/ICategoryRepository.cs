using Blog.Api.Models.Domain;

namespace Blog.Api.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> UpdateAsync(Category category);


        Task<Category?> GetById(Guid id);

        Task<Category?> DeleteAsync(Guid id);



    }





}
