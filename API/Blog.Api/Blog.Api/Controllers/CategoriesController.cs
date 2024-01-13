using Blog.Api.Data;
using Blog.Api.Models.Domain;
using Blog.Api.Models.DTO;
using Blog.Api.Repositories.Implementation;
using Blog.Api.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult>  CreateCategory(CreateCategoryRequestDto request)
        
        {
            var Category = new Category()
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };
          await  categoryRepository.CreateAsync(Category);

            var Response = new CategoryDto()
            {
                Id=Category.Id,
                Name=Category.Name,
                UrlHandle = Category.UrlHandle,
            };
            return Ok(Response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var existingcategory = await categoryRepository.GetById(id);
            if (existingcategory is null)
                return NotFound();
            CategoryDto categoryDto = new CategoryDto() { Id = existingcategory.Id,Name= existingcategory.Name,UrlHandle= existingcategory.UrlHandle };
            return Ok(categoryDto);

        }



        //      https://localhost:7007/api/Categories
        [HttpGet]
       
        public async Task<IActionResult> GetAllCategories()
        {
            var categories= await categoryRepository.GetAllAsync();
            var response = new List<CategoryDto>();
            foreach (var category in categories) 
            {
                response.Add(new CategoryDto() { Id=category.Id,
                    Name=category.Name,
                    UrlHandle=category.UrlHandle });
            }

            return Ok(response);
        }


        //      https://localhost:7007/api/Categories
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> EditCategory(Guid id, UpdateCategoryRequestDto request)
        {
            var category = new Category()
            {
                Id=id,
                Name= request.Name,
                UrlHandle= request.UrlHandle,
            };

           category= await categoryRepository.UpdateAsync(category);

            if (category == null) return NotFound();

            else
            {
                var response=new CategoryDto()
                {
                    Id=category.Id,
                    Name= category.Name,
                    UrlHandle= category.UrlHandle,

                };
                return Ok(response);
            }
        }



        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category= await categoryRepository.DeleteAsync(id);
            if (category == null)
                return NotFound();
            var response = new CategoryDto()
            {
                Id = category.Id,
                Name=category.Name,
                UrlHandle=category.UrlHandle
            };
            return Ok(response);
        }
    }
}
