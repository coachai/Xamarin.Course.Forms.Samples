using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent2
{
    public class PersonViewModel : IPersonViewModel
    {
        List<Person> personList = new List<Person>();

        public PersonViewModel()
        {
            personList.Add(new Person("Jens", "Hansen", "Emoji1"));
            personList.Add(new Person("Magnus", "Olsen", "Emoji2"));
            personList.Add(new Person("Johny", "Bravo", "Emoji3"));
            personList.Add(new Person("Chicken", "Chickensen", "Emoji4"));
            personList.Add(new Person("Spongebob", "Squarepants", "Emoji5"));
            personList.Add(new Person("Donald", "Duck", "Emoji6"));
            personList.Add(new Person("Slambert", "Kvasitorp", "Emoji7"));
            personList.Add(new Person("Sleske", "Sleskesen", "Emoji8"));
            personList.Add(new Person("Hammer", "Hammersen", "Emoji9"));
            personList.Add(new Person("Cow", "Cowsen", "Emoji10"));
        }

        public List<Person> AllPersons
        {
            get
            {
                return personList;
            }
        }
    }
}
