using System.Threading;
using Exam.Helpers;

namespace Exam.Models
{
    public class Student
    {
        private readonly Deanery _deanery;
        public string Name;
        private readonly Helper _helper = new Helper();


        public Student(Deanery deanery)
        {
            if (deanery == null) return;
            _deanery = deanery;
            Name = _helper.StudentName();
        }

        public void TryPassExam()
        {
            _deanery.ExamStarted.WaitOne();
            Thread.Sleep(_helper.GetUpToTenSeconds());
            _deanery.ExamineStudent(this);
        }
    }
}