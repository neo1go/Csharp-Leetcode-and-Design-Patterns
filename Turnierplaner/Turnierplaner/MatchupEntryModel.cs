namespace Turnierplaner
{
    //Hier wird ein Team repräsentiert welches spielt 
    public class MatchupEntryModel
    {
        public TeamModel? TeamCompeting { get; set; }

        //Score nur für dieses eine Team
        public double Score { get; set; }

        //repräsentiert das vorherige Spiel aus dem diese Team als Gewinner hervor ging, falls vorher schon gespielt wurde
        public MatchModel ParentMatchup { get; set; }
    }
}
