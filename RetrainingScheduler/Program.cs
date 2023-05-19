namespace RetrainingScheduler
{
    public class Program
    {
        static void Main()
        {
            var inputSessions = new List<Session>

            {
            new Session("Organising Parents for Academy Improvements", "60min"),
            new Session("Teaching Innovations in the Pipeline", "45min"),
            new Session("Teacher Computer Hacks", "30min"),
            new Session("Making Your Academy Beautiful", "45min"),
            new Session("Academy Tech Field Repair", "45min"),
            new Session("Sync Hard", "lightning"),
            new Session("Unusual Recruiting", "lightning"),
            new Session("Parent Teacher Conferences", "60min"),
            new Session("Managing Your Dire Allowance", "45min"),
            new Session("Customer Care", "30min"),
            new Session("AIMs – 'Managing Up'", "30min"),
            new Session("Dealing with Problem Teachers", "45min"),
            new Session("Hiring the Right Cook", "60min"),
            new Session("Government Policy Changes and New Globe", "60min"),
            new Session("Adjusting to Relocation", "45min"),
            new Session("Public Works in Your Community", "30min"),
            new Session("Talking To Parents About Billing", "30min"),
            new Session("So They Say You're a Devil Worshipper", "60min"),
            new Session("Two-Streams or Not Two-Streams", "30min"),
            new Session("Piped Water", "30min"),
        };

            var schedule = new Schedule();
            schedule.CreateSchedule(inputSessions);
            schedule.PrintSchedule();

        }
    }
}