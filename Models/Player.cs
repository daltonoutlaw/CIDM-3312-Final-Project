using System.ComponentModel.DataAnnotations;

namespace CIDM_3312_Final_Project_1.Models;

public class Player{
    public int PlayerID {get; set;} // Primary Key

    [Display(Name = "Player Name")]
    public string player_name {get; set;} = string.Empty;
    public double ERA {get; set;}
    public double AVG {get; set;}

    [Display(Name = "Team")]
    public int TeamID {get; set;} // Foreign Key
    public Team? Team {get; set;} = default!; // Navigation Property back to Team
    
}