namespace Shows4.App.Data.Entities;

public class RentDetail
{
    public int Id { get; set; }
    public DateTime RentDate { get; set; }
    public double PrecoPago { get; set; }
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int SerieId { get; set; }
    public Serie Serie { get; set; }
}
