using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ControllerTest
{
    [TestFixture]
    class Model_Competition_NextTrackShould
    {
        private Competition _competition;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }
        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {
            var result = _competition.NextTrack();
            Assert.IsNull(result);
        }
        [Test]
        public void NextTrack_OneInQueue_ReturnTrack()
        {
            Track track = new Track("Very nice");
            _competition.Tracks.Enqueue(track);
            var result = _competition.NextTrack();
            Assert.AreEqual(result, track);
        }
        [Test]
        public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        {
            Track track = new Track("cool");
            _competition.Tracks.Enqueue(track);
            var result = _competition.NextTrack();
            result = _competition.NextTrack();
            Assert.IsNull(result);
        }
        [Test]
        public void NextTrack_TwoInQueue_ReturnNextTrack()
        {
            Track track1 = new Track("track 1");
            Track track2 = new Track("track 2");

            _competition.Tracks.Enqueue(track1);
            _competition.Tracks.Enqueue(track2);

            var result1 = _competition.NextTrack();
            Assert.AreEqual(result1, track1);

            var result2 = _competition.NextTrack();
            Assert.AreEqual(result2, track2);
        }
    }
}
