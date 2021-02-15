using CoreServices.Models;
using CoreServices.Services;
using Xunit;
using NSubstitute;
using System.Threading.Tasks;

namespace CoreServices.Tests
{
    public class CustomerServiceTests
    {
        private  readonly IPostService _sut;

        private readonly BlogDBContext _blogDbContext = Substitute.For<BlogDBContext>();

        public CustomerServiceTests(){
            
            _sut = new PostService(_blogDbContext);
        }

        [Fact]
        public async Task GetPost_ReturnPost_IfExists(){
            
            int postId = 1;

            var Post= await _sut.GetPost(postId);

            Assert.Equal(postId, Post.PostId);
        }
    }
}