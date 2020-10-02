﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
       static Competition Competition { get; set; }
       public static Race CurrentRace { get; set; }
       public static void Initialize()
       {
            Competition = new Competition();
            AddTrack();
            AddDriver();
            NextRace();
       }
        public static void AddDriver()
        {
            Driver driver1 = new Driver("Max Verstappen", 0, new SnowMobile(), TeamColors.Green);
            Driver driver2 = new Driver("Captain Pete Cooper", 0, new SnowMobile(), TeamColors.Red);
            Driver driver3 = new Driver("Lionel Messie", 0, new SnowMobile(), TeamColors.Blue);
            Driver driver4 = new Driver("Raymond van Barneveld", 0, new SnowMobile(), TeamColors.Yellow);
            Driver driver5 = new Driver("Ikke", 0, new SnowMobile(), TeamColors.Grey);
            Driver driver6 = new Driver("Flikke", 0, new SnowMobile(), TeamColors.Pink);

            Competition.Participants.Add(driver1);
            Competition.Participants.Add(driver2);
            Competition.Participants.Add(driver3);
            Competition.Participants.Add(driver4);
            Competition.Participants.Add(driver5);
            Competition.Participants.Add(driver6);

        }
        public static void AddTrack()
        {
            Track elburg = new Track("Circuit Elburg", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner});
            Competition.Tracks.Enqueue(elburg);
            Track peter = new Track("Peter", new SectionTypes[] {
            SectionTypes.StartGrid,
            SectionTypes.StartGrid,
            SectionTypes.Finish,
            SectionTypes.RightCorner,
            SectionTypes.Straight,
            SectionTypes.RightCorner,
            SectionTypes.Straight,
            SectionTypes.Straight,
            SectionTypes.Straight,
            SectionTypes.RightCorner,
            SectionTypes.Straight,
            SectionTypes.RightCorner,
            });
            Competition.Tracks.Enqueue(peter);
            //CurrentRace = new Race(Competition.Tracks.Peek(), Competition.Participants);
        }
        public static void NextRace()
        {
            Track nextTrackInLine = Competition.NextTrack();
            if (nextTrackInLine != null)
            {
                CurrentRace = new Race(nextTrackInLine, Competition.Participants);
            }
        }
    }
}
