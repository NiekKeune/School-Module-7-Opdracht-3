using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Grades.DataModel
{
    public partial class Grade
    {
        public bool ValidateAssessmentDate(DateTime assessmentDate)
        {
            if (assessmentDate > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("AssessmentDate", "The inserted date is later than the current date, and could therefore not be added.");
            }

            else
            {
                return true;
            }
        }

        public bool ValidateAssessmentGrade(string assessment)
        {
            Match matchGrade = Regex.Match(assessment, @"^[A-E][+-]?$");        //Checks if the current string contains any character between A-E (with + and - also being acceptable) and if the character does match, it'll return true.

            if (matchGrade.Success == false)
            {
                throw new ArgumentOutOfRangeException("AssessmentGrade", "The inserted grade falls outside of the range of the possible grades, and could therefore not be added.");
            }

            else
            {
                return true;
            }
        }
    }
}
