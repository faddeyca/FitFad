using FitFad.Domain.Entities.Person;

namespace FitFad.Domain.Entities
{
    public class Class : AbstractEntity<Class>
    {
        public string? Name { get; private set; }
        public List<Trainer> Trainers { get; private set; } = [];
        public List<Client> Clients { get; private set; } = [];

        private DateTime _startTime;
        private DateTime _endTime;

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (value >= EndTime)
                {
                    throw new ArgumentException("Start time must be before end time.");
                }
                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get => _endTime;
            set
            {
                if (value <= StartTime)
                {
                    throw new ArgumentException("Start time must be before end time.");
                }
                _endTime = value;
            }
        }

        public TimeSpan Duration => EndTime - StartTime;

        public Class() { }

        public Class(string? name, DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
            {
                throw new ArgumentException("Start time must be before end time.");
            }
            Name = name;
            _startTime = startTime;
            _endTime = endTime;
        }

        public void RegisterTrainer(Trainer trainer)
        {
            Trainers.Add(trainer);
            trainer.RegisterToClass(this);
        }

        public bool RemoveTrainer(Trainer trainer)
        {
            return Trainers.Remove(trainer) & trainer.RemoveFromClass(this);
        }

        public void RegisterClient(Client client)
        {
            client.RegisterToClass(this);
            Clients.Add(client);
        }

        public bool RemoveClient(Client client)
        {
            return Clients.Remove(client) & client.RemoveFromClass(this);
        }
    }
}
