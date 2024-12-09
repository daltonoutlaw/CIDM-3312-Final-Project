using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIDM_3312_Final_Project_1.Models;

namespace CIDM_3312_Final_Project_1.Pages_Teams;

public class AddPlayerModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<AddPlayerModel> _logger;

    [BindProperty]
    public Player Player {get; set;} = default!;
    public SelectList TeamsDropDown {get; set;} = default!;



    public AddPlayerModel(AppDbContext context, ILogger<AddPlayerModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        TeamsDropDown = new SelectList(_context.Teams.ToList(), "TeamID", "team_name");
    }

   public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var e in allErrors)
            {
                _logger.LogError($"Error: {e.ErrorMessage}");
            }
            return Page();
        }

        _context.Players.Add(Player);
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }


}
