using System;
using System.Threading;
using Exam.Models;
using Exam.View;
using Exam.Helpers;

namespace Exam.Controllers
{
    public class ExamController
    {
        private readonly ExamForm _form;
        private readonly Deanery _deanery;
        private int AmountOfStudents;
        private int AmountOfPassedStudents;
        private static readonly Helper Helper = new Helper();

        public ExamController(ExamForm form)
        {
            _form = form;
            _form.ExamStarted += OnExamStarted;
            AmountOfPassedStudents = 0;
            _deanery = new Deanery();

            _deanery.PrintStudent += (sender, e) => PrintStudentResult(e.StudentName, e.StudentMark);
        }

        public void PrintStudentResult(string name, int mark)
        {
            _form.PrintStudentName(AmountOfPassedStudents, name);
            Thread.Sleep(Helper.GetUpToThreeSeconds());
            _form.PrintStudentMark(AmountOfPassedStudents, mark);
            AmountOfPassedStudents++;

            if (AmountOfPassedStudents >= AmountOfStudents)
            {
                _form.FinishExam();
            }
        }

        private void OnExamStarted(object sender, EventArgs e)
        {
            _deanery.StartExam();
            AmountOfStudents = Helper.AmountOfStudents();
            for (var i = 0; i < AmountOfStudents; i++)
            {
                new Thread(new Student(_deanery).TryPassExam).Start();
            }
            Console.WriteLine("Started exam");
        }


    }
}