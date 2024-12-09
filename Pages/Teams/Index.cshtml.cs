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
    public class IndexModel : PageModel
    {
        private readonly CIDM_3312_Final_Project_1.Models.AppDbContext _context;

        public IndexModel(CIDM_3312_Final_Project_1.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; } = default!;

        // Paging support
        // PageNum is the current page number we are on
        // PageSize is how many records will be displayed per page. 
        // PageNum needs BindProperty because the user decides which page we are on.
        // The user selects the page number
        // SupportsGet = true allows us to pass the PageNum through the URL with an HTTP Get Parameter 
        // This is necessary, because page numbers are not passed through normal forms
        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 15;
        public int TotalPages {get; set;}

        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Teams.Include(s => s.Players).ThenInclude(sc => sc.Team).Select(s => s);

            switch (CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(s => s.team_name);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(s => s.team_name);
                    break;
            }

            TotalPages = (int)Math.Ceiling(_context.Teams.Count() / (double)PageSize);

            Team = await _context.Teams.Include(s => s.Players).Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
