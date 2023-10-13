namespace Shows4.App.Models
{
    public class SeasonsModel : PageModel
    {
        //public int SeasonId { get; set; }
        //public int SeasonNumber { get; set; }
        //public string SesonsDescription { get; set; }
        public int SerieId {  get; set; }
        public string SerieTitle {  get; set; }
        public string SerieDescription { get; set; }
        public int SeasonNumber { get; set; }
        public string SeasonDescription { get; set; }
        public Serie Serie { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
