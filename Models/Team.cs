using System.ComponentModel.DataAnnotations;

namespace CIDM_3312_Final_Project_1.Models;

public class Team
{
    public int TeamID {get; set;} // Primary Key

    [Display(Name = "Team Name")]
    public string team_name {get; set;} = string.Empty;
    public int Wins {get; set;}
    public int Losses {get; set;}
     public List<Player> Players {get; set;} = default!;
}