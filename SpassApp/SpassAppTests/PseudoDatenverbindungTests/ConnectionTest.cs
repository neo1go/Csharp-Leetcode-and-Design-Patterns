using Xunit;


namespace SpassApp.SpassAppTests.PseudoDatenverbindungTests
{


    public class ConnectionTest
    {


        [Fact]
        public void ErstellungDatenverbindung_ConnectionTrue_ReturnsSuccessMessage()
        {
            // Arrange
            Program pseudoConnection1 = new Program();

            // Act
            string result = pseudoConnection1.ErstellungDatenverbindung(true);

            // Assert
            Assert.Equal("Datenverbindung erstellt", result);
        }

        [Fact]
        public void ErstellungDatenverbindung_ConnectionFalse_ReturnsFailureMessage()
        {
            // Arrange
            Program pseudoConnection2 = new Program();

            // Act
            string result2 = pseudoConnection2.ErstellungDatenverbindung(false);

            // Assert
            Assert.Equal("Connection failed", result2);
        }


        [Fact]
        public void ZaehlerTest_zaehlerinRange0to10()
        {
            //Arrange


            //Act
            int result3 = Zaehler.loopCounter();
            
            //Assert
            Assert.InRange(result3, 0, 9);
        }

    }
}
