using Shows4.App.Data.Entities;
namespace Shows4.App.Models;
public class SerieModel
{
    public int SerieId { get; set; }
    public string SerieTitle { get; set; }
    public string SerieDescription { get; set; }
    public double SeriePrice { get; set; }
    public string SerieImage { get; set; }
    public string SerieYearRelease { get; set; }
    public List<Season> SerieSeasons { get; set; }
    public List<Raking> SerieRakings { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public bool SerieCanDelete { get; set; }
}