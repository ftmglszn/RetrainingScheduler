namespace RetrainingScheduler;
public class Track
{
    private const int MorningSessionLimit = 180;
    private const int AfternoonSessionLimit = 240;
    private int _morningSessionUsed = 0;
    private int _afternoonSessionUsed = 0;
    public List<Session> _morningSessions;
    public List<Session> _afternoonSessions;

    public Track()
    {
        _morningSessions = new List<Session>();
        _afternoonSessions = new List<Session>();
    }

    public bool AddSessionTrack(Session session)
    {
        if (_morningSessionUsed + session.Duration <= MorningSessionLimit)
        {
            _morningSessions.Add(session);
            _morningSessionUsed += session.Duration;
            return true;
        }
        else if (_afternoonSessionUsed + session.Duration <= AfternoonSessionLimit)
        {
            _afternoonSessions.Add(session);
            _afternoonSessionUsed += session.Duration;
            return true;
        }

        return false;
    }

    public void PrintTrackSchedule()
    {
        DateTime currentTime = new DateTime(2023, 5, 18, 9, 0, 0);    

        foreach (var session in _morningSessions)
        {
            Console.WriteLine($"{currentTime.ToString("hh:mm tt")} | {session.Name} | {session.Duration}min");
            currentTime = currentTime.AddMinutes(session.Duration);
        }

        Console.WriteLine("12:00 PM | Lunch");
        currentTime = new DateTime(2023, 5, 18, 13, 0, 0);

        foreach (var session in _afternoonSessions)
        {
            Console.WriteLine($"{currentTime.ToString("hh:mm tt")} | {session.Name} | {session.Duration}min");
            currentTime = currentTime.AddMinutes(session.Duration);
        }
        Console.WriteLine($"{currentTime.ToString("hh:mm tt")} | {"Sharing Session"}");
    }

    public bool ContainsSessionTrack(Session session)
    {
        return _morningSessions.Contains(session) || _afternoonSessions.Contains(session);
    }

    public bool RespectsTimeLimits()
    {
        return _morningSessionUsed <= MorningSessionLimit && _afternoonSessionUsed <= AfternoonSessionLimit;
    }
}
