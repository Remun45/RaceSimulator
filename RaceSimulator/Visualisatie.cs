using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceSimulator
{
    public static class Visualisatie
    {
        public static int x { get; set; }
        public static int y { get; set; }
        public static int direction { get; set; }
        public static int newDirection { get; set; }
        public static Race Race { get; set; }
        public static void Initialize() { }

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

        public static void DrawTrack(Track track)
        {
            y = 10;
            x = 30;
            direction = 1;
            newDirection = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Section section in track.Sections)
            {
                string[] graphics = GetGoodGraphics(section.SectionType, direction);
                foreach (string partOfTrack in graphics)
                {
                    string tekst = "";
                    tekst = ChangeStrings(partOfTrack, Race.GetSectionData(section).Left, Race.GetSectionData(section).Right);
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(tekst);
                    y += 1;
                }
                section.X = x;
                section.Y = y;
                direction = newDirection;
                SetY();
                SetX();
            }
        }
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
                newDirection = 3;
                return _westToSouth;
            }
            else if (direction == 1)
            {
                newDirection = 0;
                return _northToWest;
            }
            else if (direction == 2)
            {
                newDirection = 1;
                return _eastToNorth;
            }
            else
            {
                newDirection = 2;
                return _southToEast;
            }
        }
        public static string[] GetRightCorner(int direction)
        {
            if (direction == 0)
            {
                newDirection = 1;
                return _southToEast;
            }
            else if (direction == 1)
            {
                newDirection = 2;
                return _westToSouth;
            }
            else if (direction == 2)
            {
                newDirection = 3;
                return _northToWest;
            }
            else
            {
                newDirection = 0;
                return _eastToNorth;
            }
        }
        public static void SetX()
        {
            if (direction == 1)
            {
                x += 4;
            }
            else if (direction == 3)
            {
                x -= 4;
            }
        }
        public static void SetY()
        {
            if (direction == 1 || direction == 3)
            {
                y -= 4;
            }
            else if (direction == 0)
            {
                y -= 8;
            }
        }
        public static string ChangeStrings(String tekst, IParticipant een, IParticipant twee)
        {
            if (tekst.Contains('1') && een != null)
            {
                tekst = tekst.Replace('1', een.GetFirstLetter());
            } else
            {
                tekst = tekst.Replace('1', ' ');

            }
            if (tekst.Contains('2') && twee != null)
            {
                tekst = tekst.Replace('2', twee.GetFirstLetter());
            } else
            {
                tekst = tekst.Replace('2', ' ');
            }
            return tekst;
        }
        public static void OnDriversChanged(object sender, DriversChangedEventArgs args)
        {
            DrawTrack(args.Track);
        }
    }
}
