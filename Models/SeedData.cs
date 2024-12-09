using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project_1.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Teams.Any()) 
        {
            return;
        }

        context.Teams.AddRange(
            new Team { team_name = "ARI", Wins = 89, Losses = 73},
            new Team { team_name = "ATL", Wins = 89, Losses = 73},
            new Team { team_name = "BAL", Wins = 91, Losses = 71},
            new Team { team_name = "BOS", Wins = 81, Losses = 81},
            new Team { team_name = "CHC", Wins = 83, Losses = 79},
            new Team { team_name = "CHW", Wins = 41, Losses = 121},
            new Team { team_name = "CIN", Wins = 77, Losses = 85},
            new Team { team_name = "CLE", Wins = 92, Losses = 69},
            new Team { team_name = "COL", Wins = 61, Losses = 101},
            new Team { team_name = "DET", Wins = 86, Losses = 76},
            new Team { team_name = "HOU", Wins = 88, Losses = 73},
            new Team { team_name = "KCR", Wins = 86, Losses = 76},
            new Team { team_name = "LAA", Wins = 63, Losses = 99},
            new Team { team_name = "LAD", Wins = 98, Losses = 64},
            new Team { team_name = "MIA", Wins = 62, Losses = 100},
            new Team { team_name = "MIL", Wins = 93, Losses = 69},
            new Team { team_name = "MIN", Wins = 82, Losses = 80},
            new Team { team_name = "NYM", Wins = 89, Losses = 73},
            new Team { team_name = "NYY", Wins = 94, Losses = 68},
            new Team { team_name = "OAK", Wins = 69, Losses = 93},
            new Team { team_name = "PHI", Wins = 95, Losses = 67},
            new Team { team_name = "PIT", Wins = 76, Losses = 86},
            new Team { team_name = "SDP", Wins = 93, Losses = 69},
            new Team { team_name = "SFG", Wins = 80, Losses = 82},
            new Team { team_name = "SEA", Wins = 85, Losses = 77},
            new Team { team_name = "STL", Wins = 83, Losses = 79},
            new Team { team_name = "TBR", Wins = 80, Losses = 82},
            new Team { team_name = "TEX", Wins = 78, Losses = 84},
            new Team { team_name = "TOR", Wins = 74, Losses = 88},
            new Team { team_name = "WSH", Wins = 71, Losses = 91}

        );

        context.SaveChanges();

        Player KCRPlayer = new Player {
            player_name = "Bobby Witt",
            ERA = 0,
            AVG = 0.33,
        };
        context.Add(KCRPlayer);
        context.SaveChanges();
    }
}