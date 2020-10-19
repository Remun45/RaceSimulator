using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RaceSimulator
{
    public static class Visualisatie
    {
        // variables
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int Direction { get; set; }
        public static int NewDirection { get; set; }
        public static Race Race { get; set; }

        // initialize method
        public static void Initialize(Race race)
        {
            Race = race;
            Race.DriversChanged += OnDriversChanged;
            Race.StartNextRace += StartNextRace;
            DrawTrack(Race.Track);
        }

        #region graphics
        private static string[] _finishHorizontal = { "----", "  1#", "  2#", "----" };
        private static string[] _finishVertical = { "|12|", "|##|", "|##|", "|  |" };
        private static string[] _startHorizontal = { "----", " 1] ", " 2] ", "----" };
        private static string[] _startVertical = { "|12|", "|_ |", "| _|", "|  |" };
        private static string[] _westToSouth = { "--\\ ", "  2\\", " 1 |", "|  |" };
        private static string[] _northToWest = { "/  |", "  2|", " 1 /", "--/ " };
        private static string[] _eastToNorth = { "|  \\", "|2  ", "\\ 1 ", " \\--" };
        private static string[] _southToEast = { " /--", "/12 ", "|   ", "|  |" };
        private static string[] _horizontalTrack = { "----", " 1  ", "  2 ", "----", };
        private static string[] _verticalTrack = { "|  |", "|12|", "|  |", "|  |" };
        #endregion

        // draw track on console
        public static void DrawTrack(Track track)
        {
            //Console.Clear();
            Y = 0;
            X = 30;
            Direction = 1;
            NewDirection = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Section section in track.Sections)
            {
                string[] graphics = GetGoodGraphics(section.SectionType, Direction);
                foreach (string partOfTrack in graphics)
                {
                    string tekst = "";
                    tekst = ChangeStrings(partOfTrack, Race.GetSectionData(section).Left, Race.GetSectionData(section).Right);
                    Console.SetCursorPosition(X, Y);
                    Console.WriteLine(tekst);
                    Y += 1;
                }
                Direction = NewDirection;
                SetY();
                SetX();
            }
            Console.SetCursorPosition(X, Y+30);
        }

        //  get graphics functions
        public static string[] GetGoodGraphics(SectionTypes section, int direction)
        {
            switch (section)
            {
                case SectionTypes.StartGrid:
                    return GetStartGrid(direction);
                case SectionTypes.LeftCorner:
                    return GetLeftCorner(direction);
                case SectionTypes.RightCorner:
                    return GetRightCorner(direction);
                case SectionTypes.Straight:
                    return GetStraight(direction);
                case SectionTypes.Finish:
                    return GetFinish(direction);
            }
            return null;
        }
        public static string[] GetStartGrid(int direction)
        {
            if (direction == 0 || direction == 2)
            {
                return _startVertical;
            }
            else
            {
                return _startHorizontal;
            }

        }
        public static string[] GetFinish(int direction)
        {
            if (direction == 0 || direction == 2)
            {
                return _finishVertical;
            }
            else
            {
                return _finishHorizontal;
            }
        }
        public static string[] GetStraight(int direction)
        {
            if (direction == 0 || direction == 2)
            {
                return _verticalTrack;
            }
            else
            {
                return _horizontalTrack;
            }
        }
        public static string[] GetLeftCorner(int direction)
        {
            if (direction == 0)
            {
                NewDirection = 3;
                return _westToSouth;
            }
            else if (direction == 1)
            {
                NewDirection = 0;
                return _northToWest;
            }
            else if (direction == 2)
            {
                NewDirection = 1;
                return _eastToNorth;
            }
            else
            {
                NewDirection = 2;
                return _southToEast;
            }
        }
        public static string[] GetRightCorner(int direction)
        {
            if (direction == 0)
            {
                NewDirection = 1;
                return _southToEast;
            }
            else if (direction == 1)
            {
                NewDirection = 2;
                return _westToSouth;
            }
            else if (direction == 2)
            {
                NewDirection = 3;
                return _northToWest;
            }
            else
            {
                NewDirection = 0;
                return _eastToNorth;
            }
        }

        // set X and Y
        public static void SetX()
        {
            if (Direction == 1)
            {
                X += 4;
            }
            else if (Direction == 3)
            {
                X -= 4;
            }
        }
        public static void SetY()
        {
            if (Direction == 1 || Direction == 3)
            {
                Y -= 4;
            }
            else if (Direction == 0)
            {
                Y -= 8;
            }
        }

        // set good characters in strings
        public static string ChangeStrings(String tekst, IParticipant een, IParticipant twee)
        {
            char first = 'X';

            if (tekst.Contains('1') && een != null)
            {
                if (!een.Equipment.isBroken)
                {
                    first = een.GetFirstLetter();
                }
                tekst = tekst.Replace('1', first);
            } else
            {
                tekst = tekst.Replace('1', ' ');

            }

            char second = 'X';
            if (tekst.Contains('2') && twee != null)
            {
                if (!twee.Equipment.isBroken)
                {
                    second = twee.GetFirstLetter();
                }
                tekst = tekst.Replace('2', second);
            } else
            {
                tekst = tekst.Replace('2', ' ');
            }
            return tekst;
        }

        // events, when drivers change and when next race gets started
        public static void OnDriversChanged(object sender, DriversChangedEventArgs args)
        {
            DrawTrack(args.Track);
        }
        public static void StartNextRace(object sender, EventArgs args)
        {
            Console.Clear();
            Race.DriversChanged -= OnDriversChanged;
            Race.StartNextRace -= StartNextRace;
            Race.RaceFinished -= Data.Competition.OnRaceFinished;
            Data.NextRace();
            if (Data.CurrentRace != null)
            {
                Initialize(Data.CurrentRace);
            }
            else
            {
                Console.SetCursorPosition(5,5);
                Console.WriteLine("Alle races zijn afgelopen");
            }
        }
    }
}
