namespace Turnierplaner
{
    public class SingleTournamentModel
    {

        // TODO - Eventuell entscheiden, ob jeder gegen jeden oder klassisch 32,16,8,4,2,1 etc
        // Vielleicht diese Klasse abstrakt machen
        public string TournamentName { get; set; }

        public DateTime? SingleTournamentDate { get; set; }

        public List<PersonModel> EnteredPlayers { get; set; } = new List<PersonModel>();

        public List<PrizeModel>? Prizes { get; set; } = new List<PrizeModel>();
    }
}
