using System;
using System.Collections.Generic;

namespace _4sem_course_project.Controller.ModePkg.Impl
{
    /// <summary>
    /// The mode responsible for mixing cards mode. Implements IMode.
    /// </summary>
    public class ShuffleMode : IMode
    {
        public List<Card> GetCardList(List<Card> list)
        {
            var lst = new List<Card>(list);
            var rnd = new Random();
            for (int i = lst.Count - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = lst[j];
                lst[j] = lst[i];
                lst[i] = temp;
            }
            return lst;
        }
    }
}
