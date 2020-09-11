using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Competition
    {
        public List<IParticipant> Participants { get; set; }
        public Queue<Track> Tracks { get; set; }
        public Competition()
        {

        }
        public void addParticipant(IParticipant participant)
        {
            Participants.Add(participant);
        }
    }

}
