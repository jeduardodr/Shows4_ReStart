using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4.App.Data.Entities;
public class Serie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public string YearRelease  { get; set; }
    public List<Season> Seasons { get; set; } // lista de temporadas da série
    public List<Raking> Rakings { get; set; } // lista de avaliações da série
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    [NotMapped] // Para evitar que o canDelete seja mapeado para a base de dados
    public bool CanDelete { get; set; } // Para poder probir de elimnar um dado que contenha FK

}
