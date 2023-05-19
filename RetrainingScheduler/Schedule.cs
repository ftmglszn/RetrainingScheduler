

namespace RetrainingScheduler
{
    public class Schedule
    {
        private readonly List<Track> _tracks;
        public Schedule()
        {
            _tracks = new List<Track> {};
        }

        public void CreateSchedule(List<Session> sessions)
        {
            if (sessions == null || sessions.Count == 0)
                throw new ArgumentException("Sessions list must not be null or empty.");
            sessions = sessions.OrderByDescending(s => s.Duration).ToList();

            foreach (var session in sessions)
            {
                bool isSessionScheduled = false;

                foreach (var track in _tracks)
                {
                    if (track.AddSessionTrack(session))
                    {
                        isSessionScheduled = true;
                        break;
                    }
                }

                if (!isSessionScheduled)
                {
                    var newTrack = new Track();
                    newTrack.AddSessionTrack(session);
                    _tracks.Add(newTrack);
                }
            }
        }


        public void PrintSchedule()
        {
            for (int i = 0; i < _tracks.Count; i++)
            {
                Console.WriteLine($"Track {i + 1}");
                Console.WriteLine("Time | Session Name | Duration");
                Console.WriteLine("---------|---------------------------------------------|----------");
                _tracks[i].PrintTrackSchedule();
                Console.WriteLine();
            }
        }

        public bool ContainsSession(Session session)
        {
            return _tracks.Any(t => t.ContainsSessionTrack(session));
        }

        public bool AllTracksRespectTimeLimits()
        {
            return _tracks.All(t => t.RespectsTimeLimits());
        }
    }
}
