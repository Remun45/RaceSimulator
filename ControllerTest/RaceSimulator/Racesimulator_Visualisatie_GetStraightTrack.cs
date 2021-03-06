﻿using NUnit.Framework;
using RaceSimulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerTest.RaceSimulator
{
    [TestFixture]
    class RaceSimulator_Visualisatie_GetStraightTrack
    {
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
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void GetStraightTrackShould_ReturnHorizontal()
        {
            //setup
            int direction = 1;
            int direction2 = 3;

            //actions
            var result = Visualisatie.GetStraight(direction);
            var result2 = Visualisatie.GetStraight(direction2);

            //assertions
            Assert.AreEqual(result, _horizontalTrack);
            Assert.AreEqual(result, _horizontalTrack);
        }
        [Test]
        public void GetStraightTrackShould_ReturnVertical()
        {
            //setup
            int direction = 0;
            int direction2 = 2;

            //actions
            var result = Visualisatie.GetStraight(direction);
            var result2 = Visualisatie.GetStraight(direction2);

            //assertions
            Assert.AreEqual(result, _verticalTrack);
            Assert.AreEqual(result, _verticalTrack);
        }
    }
}
