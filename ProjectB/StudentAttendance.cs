using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class StudentAttendance
    {
        private int attendanceid;
        private int studentid;
        private int attendancestatus;

        public int Attendanceid { get => attendanceid; set => attendanceid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Attendancestatus { get => attendancestatus; set => attendancestatus = value; }
    }
}
