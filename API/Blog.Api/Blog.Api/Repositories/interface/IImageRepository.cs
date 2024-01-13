using Blog.Api.Models.Domain;

namespace Blog.Api.Repositories.Interface
{
    public interface IImageRepository
{

        Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);

        Task<IEnumerable<BlogImage>> GetAll();
    }
}
