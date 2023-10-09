using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4.App.Data.Entities
{
    public class WriterSerie
    {
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        [ForeignKey("Serie")]
        public int SerieId { get; set; }
        public virtual Serie Serie { get; set; }
    }
}
