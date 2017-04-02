using System;
using System.Windows.Forms;
using Mono.CSharp;

namespace Exam.View
{
    public sealed partial class ExamForm : Form
    {

        public event EventHandler ExamStarted;

        public ExamForm()
        {
            InitializeComponent();
            ResetViewToExamStart();
        }

        public void SetStudent(string studentName, int mark)
        {
            InvokeIfNeeded(studentsMarks, ()
                => studentsMarks.Items.Insert(1, studentName));
        }

        public void PrintStudentName(int id, string name)
        {
            InvokeIfNeeded(studentsMarks, ()
                => studentsMarks.Items.Add(new ListViewItem(new[] { name })));
        }

        public void PrintStudentMark(int id, int mark)
        {
            InvokeIfNeeded(studentsMarks, () => studentsMarks.Items.Add(mark.ToString()));
        }


        private void OnButtonStartClick(object sender, EventArgs e)
        {
            ResetViewToExamStart();
            ExamStarted?.Invoke(this, EventArgs.Empty);
        }


        private void ResetViewToExamStart()
        {
            InvokeIfNeeded(this, () =>
            {
                studentsMarks.Items.Clear();
                studentsMarks.Refresh();
                labelExamState.Text = "Examination...";
            });

        }

        public void FinishExam()
        {

            InvokeIfNeeded(this, () =>
            {
                labelExamState.Text = "Exam completed!";
                labelExamState.Show();

                btnStart.Enabled = true;
            });
        }

        private static void InvokeIfNeeded(Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }

    }





}

