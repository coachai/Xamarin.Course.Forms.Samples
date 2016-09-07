using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent2
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string imagePath;

        public Person(string firstName, string lastName, string imagePath)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.imagePath = imagePath;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
            }
        }
    }
}
