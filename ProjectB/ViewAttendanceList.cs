using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class ViewAttendanceList
    {
        private string firstname;
        private string lastname;
        private string regno;
        private int attendancestatus;
        private int attendanceid;
        private int studentid;
        private string status;

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Regno { get => regno; set => regno = value; }
        public int Attendanceid { get => attendanceid; set => attendanceid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
       public string Status { get => status; set => status = value; }
        public int Attendancestatus { get => attendancestatus; set => attendancestatus = value; }
    }
}
