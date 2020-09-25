using NUnit.Framework;
using RaceSimulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerTest.RaceSimulator
{
    [TestFixture]
    class RaceSimulator_Visualisatie_GetStartGrid
    {
        #region graphics
        private static string[] _finishHorizontal = { "----", "  # ", "  # ", "----" };
        private static string[] _finishVertical = { "|  |", "|##|", "|##|", "|  |" };
        private static string[] _startHorizontal = { "----", " ]  ", "  ] ", "----" };
        private static string[] _startVertical = { "|  |", "|_ |", "| _|", "|  |" };
        private static string[] _westToSouth = { "--\\ ", "   \\", "   |", "|  |" };
        private static string[] _northToWest = { "/  |", "   |", "   /", "--/ " };
        private static string[] _eastToNorth = { "|  \\", "|   ", "\\   ", " \\--" };
        private static string[] _southToEast = { " /--", "/   ", "|   ", "|  |" };
        private static string[] _horizontalTrack = { "----", "    ", "    ", "----", };
        private static string[] _verticalTrack = { "|  |", "|  |", "|  |", "|  |" };
        #endregion
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void GetStartShould_ReturnHorizontal()
        {
            //setup
            int direction = 1;
            int direction2 = 3;

            //actions
            var result = Visualisatie.GetStartGrid(direction);
            var result2 = Visualisatie.GetStartGrid(direction2);

            //assertions
            Assert.AreEqual(result, _startHorizontal);
            Assert.AreEqual(result, _startHorizontal);
        }
        [Test]
        public void GetStartShould_ReturnVertical()
        {
            //setup
            int direction = 0;
            int direction2 = 2;

            //actions
            var result = Visualisatie.GetStartGrid(direction);
            var result2 = Visualisatie.GetStartGrid(direction2);

            //assertions
            Assert.AreEqual(result, _startVertical);
            Assert.AreEqual(result, _startVertical);
        }
    }
}
