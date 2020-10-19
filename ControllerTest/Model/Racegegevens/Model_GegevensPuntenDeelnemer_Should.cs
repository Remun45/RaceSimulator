using System;
using System.Collections.Generic;
using System.Text;
using Model;
using NUnit.Framework;

namespace ControllerTest.Model.Racegegevens
{
    [TestFixture]
    class Model_GegevensPuntenDeelnemer_Should
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShouldReturnNull()
        {
            //setup
            RaceGegevens<GegevensPuntenDeelnemer> list = new RaceGegevens<GegevensPuntenDeelnemer>();
            IParticipant deelnemer = new Driver();
            Track track = new Track("TestTrack");

            //actions
            list.AddItemToList(new GegevensPuntenDeelnemer(){ AantalPunten = 10, Deelnemer = deelnemer, Track = track });
            string expected = "De meeste punten zijn voor: 10";
            string result = list.Print();

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
