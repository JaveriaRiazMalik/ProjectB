using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    /// <summary>
    /// class of StudentAttendance
    /// </summary>
    class StudentAttendance
    {
        private int attendanceid; //primary key
        private int studentid; //primary key
        private int attendancestatus;

        public int Attendanceid { get => attendanceid; set => attendanceid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Attendancestatus { get => attendancestatus; set => attendancestatus = value; }
    }
}
