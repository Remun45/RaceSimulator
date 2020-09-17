using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Track
    {
        string Name { get; set; }
        LinkedList<Section> Sections { get; set; }

        Track(string name, LinkedList<Section> sections)
        {
            Name = name;
            Sections = sections;
        }
        public Track()
        {

        }
    }
}
