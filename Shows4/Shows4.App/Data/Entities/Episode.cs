using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shows4.App.Data.Entities;

public class Episode
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    [BindNever]
    public int SeasonId { get; set; } // chave estrangeira da temporada
    //public Season Season { get; set; } // referência à temporada
    
}
