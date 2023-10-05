namespace Shows4.App.Data.Entities
{
    public class WriterSerie
    {
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}
