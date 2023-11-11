namespace Domain
{
    public class Meetup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Place { get; set; } = null!;
    }
}
