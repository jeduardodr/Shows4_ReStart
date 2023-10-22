namespace Shows4.App.Data.Entities;

public class Cast
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
    public virtual Country Country {  get; set; }
    public List<Episode> Episodes { get; set; } // lista de episódios em que o ator participa
    public List<EpisodeCast> EpisodeCasts { get; set; }
    [NotMapped] // Para evitar que o canDelete seja mapeado para a base de dados
    public bool CanDelete { get; set; } // Para poder probir de elimnar um dado que contenha FK
}
