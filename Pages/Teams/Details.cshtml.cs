using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM_3312_Final_Project_1.Models;

namespace CIDM_3312_Final_Project_1.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly CIDM_3312_Final_Project_1.Models.AppDbContext _context;

        public DetailsModel(CIDM_3312_Final_Project_1.Models.AppDbContext context)
        {
            _context = context;
        }

        public Team Team { get; set; } = default!;

        [BindProperty]
        public int PlayerIDToDelete {get; set;}


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.Include(m => m.Players).FirstOrDefaultAsync(m => m.TeamID == id);



            if (team is not null)
            {
                Team = team;

                return Page();
            }

            return NotFound();
        }

        public IActionResult OnPostDeletePlayer(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var review = _context.Players.FirstOrDefault(r => r.PlayerID == PlayerIDToDelete);
            if (review != null)
            {
                _context.Remove(review);
                _context.SaveChanges();
            }

            Team = _context.Teams.Include(m => m.Players).First(m => m.TeamID == id);
            return Page();
        }

    }
}
