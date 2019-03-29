using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    /// <summary>
    /// Data retrieved from RubricLevel table from database
    /// </summary>
    class RubricLevel
    {
        private int id; //primary key
        private int RubricId;
        private string details;
        private int Mlevel;

        public int Id { get => id; set => id = value; }
        public int RubricId1 { get => RubricId; set => RubricId = value; }
        public string Details { get => details; set => details = value; }
        public int Mlevel1 { get => Mlevel; set => Mlevel = value; }
    }
}
