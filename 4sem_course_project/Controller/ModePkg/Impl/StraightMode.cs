using System.Collections.Generic;

namespace _4sem_course_project.Controller.ModePkg.Impl
{
    /// <summary>
    /// The mode responsible for straight order of cards mode. Implements IMode.
    /// </summary>
    public class StraightMode : IMode
    {
        public List<Card> GetCardList(List<Card> list) => list;
    }
}
