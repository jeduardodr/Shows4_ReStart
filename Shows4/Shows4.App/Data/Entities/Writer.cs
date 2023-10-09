using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4.App.Data.Entities
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public static implicit operator Writer(List<Writer> v)
        {
            throw new NotImplementedException();
        }

        //Talvez criar um genero em DataBase masculino, femenino, etc
    }
}
