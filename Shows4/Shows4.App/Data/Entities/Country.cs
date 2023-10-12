using System.ComponentModel.DataAnnotations;

namespace Shows4.App.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(5)]
        public string Alpha2Code { get; set; }
        [MaxLength(30)]

        public string Name { get; set; }
      
    }
}
