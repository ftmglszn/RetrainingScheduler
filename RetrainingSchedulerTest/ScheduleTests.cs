using NUnit.Framework;
using RetrainingScheduler;

[TestFixture]
public class ScheduleTests
{
    private Schedule _schedule;
    private List<Session> _sessions;

    [SetUp]
    public void Setup()
    {
        _schedule = new Schedule();

        _sessions = new List<Session>
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
            new Session("Piped Water", "30min")
        };
    }

    [Test]
    public void CreateSchedule_AssignsAllSessions()
    {
        _schedule.CreateSchedule(_sessions);
        // All sessions should be assigned to some track.
        Assert.That(_sessions.All(s => _schedule.ContainsSession(s)));
    }

    [Test]
    public void CreateSchedule_DoesNotExceedTrackLimits()
    {
        _schedule.CreateSchedule(_sessions);
        // No track should have more than 180 minutes in the morning or more than 240 minutes in the afternoon.
        Assert.That(_schedule.AllTracksRespectTimeLimits());
    }

    [Test]
    public void Session_DurationParsing_WorksCorrectly()
    {
        var session1 = new Session("Test", "60min");
        var session2 = new Session("Test", "lightning");

        Assert.That(session1.Duration, Is.EqualTo(60));
        Assert.That(session2.Duration, Is.EqualTo(5));
    }
}