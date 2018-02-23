using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.DataModel
{
    public partial class Teacher
    {
        private const int MAX_CLASS_SIZE = 8;

        public void EnrollInClass(Student student)
        {
            var students = (from s in Students
                            where s.TeacherUserId == UserId
                            select s).Count();

            if (students >= MAX_CLASS_SIZE)
            {
                throw new ClassFullException("The student couldn't be added because the class is already full.", Class);
            }

            if (student.TeacherUserId == null)          //If the student has no TeacherID and therefore no Teacher, the Student's TeacherID will be set to the current Teacher who is adding said student.
            {
                student.TeacherUserId = UserId;
            }
            else
            {
                throw new ArgumentException("The student is already assigned to a class!");
            }
        }
    }
}
