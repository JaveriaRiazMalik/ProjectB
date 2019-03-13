using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class CLO
    {
        private int id;
        private string name;
        private DateTime DateCreated;
        private DateTime DateUpdated;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateCreated1 { get => DateCreated; set => DateCreated = value; }
        public DateTime DateUpdated1 { get => DateUpdated; set => DateUpdated = value; }
    }
}
