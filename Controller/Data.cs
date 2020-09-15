using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    static class Data
    {
       static Competition competition { get; set; }
       public static void initialize()
       {
            competition = new Competition();
       }
       static void addParticipants()
       {
            competition.addParticipant()
       }
    }
}
