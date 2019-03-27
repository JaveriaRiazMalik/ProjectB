using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    /// <summary>
    /// class of ClassAttendance
    /// </summary>
    class ClassAttendance
    {
        private int id;
        private DateTime attendancedate;

        public int Id { get => id; set => id = value; }
        public DateTime Attendancedate { get => attendancedate; set => attendancedate = value; }
    }
}
