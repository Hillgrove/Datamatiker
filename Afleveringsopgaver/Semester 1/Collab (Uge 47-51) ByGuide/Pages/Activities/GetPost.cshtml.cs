
// By: Jesper H�jlund

using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Activities
{
    public class GetPostModel : PageModel
    {
        #region Instance Fields
        private IPostService _postService;
        #endregion

        #region Constructor
        public GetPostModel(IPostService postService)
        {
            _postService = postService;
        }
        #endregion

        #region Properties
        public Models.Post? Post { get; private set; }

        [BindProperty(SupportsGet = true)]
        public int PostId { get; set; }
        #endregion

        #region Methods
        public IActionResult OnGet(int id)
        {
            PostId = id;
            Post = _postService.GetPost(PostId);

            if (Post == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
        #endregion
    }
}
