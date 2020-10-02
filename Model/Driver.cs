using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }

        public Driver(String name, int points, IEquipment equipment, TeamColors teamColors)
        {
            this.Name = name;
            this.Points = points;
            this.Equipment = equipment;
            this.TeamColor = teamColors;
        }
        public Driver() { }
        public char GetFirstLetter()
        {
            return Name[0];
        }
    }
}
