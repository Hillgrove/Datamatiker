
// By: Jesper Højlund

using ByGuide.Models;

namespace ByGuide.Service
{
    public interface IPostService
    {
        #region Methods
        void AddPost(Post post);
        Post GetPost(int Id);
        List<Post> GetPosts();
        IEnumerable<Post> Search(string title);
        void UpdatePost(Post post);
        IEnumerable<Post> Filter(string? category = null);
        Post DeletePost(int? id);
        #endregion
    }
}
