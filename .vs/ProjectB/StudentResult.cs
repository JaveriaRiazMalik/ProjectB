using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    /// <summary>
    /// class corresponding to StudentResult table in database
    /// </summary>
    class StudentResult
    {
        private int studentid; //primary key
        private int assessmentcomponentid; //primary key
        private int rubricmeasurementid;
        private DateTime evaluationdate;

        public int Studentid { get => studentid; set => studentid = value; }
        public int Assessmentcomponentid { get => assessmentcomponentid; set => assessmentcomponentid = value; }
        public int Rubricmeasurementid { get => rubricmeasurementid; set => rubricmeasurementid = value; }
        public DateTime Evaluationdate { get => evaluationdate; set => evaluationdate = value; }
    }
}
