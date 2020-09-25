using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Track
    {
        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }

        public Track(string name, SectionTypes[] sectionTypes)
        {
            Name = name;
            Sections = ConvertArrayToLinkedList(sectionTypes);
        }
        public Track(string name)
        {
            this.Name = name;
        }
        public LinkedList<Section> ConvertArrayToLinkedList(SectionTypes[] sectionTypes)
        {
            LinkedList<Section> sections = new LinkedList<Section>();
            foreach (SectionTypes sectionType in sectionTypes)
            {
                Section section = new Section(sectionType);
                sections.AddLast(section);
            }
            return sections;
        }
    }
}
