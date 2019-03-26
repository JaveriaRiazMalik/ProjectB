using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class Assessment
    {
        private int id;
        private string title;
        private DateTime datecreated;
        private int totalmarks;
        private int totalweightage;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public DateTime Datecreated { get => datecreated; set => datecreated = value; }
        public int Totalmarks { get => totalmarks; set => totalmarks = value; }
        public int Totalweightage { get => totalweightage; set => totalweightage = value; }
    }
}
