using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _4sem_course_project
{
    /// <summary>
    /// The class responsible for work with study module.
    /// Has property Cards.
    /// </summary>
    [Serializable]
    public class Module
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlArray(ElementName = "cards")]
        [XmlArrayItem(ElementName = "card")]
        /// <summary>
        /// Returns copy of the list of cards. Sets new list of cards.
        /// </summary>
        public List<Card> Cards
        {
            get
            {
                return _cards;
            }
            set
            {
                foreach (var card in value)
                {
                    AddCard(card.Term, card.Definition);
                }
            }
        }

        private List<Card> _cards = new List<Card>();

        

        public Module() { }

        public Module(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Adds new card to list of cards in module.
        /// Throws CardsContainsSameTermsException in case of adding second card with the same term.
        /// </summary>
        /// <param name="term"></param>
        /// <param name="definition"></param>
        /// <exception cref="CardsContainsSameTermsException"></exception>
        public void AddCard(string term, string definition)
        {
            if (_cards.Where(x => x.Term.Equals(term)).Count() == 0)
            {
                _cards.Add(new Card(term, definition));
            }
            else
            {
                throw new Exception("CardsContainsReccuringTermsException");
            }
        }

        /// <summary>
        /// Deletes card from list of cards in module by its term.
        /// Throws NoCardWithThisTermWasFoundException if there is no card with input term.
        /// </summary>
        /// <param name="term"></param>
        /// <exception cref="NoCardWithThisTermWasFoundException"></exception>
        public void DeleteCard(string term)
        {
            if (!_cards.Remove(_cards.Find(x => x.Term.Equals(term))))
            {
                throw new Exception("NoCardWithThisTermWasFoundException");
            }
        }

        /// <summary>
        /// Sets new definition to card with entered term. 
        /// Throws NoCardWithThisTermWasFoundException if there is no card with entered term in card list.
        /// </summary>
        /// <param name="term"></param>
        /// <param name="newDefinition"></param>
        /// <exception cref="NoCardWithThisTermWasFoundException"></exception>
        public void EditCard(string term, string newDefinition)
        {
            if (_cards.Where(x => x.Term.Equals(term)).Count() != 0)
            {
                _cards[_cards.FindIndex(x => x.Term.Equals(term))].Definition = newDefinition;
            }
            else
            {
                throw new Exception("NoCardWithThisTermWasFoundException");
            }
        }

        public override bool Equals(object obj)
        {
            var cardList = ((Module)obj).Cards;
            bool result = true;
            for (int i = 0; i < _cards.Count; i++)
                result &= _cards[i].Equals(cardList[i]);
            return result && (_cards.Count == cardList.Count);
        }
    }
}
