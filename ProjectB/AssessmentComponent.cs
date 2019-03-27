using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    /// <summary>
    /// class of AssessmentComponent
    /// </summary>
    class AssessmentComponent
    {
        private int id;
        private int rubricid;
        private int assessmentid;
        private int totalmarks;
        private string name;
        private DateTime datecreated;
        private DateTime dateupdated;

        public int Id { get => id; set => id = value; }
        public int Rubricid { get => rubricid; set => rubricid = value; }
        public int Assessmentid { get => assessmentid; set => assessmentid = value; }
        public int Totalmarks { get => totalmarks; set => totalmarks = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Datecreated { get => datecreated; set => datecreated = value; }
        public DateTime Dateupdated { get => dateupdated; set => dateupdated = value; }
    }
}
