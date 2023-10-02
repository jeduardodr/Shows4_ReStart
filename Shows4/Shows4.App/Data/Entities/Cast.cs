namespace Shows4.App.Data.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
