using System;
using System.Collections.Generic;
using System.Text;
using Model;
using NUnit.Framework;
using RaceSimulator;

namespace ControllerTest.RaceSimulator
{
    [TestFixture]
    class RaceSimulator_Visualisatie_GetGoodGraphics
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
        public void GetGoodGraphics_Should_ReturnFinishHorizontal()
        {
            //setup
            SectionTypes section = SectionTypes.Finish;

            int direction = 1;
            int direction2 = 3;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section, direction2);

            //Assertions
            Assert.AreEqual(result, _finishHorizontal);
            Assert.AreEqual(result2, _finishHorizontal);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnFinishVertical()
        {
            //setup
            SectionTypes section = SectionTypes.Finish;

            int direction = 0;
            int direction2 = 2;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section, direction2);

            //Assertions
            Assert.AreEqual(result, _finishVertical);
            Assert.AreEqual(result2, _finishVertical);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnStartHorizontal()
        {
            //setup
            SectionTypes section = SectionTypes.StartGrid;

            int direction = 1;
            int direction2 = 3;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section, direction2);

            //Assertions
            Assert.AreEqual(result, _startHorizontal);
            Assert.AreEqual(result2, _startHorizontal);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnStartVertical()
        {
            //setup
            SectionTypes section = SectionTypes.StartGrid;

            int direction = 0;
            int direction2 = 2;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section, direction2);

            //Assertions
            Assert.AreEqual(result, _startVertical);
            Assert.AreEqual(result2, _startVertical);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnStraightHorizontal()
        {
            //setup
            SectionTypes section = SectionTypes.Straight;

            int direction = 1;
            int direction2 = 3;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section, direction2);

            //Assertions
            Assert.AreEqual(result, _horizontalTrack);
            Assert.AreEqual(result2, _horizontalTrack);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnStraightVertical()
        {
            //setup
            SectionTypes section = SectionTypes.Straight;

            int direction = 0;
            int direction2 = 2;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section, direction2);

            //Assertions
            Assert.AreEqual(result, _verticalTrack);
            Assert.AreEqual(result2, _verticalTrack);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnWestToSouth()
        {
            //setup
            SectionTypes section = SectionTypes.RightCorner;
            SectionTypes section2 = SectionTypes.LeftCorner;

            int direction = 1;
            int direction2 = 0;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section2, direction2);

            //Assertions
            Assert.AreEqual(result, _westToSouth);
            Assert.AreEqual(result2, _westToSouth);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnNorthToWest()
        {
            //setup
            SectionTypes section = SectionTypes.RightCorner;
            SectionTypes section2 = SectionTypes.LeftCorner;

            int direction = 2;
            int direction2 = 1;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section2, direction2);

            //Assertions
            Assert.AreEqual(result, _northToWest);
            Assert.AreEqual(result2, _northToWest);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnEastToNorth()
        {
            //setup
            SectionTypes section = SectionTypes.RightCorner;
            SectionTypes section2 = SectionTypes.LeftCorner;

            int direction = 3;
            int direction2 = 2;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section2, direction2);

            //Assertions
            Assert.AreEqual(result, _eastToNorth);
            Assert.AreEqual(result2, _eastToNorth);
        }
        [Test]
        public void GetGoodGraphics_Should_ReturnSouthToEast()
        {
            //setup
            SectionTypes section = SectionTypes.RightCorner;
            SectionTypes section2 = SectionTypes.LeftCorner;

            int direction = 0;
            int direction2 = 3;

            //Actions
            var result = Visualisatie.GetGoodGraphics(section, direction);
            var result2 = Visualisatie.GetGoodGraphics(section2, direction2);

            //Assertions
            Assert.AreEqual(result, _southToEast);
            Assert.AreEqual(result2, _southToEast);
        }
    }
}
