using System;
using System.Windows.Forms;

namespace _4sem_course_project.View.AdditionalFormPkg
{
    public partial class CheckSaveForm : Form
    {
        public bool IsAnswerYes;

        public CheckSaveForm()
        {
            InitializeComponent();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            IsAnswerYes = true;
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            IsAnswerYes = false;
            Close();
        }
    }
}
