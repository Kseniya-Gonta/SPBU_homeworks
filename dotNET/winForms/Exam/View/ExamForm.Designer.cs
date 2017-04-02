namespace Exam.View
{
    partial class ExamForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.studentsMarks = new System.Windows.Forms.ListView();
            this.labelExamState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(250, 50);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(50, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += OnButtonStartClick;
            //this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // studentsMarks
            // 
            this.studentsMarks.Location = new System.Drawing.Point(50, 50);
            this.studentsMarks.Name = "studentsMarks";
            this.studentsMarks.Size = new System.Drawing.Size(150, 400);
            this.studentsMarks.TabIndex = 3;
            this.studentsMarks.UseCompatibleStateImageBehavior = false;
            //
            // labelExamState
            //
            this.labelExamState.AutoSize = true;
            this.labelExamState.Location = new System.Drawing.Point(250, 100);
            this.labelExamState.Name = "labelExamState";
            this.labelExamState.Size = new System.Drawing.Size(99, 13);
            this.labelExamState.TabIndex = 2;
            this.labelExamState.Text = "Exam finished";
            this.labelExamState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelExamState.Visible = false;
            //this.studentsMarks.SelectedIndexChanged += new System.EventHandler(this.studentsMarks_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.studentsMarks);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labelExamState);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView studentsMarks;
        private System.Windows.Forms.Label labelExamState;
    }
}

