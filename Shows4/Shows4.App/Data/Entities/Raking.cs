namespace Shows4.App.Data.Entities
{
    public class Raking
    {
        public int Id { get; set; }
        public int Estrelas { get; set; } 
        public string Descricao { get; set; } 
        public int SerieId { get; set; } 
        public Serie Serie { get; set; } 
        public string ClienteId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; } 
    }
}