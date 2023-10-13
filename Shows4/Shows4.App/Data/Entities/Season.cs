using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    }
}
