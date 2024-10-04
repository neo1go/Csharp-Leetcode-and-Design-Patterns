namespace Turnierplaner
{
    public class PrizeModel
    {
        public int PlaceNumber { get; set; }
        public decimal PriceAmount { get; set; }
        public double PrizePercentage { get; set; }
        // TODO - Hier wird die Art der Preisverteilung geregelt
        // Klassisch  3ter 2ter 1ter
        //Top 10 
        //bei vielen Spielern vielleicht Top 12 oder prozentual. und/oder alle folgenden Spieler erhalten einen kleinen Wert zurück
        // Beispiel 30 Euro Teilnahmegebühr - die letzten Plätze immer noch 14 Euro
        // 50 Spieler * 30 = 1500 Euro  1 450Eur 2 200Eur 3 100Eur 4 50Eur 5 40Eur 6 30 Eur     restlichen 44 Spieler erhalten 14 Eur 

        //Die Spieleranzahl oder Teamanzahl ist List.Count oder List.Length 
    }
}
