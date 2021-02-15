using System.Collections.Generic;
using System.Threading.Tasks;
using CoreServices.Models;
using CoreServices.ViewModel;

namespace CoreServices.Services
{
    public interface IPostService
    {
         Task<List<Category>> GetCategories();

        Task<List<PostViewModel>> GetPosts();

        Task<PostViewModel> GetPost(int? postId);

        Task<int> AddPost(Post post);

        Task<int> DeletePost(int? postId);

        Task UpdatePost(Post post);
    }
}