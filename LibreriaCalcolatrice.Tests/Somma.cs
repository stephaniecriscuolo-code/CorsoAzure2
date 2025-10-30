using ClassLibrary1;
using Moq;

namespace LibreriaCalcolatrice.Tests
{
    public class Somma
    {
         
        [Fact]
        public void SommaduenumerirestituiscesommaAritmetica()
        {
            ICLock cLock = new MockWednesdayClock();
            var calcolatrice = new Calcolatrice(cLock);
            //Arrange
            int a = 2;
            int b = 3;
            var atteso = 5;
            var calcolato = calcolatrice.Somma(a, b);
            //Act
            //Assert
            Assert.Equal(atteso,calcolato);
        }
        [Fact]
        public void SommazerorestituisceNumerodiPArtenza()
        {
            ICLock cLock = new MockWednesdayClock();
            var calcolatrice = new Calcolatrice(cLock);
            //Arrange
            int a = 2;
            int b = 0;
            var atteso = 2;
            var calcolato = calcolatrice.Somma(a, b);
            //Act
            //Assert
            Assert.Equal(atteso, calcolato);
        }
        [Fact]
        public void SommaNegativaRestituisceZero()
        {
            ICLock cLock = new MockWednesdayClock();
            var calcolatrice = new Calcolatrice(cLock);
            //Arrange
            int a = 2;
            int b = -2;
            var atteso = 0;
            var calcolato = calcolatrice.Somma(a, b);
            //Act
            //Assert
            Assert.Equal(atteso, calcolato);
        }
        [Fact]
        public void SommaPazza()
        {
            ICLock cLock = new MockWednesdayClock();
            var calcolatrice = new Calcolatrice(cLock);
            //Arrange
            int a = 1;
            int b = 6;
            var atteso = 7;
            var calcolato = calcolatrice.Somma(a, b);
            //Act
            //Assert
            Assert.Equal(atteso, calcolato);
        }
        [Fact]
        public void SommaPazzaTestMartedì()
        {
            //es con MOq
            var mock = new Mock<ICLock>();
            mock.Setup(clock => clock.Now()).Returns(new DateTime(2025,10,28));
            ICLock cLock = new MockTuesdayClock();
            var calcolatrice = new Calcolatrice(cLock);
            //Arrange
            int a = 1;
            int b = 6;
            var atteso = 37;
            var calcolato = calcolatrice.Somma(a, b);
            //Act
            //Assert
            Assert.Equal(atteso, calcolato);
        }
        [Fact]
        public void SommaNormaleTestMarcoledì()
        {
            //es con MOq
            var mock = new Mock<ICLock>();
            mock.Setup(clock => clock.Now()).Returns(new DateTime(2025, 10, 29));
            ICLock cLock = new MockWednesdayClock();
            var calcolatrice = new Calcolatrice(cLock);
            //Arrange
            int a = 1;
            int b = 6;
            var atteso = 7;
            var calcolato = calcolatrice.Somma(a, b);
            //Act
            //Assert
            Assert.Equal(atteso, calcolato);
        }
    }
}