using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4.App.Data.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        [BindNever]
        public int SerieId { get; set; } // chave estrangeira da série
        //public Serie Serie { get; set; } // referência à série
        public List<Episode> Episodes { get; set; }
        [NotMapped] // Para evitar que o canDelete seja mapeado para a base de dados
        public bool CanDelete { get; set; } // Para poder probir de elimnar um dado que contenha FK

    }
}
