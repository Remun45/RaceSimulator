using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Track
    {
        string Name { get; set; }
        LinkedList<Section> Sections { get; set; }

        public Track(string name, LinkedList<Section> sections)
        {
            Name = name;
            Sections = sections;
        }
    }
}
