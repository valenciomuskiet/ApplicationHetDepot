using System;
using System.IO;

namespace sprint2testingthings
{
     class Contact
	 {
		public string Name;
		public int PhoneNumber;
		public string Tijd;

        public override string ToString()
        {
            return string.Format("Contact Information:\n\tName: {0}, Phonenumber: {1}, Age: {2}", Name, PhoneNumber, Tijd  );
        }


     }
}
