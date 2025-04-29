using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject_AReeder.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {

        [BindProperty]
        public double ExamG { get; set; }

        [BindProperty]
        public double ExamW { get; set; }

        [BindProperty]
        public double LabG { get; set; }

        [BindProperty]
        public double LabW { get; set; }

        [BindProperty]
        public double QuizG { get; set; }

        [BindProperty]
        public double QuizW { get; set; }

        public double FinalGrade { get; set; }
        public string? LetterGrade { get; set; }

        public async Task<IActionResult> OnPost()
        {
            double totalWeight = ExamW + LabW + QuizW;

            // Check if the total weight is 100
            if (Math.Abs(totalWeight - 100) > 0.01)
            {
                ModelState.AddModelError(string.Empty, "Total weight must equal 100%.");
                
            }

            if (!ModelState.IsValid)
            {
                // Stay on the same page and show errors!
                return Page();
            }

            // Calculate the final grade
            FinalGrade = (ExamG * ExamW / 100) +
                         (LabG * LabW / 100) +
                         (QuizG * QuizW / 100);

            // Determine the letter grade
            if (FinalGrade >= 90)
                LetterGrade = "A";
            else if (FinalGrade >= 80)
                LetterGrade = "B";
            else if (FinalGrade >= 70)
                LetterGrade = "C";
            else if (FinalGrade >= 60)
                LetterGrade = "D";
            else
                LetterGrade = "F";

            // Redirect to Result page with calculated grades
            return RedirectToPage("/Result", new { finalGrade = FinalGrade, letterGrade = LetterGrade });
        }
    }
}

