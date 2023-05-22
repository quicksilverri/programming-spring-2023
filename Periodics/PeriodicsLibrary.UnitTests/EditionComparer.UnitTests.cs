using NUnit.Framework;

namespace PeriodicsLibrary
{
    [TestFixture]
    public class EditionComparerTests
    {
        private static PeriodicalEdition edition_x; 
        private static ElectronicPeriodicalEdition edition_y; 
        private static PeriodicalEdition edition_z; 
        private static EditionComparer comparer; 
        private static Edition[] editions; 
        private static Catalogue catalogue; 

        [SetUp]
        public void Setup()
        {
            edition_x = new PeriodicalEdition("ABCD", 2020, 1); 
            edition_y = new ElectronicPeriodicalEdition("ABCD", 2019, EditionType.Almanac);
            edition_z = new PeriodicalEdition("A", 2019, 2); 
            edition_x.Type = EditionType.Magazine; 
            comparer = new EditionComparer(); 
            editions = new Edition[] { edition_x, edition_y, edition_z }; 
            catalogue = new Catalogue(editions); 
        }

        [Test]
        public void CompareToTest()
        {
            Assert.That(edition_x.CompareTo(edition_y), Is.LessThan(0)); 
            Assert.That(edition_x.CompareTo(edition_z), Is.GreaterThan(0));
            Assert.That(edition_y.CompareTo(edition_z), Is.GreaterThan(0));
        }

        [Test]
        public void ComparerTest()
        {
            Assert.That(comparer.Compare(edition_x, edition_y), Is.GreaterThan(0)); 
            Assert.That(comparer.Compare(edition_x, edition_z), Is.GreaterThan(0));
        }

        [Test]
        public void CatalogueCountTest()
        {
            Assert.That(catalogue.Count, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerableTest()
        {
            var i = 0; 
            foreach(var item in catalogue) Assert.That(item, Is.SameAs(editions[i++]));
        }
    }
}