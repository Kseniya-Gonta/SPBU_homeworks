using System;
using System.Threading;
using Exam.Controllers;
using Exam.Helpers;

namespace Exam.Models
{
    public class Deanery
    {
        public ManualResetEvent ExamStarted { get; }
        private readonly object _lockingObject = new object();
        private readonly Helper _helper = new Helper();
        public event EventHandler<PrintStudentEventArgs> PrintStudent;
        public class PrintStudentEventArgs : EventArgs
        {
            public string StudentName;
            public int StudentMark;
        }

        public Deanery()
        {
            ExamStarted = new ManualResetEvent(false);
        }

        public void StartExam()
        {
            ExamStarted.Set();
        }

        public void ExamineStudent(Student student)
        {
            lock (_lockingObject)
            {

                var printStudentEventArgs = new PrintStudentEventArgs();
                if (PrintStudent == null) return;
                printStudentEventArgs.StudentName = student.Name;
                printStudentEventArgs.StudentMark = _helper.StudentMark();
                PrintStudent(this, printStudentEventArgs);
            }
        }
    }
}