using NUnit.Framework; 

namespace PeriodicsLibrary.UnitTests
{
    [TestFixture]
    public class PeriodicEditionTests
    {
        private static PeriodicalEdition periodicalEdition;
        
        [SetUp]
        public void Setup()
        {
            periodicalEdition = new PeriodicalEdition("Комсомольская правда", 2005, 1);
            periodicalEdition.Type = EditionType.Newspaper;
        }
        [Test]
        public void ConstructorTest()
        {
            Assert.That(periodicalEdition.Name, Is.EqualTo("Комсомольская правда"));
            Assert.That(periodicalEdition.Year, Is.EqualTo(2005));
            Assert.That(periodicalEdition.Issue, Is.EqualTo(1));
        }

        [Test]
        public void GetEditionTypeNameTest()
        {
            Assert.That(periodicalEdition.GetEditionTypeName(), Is.EqualTo("Газета"));
        }
        
        [Test]
        public void GetInfoTest()
        {
            string expectedInfo = "Название: Комсомольская правда. ";
            expectedInfo += "Год: 2005. ";
            expectedInfo += "Выпуск: 1. ";
            expectedInfo += "Тип: Газета.";
            Assert.That(periodicalEdition.GetInfo(), Is.EqualTo(expectedInfo));
        }
    }
}