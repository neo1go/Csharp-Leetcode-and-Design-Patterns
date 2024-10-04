namespace Turnierplaner
{

    //Modellierung eines Teams mit den dazugehörigen Spielern
    public class TeamModel
    {
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        public string? TeamName { get; set; }
    }
}
