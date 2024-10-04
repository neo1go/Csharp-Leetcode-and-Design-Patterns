namespace Turnierplaner
{
    public class TeamTournamentModel
    {
        //TODO - Nimmt alle Teams aus der aktiven Teamsliste auf
        public string TournamentName { get; set; }
        public DateTime? TeamTournamentDate { get; set; }

        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
    }
}

//TODO - Die Gebühren werde ich später als Interface EntryFee einfügen
