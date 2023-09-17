using System.Collections.Generic;

namespace _4sem_course_project.Controller.ModePkg
{
    /// <summary>
    /// Contract for all modes.
    /// </summary>
    public interface IMode
    {
        /// <summary>
        /// Defines the order of cards due to mode logic.
        /// </summary>
        /// <param name="list"></param>
        /// <returns> List of cards in special order. </returns>
        List<Card> GetCardList(List<Card> list);
    }
}
