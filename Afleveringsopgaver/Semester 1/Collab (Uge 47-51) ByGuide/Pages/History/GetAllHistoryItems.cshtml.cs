
// By: Jesper Højlund

using ByGuide.Models;
using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.History
{
    public class GetAllPostsModel : PageModel
    {
        #region Instance Fields
        private IPostService _postService;
        #endregion

        #region Constructor
        public GetAllPostsModel(IPostService postService)
        {
            _postService = postService;
        }
        #endregion

        #region Properties
        public List<Models.Post>? Posts { get; private set; }

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public string Category { get; set; }
        #endregion

        #region Methods
        public void OnGet()
        {
            Posts = _postService.GetPosts();
        }

        public IActionResult OnPostSearch()
        {
            Posts = _postService.Search(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostFilter()
        {
            Posts = _postService.Filter(Category).ToList();
            return Page();
        }
        #endregion
    }
}