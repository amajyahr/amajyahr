using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject_AReeder.Pages
{
    public class ResultModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public double FinalGrade { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LetterGrade { get; set; } = "";

        public void OnGet()
        {
           
        }
    }
}
