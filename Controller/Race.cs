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
        public List<IParticipant> deelnemers { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random;
        private Dictionary<Section, SectionData> _positions;
        public SectionData GetSectionData(Section section)
        {
            return _positions[section];
        }
    }
}
