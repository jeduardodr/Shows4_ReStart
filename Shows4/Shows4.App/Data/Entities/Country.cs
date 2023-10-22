namespace Shows4.App.Data.Entities;

public class Country
{
    public int Id { get; set; }

    [MaxLength(5)]
    public string Alpha2Code { get; set; }
    [MaxLength(30)]

    public string Name { get; set; }
    [NotMapped] // Para evitar que o canDelete seja mapeado para a base de dados
    public bool CanDelete { get; set; } // Para poder probir de elimnar um dado que contenha FK

}
