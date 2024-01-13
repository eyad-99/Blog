﻿using Blog.Api.Models.Domain;

namespace Blog.Api.Repositories.Interface
{
    public interface IBlogPostRepository
{
    Task<BlogPost> CreateAsync(BlogPost blogPost);

    Task<IEnumerable<BlogPost>> GetAllAsync();

    Task<BlogPost?> GetByIdAsync(Guid id);

    Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);

    Task<BlogPost?> UpdateAsync(BlogPost blogPost);

    Task<BlogPost?> DeleteAsync(Guid id);
}
}
