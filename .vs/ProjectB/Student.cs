using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    /// <summary>
    /// Data retrieved from Student table from database
    /// </summary>
    class Student
    {
        private int id; //primary key
        private string firstName;
        private string lastName;
        private string contact;
        private string email;
        private string registrationNo;
        private int status;
        private string statusid;

        public int Id { get => id; set => id = value; }
        public string Contact { get => contact; set => contact = value; }
        public string RegistrationNo { get => registrationNo; set => registrationNo = value; }
        public int Status { get => status; set => status = value; }

        public string FirstName
        {
            get
            { return firstName; }

            set
            {
                bool n = true;
                if (string.IsNullOrEmpty(value))
                { n = false; }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!Char.IsLetter(value[i]) && !Char.IsWhiteSpace(value[i])) //validation check in the setter to check that the given name should be alphabets
                        {
                            n = false;

                        }

                    }
                }
                if (n == true)
                {
                    firstName = value;
                }
                else
                {
                    throw new Exception(); //excaeption is raised in case of an error
                }
            }
        }


        public string LastName
        {
            get
            { return lastName; }

            set
            {
                bool n = true;
                if (string.IsNullOrEmpty(value))
                { n = false; }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!Char.IsLetter(value[i]) && !Char.IsWhiteSpace(value[i])) //validation check in the setter to check that the given name should be alphabets
                        {
                            n = false;

                        }

                    }
                }
                if (n == true)
                {
                    lastName = value;
                }
                else
                {
                    throw new Exception(); //excaeption is raised in case of an error
                }
            }
        }


        public string Email
        {
            get
            { return email; }

            set
            {
                bool n = true;
                foreach (char c in value)
                {
                    if (Char.IsWhiteSpace(c)) //there should not be any spaces in the email id
                    {
                        n = false;
                    }
                }
                if (n)
                {
                    email = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public string Statusid { get => statusid; set => statusid = value; }
    }
}
