using NUnit.Framework;
using _4sem_course_project;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private Module module;
        
        [SetUp]
        public void init()
        {
            module = new Module("модуль", "описание");
        }

        [Test]
        public void AddCardTest()
        {
            var expectedCards = new List<Card>();
            expectedCards.Add(new Card("1", "One"));
            expectedCards.Add(new Card("2", "Two"));
            module.AddCard("1", "One");
            module.AddCard("2", "Two");
            Assert.AreEqual(expectedCards, module.Cards);
        }

        [Test]
        public void DeleteCardTest()
        {
            var expectedCards = new List<Card>();
            expectedCards.Add(new Card("1", "One"));
            expectedCards.Add(new Card("3", "Three"));
            module.AddCard("1", "One");
            module.AddCard("2", "Two");
            module.AddCard("3", "Three");
            module.DeleteCard("2");
            Assert.AreEqual(expectedCards, module.Cards);
        }

        [Test]
        public void EditCardTest()
        {
            var expectedCards = new List<Card>();
            expectedCards.Add(new Card("1", "One"));
            expectedCards.Add(new Card("2", "Two"));
            expectedCards.Add(new Card("3", "Edited three"));
            module.AddCard("1", "One");
            module.AddCard("2", "Two");
            module.AddCard("3", "Three");
            module.EditCard("3", "Edited three");
            Assert.AreEqual(expectedCards, module.Cards);
        }

        [Test]
        public void SetCardsTest()
        {
            var expectedCards = new List<Card>();
            expectedCards.Add(new Card("1", "One"));
            expectedCards.Add(new Card("2", "Two"));
            module.Cards = expectedCards;
            Assert.AreEqual(expectedCards, module.Cards);
        }
    }
}