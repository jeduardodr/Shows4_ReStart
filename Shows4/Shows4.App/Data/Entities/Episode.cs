namespace Shows4.App.Data.Entities;

public class Episode
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public double RatingGlobal { get; set; }
    public List<Cast> Casts { get; set; }
}
