using System;

namespace PeriodicsLibrary
{
    public class PeriodicalEdition
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Issue { get; set; }
        public string Publisher { get; set; }
        public EditionType Type { get; set; }
        public readonly int ISSN;
        public int Price = -1;

        public PeriodicalEdition(string name, int year, int issue)
        {
            Name = name;
            Year = year;
            Issue = issue;
        }

        public string GetEditionTypeName()
        {
            switch (Type)
            {
                case EditionType.Almanac:
                    return "Альманах";
                case EditionType.Catalogue:
                    return "Каталог";
                case EditionType.Magazine:
                    return "Журнал";
                case EditionType.Newspaper:
                    return "Газета";
                case EditionType.Other:
                    return "Другое";
            }
            return "Нет типа";
        }

        public string GetInfo()
        {
            var result = "";
            result += $"Название: {Name}. Год: {Year}. Выпуск: {Issue}.";
            if (Publisher != default)
                result += $" Издатель: {Publisher}.";
            
            var typeName = GetEditionTypeName();
            if (typeName != "Нет типа")
                result += $" Тип: {typeName}.";
            if (ISSN != 0)
                result += $" ISSN: {ISSN}.";
            if (Price != -1)
                result += $" Издатель: {Publisher}.";
            return result;
        }
    }
}