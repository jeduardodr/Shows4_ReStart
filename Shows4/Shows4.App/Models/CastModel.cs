namespace Shows4.App.Models;
public class CastModel
{
    public int CastId { get; set; }
    public string CastName { get; set; }
    public DateTime Birth { get; set; }
    public string CastGender { get; set; }
    public string CountryName { get; set; }
    public List<Episode> CastEpisodes { get; set; }
}
