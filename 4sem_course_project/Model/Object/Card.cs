using System;
using System.Xml.Serialization;

namespace _4sem_course_project
{
    /// <summary>
    /// The class responsible for card. Contains properties term and definition.
    /// </summary>
    [Serializable]
    public class Card
    {
        [XmlElement ("term")]
        public string Term { get; set; }

        [XmlElement ("definition")]
        public string Definition { get; set; }

        public Card() { }
        public Card(string term, string definition) 
        {
            Term = term;
            Definition = definition;
        }

        public override bool Equals(object obj)
        {
            var card = (Card)obj;
            return (Term.Equals(card.Term) && Definition.Equals(card.Definition));
        }
    }
}
