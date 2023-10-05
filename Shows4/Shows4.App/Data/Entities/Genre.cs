using System.ComponentModel.DataAnnotations;

namespace Shows4.App.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(15)]
        public string Name { get; set; }
      
       
    }
}
