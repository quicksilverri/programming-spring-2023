namespace PeriodicsLibrary
{
    public class ElectronicPeriodicalEdition : Edition
    {
        public string Hyperlink { get; set; }
        public ElectronicPeriodicalEdition(string name, int year, EditionType type)
        {
            Name = name;
            Year = year;
            Type = type;
        }

        public override string GetInfo()
        {
            var result = $"Название: {Name}. Год: {Year}. Тип: {GetEditionTypeName()}.";
            if (Hyperlink != default)
                result += $" Гиперссылка: {Hyperlink}.";
            return result;
        }
    }
}