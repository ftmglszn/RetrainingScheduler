namespace RetrainingScheduler
{
    public class Session
    {
        public string Name { get; set; }
        public int Duration { get; set; }

        private const string Lightning = "lightning";

        public Session(string name, string duration)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Session name cannot be null or empty.");
            Name = name;
            if (duration.Equals(Lightning))
                Duration = 5;

            else if (duration.EndsWith("min") && int.TryParse(duration.Replace("min", ""), out int minutes))
                Duration = minutes;
            else
                throw new ArgumentException("Invalid session duration format.");
        }

    }
}