namespace Shows4.App.Data.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public double RatingGlobal { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
       
        public List<Episode> Episodes { get; set; }
    }
}
