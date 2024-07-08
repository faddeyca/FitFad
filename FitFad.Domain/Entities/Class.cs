namespace FitFad.Domain.Entities
{
    public class Class : AbstractEntity<Class>
    {
        public string? Name { get; private set; }
        public List<Trainer> Trainer { get; private set; } = [];
        public List<Client> Clients { get; private set; } = [];
        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
    }
}
