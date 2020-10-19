using System;
using System.Collections.Generic;
using System.Text;
using Model;
using NUnit.Framework;

namespace ControllerTest.Model
{
    [TestFixture]
    class Model_Track_Should
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void TrackConstructorShould()
        {
            string name = "circuitje niffo";
            SectionTypes[] section = new SectionTypes[]
            {
                SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.RightCorner, SectionTypes.Straight,
                SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.RightCorner,
                SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.StartGrid, SectionTypes.StartGrid
            };

            Track cool = new Track(name, section);
            LinkedList<Section> sections = cool.ConvertArrayToLinkedList(section);
            Assert.AreEqual(name, cool.Name);
            Assert.AreEqual(sections, cool.Sections);
        }

        [Test]
        public void TrackConvertArray_Should()
        {
            Track lit = new Track("lit");
            LinkedList<Section> sections = new LinkedList<Section>();
            sections.AddLast(new Section(SectionTypes.StartGrid));
            sections.AddLast(new Section(SectionTypes.Finish));
            SectionTypes[] array = {SectionTypes.StartGrid, SectionTypes.Finish};

            Assert.AreEqual(lit.ConvertArrayToLinkedList(array), sections);
        }
    }
}
