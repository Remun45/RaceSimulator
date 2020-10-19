using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RaceFinishedArgs : EventArgs
    {
        public Stack<IParticipant> Eindstand { get; set; }
        public Track Track { get; set; }
    }
}
