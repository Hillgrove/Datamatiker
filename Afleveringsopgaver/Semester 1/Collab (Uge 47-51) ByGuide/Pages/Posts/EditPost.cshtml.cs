
// By: Jesper Højlund

using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Posts
{
    public class EditPostModel : PageModel
    {
        #region Instance Fields
        private IPostService _postService;
        #endregion

        #region Constructor
        public EditPostModel(IPostService postService)
        {
            _postService = postService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public Models.Post Post { get; set; }
        #endregion

        #region Methods
        public IActionResult OnGet(int id)
        {
            Post = _postService.GetPost(id);
            if (Post == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _postService.UpdatePost(Post);
            return RedirectToPage("GetAllPosts");
        }
        #endregion
    }
}
