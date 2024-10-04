namespace Turnierplaner
{
    public class MatchModel
    {
        //TODO- hier wird ein einzelnes Match eines Turniers modelliert
        //es werden immer zwei Gegner gegenübergestellt, entweder Teams oder Einzelspieler

        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        public TeamModel? Winner { get; set; }
        public int MatchupRound { get; set; } // Rundenzahl basierend auf dem TeamTournamentModel oder SingleTournamentModel

    }


}
