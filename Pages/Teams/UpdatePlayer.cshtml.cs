using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIDM_3312_Final_Project_1.Models;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project_1.Pages_Teams;

public class UpdatePlayerModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<UpdatePlayerModel> _logger;

    [BindProperty]
    public Player Player {get; set;} = default!;

    public SelectList TeamsDropDown {get; set;} = default!;


    public UpdatePlayerModel(AppDbContext context, ILogger<UpdatePlayerModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var player = _context.Players.Find(id);
        if (player == null)
        {
            return NotFound();
        }
        else
        {
            Player = player;
        }

        TeamsDropDown = new SelectList(_context.Teams.ToList(), "TeamID", "team_name");


        return Page();
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

    _context.Attach(Player).State = EntityState.Modified;
    _context.SaveChanges();

    TeamsDropDown = new SelectList(_context.Teams.ToList(), "TeamID", "Wins", "Losses");


    return RedirectToPage("./Index");
}


}
