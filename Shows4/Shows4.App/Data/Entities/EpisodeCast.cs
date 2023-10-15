namespace Shows4.App.Data.Entities
{
    public class EpisodeCast
    {
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public int CastId { get; set; }
        public Cast Cast { get; set; }
    }
}
