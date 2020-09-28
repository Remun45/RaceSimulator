using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Controller
{
    public class Race
    {
        public Track Track {get;set;}
        public List<IParticipant> Deelnemers { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random;
        private Dictionary<Section, SectionData> _positions;
        public SectionData GetSectionData(Section section)
        {
            if (!_positions.ContainsKey(section))
            {
                _positions.Add(section, new SectionData());
            }
            return _positions[section];
        }
        public Race(Track track, List<IParticipant> deelnemers)
        {
            this.Track = track;
            this.Deelnemers = deelnemers;
            _random = new Random(DateTime.Now.Millisecond);
            StartTime = new DateTime();
            _positions = new Dictionary<Section, SectionData>();
        }
        public void RandomizeEquipment()
        {
            foreach (IParticipant  deelnemer in Deelnemers)
            {
                deelnemer.Equipment.Performance = _random.Next();
                deelnemer.Equipment.Quality = _random.Next();
            }
        }
        public void setStartPositions()
        {
            int participants = 0;
            foreach (KeyValuePair<Section, SectionData> valuePair in _positions)
            {
                if (valuePair.Equals(SectionTypes.StartGrid))
                {
                    if (Deelnemers[participants] == null)
                    {
                        break;
                    }
                    valuePair.Value.Left = Deelnemers[participants];
                    valuePair.Value.DistanceLeft = 1;
                    // check if there are no more participants
                    if (Deelnemers[participants + 1] == null)
                    {
                        break;
                    }
                    valuePair.Value.Right = Deelnemers[participants];
                    valuePair.Value.DistanceRight = 1;
                }
            }
        }
    }
}
