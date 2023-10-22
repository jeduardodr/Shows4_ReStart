using Shows4.App.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4.App.Data.Entities
{
    public class Writer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [AdultValidation(ErrorMessage = "Age must be greater than 18 years.")]

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        [NotMapped] // Para evitar que o canDelete seja mapeado para a base de dados
    public bool CanDelete { get; set; } // Para poder probir de elimnar um dado que contenha FK

    }
}
