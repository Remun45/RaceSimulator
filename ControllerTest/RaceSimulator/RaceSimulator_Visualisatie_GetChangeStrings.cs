using Model;
using NUnit.Framework;
using RaceSimulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerTest.RaceSimulator
{
    [TestFixture]
    class RaceSimulator_Visualisatie_GetChangeStrings
    {
        [SetUp]
        public void SetUp()
        {

        }
        [TestCase("----", "----")]
        [TestCase("| 1|", "| R|")]
        [TestCase("|2 |", "|P |")]
        [TestCase("|  |", "|  |")]

        public void ChangeStrings_Should_Return(string tekst, string expected)
        {
            //setup
            IParticipant een = new Driver("Remon", 0, new SnowMobile(), TeamColors.Red);
            IParticipant twee = new Driver("Peter", 0, new SnowMobile(), TeamColors.Red);

            //action
            var result = Visualisatie.ChangeStrings(tekst, een, twee);

            //assert
            Assert.AreEqual(result, expected);
        }
    }
}
