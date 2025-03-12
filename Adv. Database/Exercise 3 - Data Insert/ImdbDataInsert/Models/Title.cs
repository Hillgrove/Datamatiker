namespace ImdbDataInsert.Models
{
    public class Title
    {
        public required string Tconst { get; set; }
        public int TitleTypeID { get; set; }
        public required string PrimaryTitle { get; set; }
        public required string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public short? StartYear { get; set; }
        public short? EndYear { get; set; }
        public int? RuntimeMinutes { get; set; }

        public override string ToString()
        {
            return $"Tconst: {Tconst}, TitleTypeID: {TitleTypeID}, PrimaryTitle: {PrimaryTitle}, OriginalTitle: {OriginalTitle}, IsAdult: {IsAdult}, StartYear: {StartYear}, EndYear: {EndYear}, RuntimeMinutes: {RuntimeMinutes}";
        }
    }
}
