using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    /// <summary>
    /// Data retrieved from Rubric table from database
    /// </summary>
    class Rubric
    {
        private int id; //primary key
        private int cloid;
        private string details;

        public int Id { get => id; set => id = value; }
        public int Cloid { get => cloid; set => cloid = value; }
        public string Details { get => details; set => details = value; }
    }
}
