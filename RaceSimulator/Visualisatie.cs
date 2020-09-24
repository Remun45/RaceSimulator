using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceSimulator
{
    static class Visualisatie
    {
        public static void Initialize() { }

        #region graphics
        private static string[] _finishHorizontal = { "----", "  # ", "  # ", "----" };
        private static string[] _startHorizontal = { "----", " ]  ", "  ] ", "----" };
        private static string[] _westToSouth = { "--\\ ", "   \\", "\\  |", "|  |" };
        private static string[] _northToWest = { "|  |", "/  |", "   /", "--/ " };
        private static string[] _eastToNorth = { "|  |", "|  \\", "\\   ", " \\--" };
        private static string[] _westToEast = { " /--", "/   ", "|  /", "|  |" };
        private static string[] _horizontalTrack = {"----", "    ", "    ", "----",};
        private static string[] _verticalTrack = { "|  |", "|  |", "|  |", "|  |" };
        #endregion

        public static void DrawTrack(Track track)
        {
            
        }
    }
}
