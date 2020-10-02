using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Timers;

namespace Controller
{
    public delegate void OnDriversChanged(object sender, DriversChangedEventArgs args);
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Deelnemers { get; set; }
        public DateTime StartTime { get; set; }
        public event OnDriversChanged DriversChanged;
        private Random _random;
        private Dictionary<Section, SectionData> _positions;
        private Timer _timer;
        public Race(Track track, List<IParticipant> deelnemers)
        {
            this.Track = track;
            this.Deelnemers = deelnemers;

            _random = new Random(DateTime.Now.Millisecond);
            StartTime = new DateTime();
            _positions = new Dictionary<Section, SectionData>();

            RandomizeEquipment();
            SetAllSections();
            SetStartPositions();

            _timer = new Timer(500);
            _timer.Elapsed += OnTimedEvent;
        }
        public void OnTimedEvent(object sender, ElapsedEventArgs args)
        {
            foreach (KeyValuePair<Section, SectionData> valuePair in _positions)
            {
                if (valuePair.Value.Left != null)
                {

                }
            }
        }
        public void Start()
        {
            _timer.Start();
        }
        public SectionData GetSectionData(Section section)
        {
            if (!_positions.ContainsKey(section))
            {
                _positions.Add(section, new SectionData());
            }
            return _positions[section];
        }
        public void RandomizeEquipment()
        {
            foreach (IParticipant  deelnemer in Deelnemers)
            {
                deelnemer.Equipment.Performance = _random.Next();
                deelnemer.Equipment.Quality = _random.Next();
            }
        }
        public void SetStartPositions()
        {
            int participants = 0;
            int max = Deelnemers.Count;
            foreach (KeyValuePair<Section, SectionData> keyValue in _positions)
            {
                if (keyValue.Key.SectionType == SectionTypes.StartGrid)
                {
                    if (participants+1 < max)
                    {
                        keyValue.Value.Left = Deelnemers[participants];
                        keyValue.Value.Right = Deelnemers[participants + 1];
                        participants += 2;
                    } else if (participants < max)
                    {
                        keyValue.Value.Left = Deelnemers[participants];
                        participants += 1;
                    }
                }
            }
        }
        public void SetAllSections()
        {
            foreach (Section section in Track.Sections)
            {
                _positions.Add(section, new SectionData());
            }
        }
        public void SetDeelnemerNextSection()
        {

        }
    }
}
