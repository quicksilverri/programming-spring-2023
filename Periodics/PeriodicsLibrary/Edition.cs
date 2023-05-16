namespace PeriodicsLibrary

{
    public abstract class Edition
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public EditionType Type { get; set; }
        public abstract string GetInfo();
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
    }
}