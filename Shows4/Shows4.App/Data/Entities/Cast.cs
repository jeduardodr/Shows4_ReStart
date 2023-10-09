using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4.App.Data.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country {  get; set; }
    }
}
