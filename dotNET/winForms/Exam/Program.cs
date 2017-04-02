using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam.Controllers;

namespace Exam
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var examForm = new View.ExamForm();
            var examController = new ExamController(examForm);
            examForm.ShowDialog();
        }
    }
}
