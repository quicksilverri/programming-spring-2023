using NUnit.Framework;

namespace PeriodicsLibrary
{
    [TestFixture]
    public class ElectronicPeriodicalEditionTests
    {
        private static ElectronicPeriodicalEdition edition;

        [SetUp]
        public void Setup()
        {
            edition = new ElectronicPeriodicalEdition("Е-комсомольская правда", 2005, EditionType.Newspaper);
            edition.Hyperlink = "link.ru";
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(edition.Name, Is.EqualTo("Е-комсомольская правда"));
            Assert.That(edition.Year, Is.EqualTo(2005));
            Assert.That(edition.Type, Is.EqualTo(EditionType.Newspaper));
        }

        [Test]
        public void GetEditionTypeNameTest()
        {
            Assert.That(edition.GetEditionTypeName(), Is.EqualTo("Газета"));
        }

        [Test]
        public void GetInfoTest()
        {
            string expectedInfo = "Название: Е-комсомольская правда. ";
            expectedInfo += "Год: 2005. ";
            expectedInfo += "Тип: Газета. ";
            expectedInfo += "Гиперссылка: link.ru.";
            Assert.That(edition.GetInfo(), Is.EqualTo(expectedInfo));
        }
    }
}