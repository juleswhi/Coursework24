using System.Data;
using ChessMasterQuiz.Forms.Admin;

namespace ChessMasterQuiz.Forms
{
    public partial class formAddQuestion : Form
    {
        public formAddQuestion() =>
            InitializeComponent();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<CheckBox> checkBoxes = new()
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
            };

            if (checkBoxes.Where(x => x.Checked).Count() != 1)
            {
                return;
            }

            TextQuestion tq = new()
            {
                Q = txtBoxQuestion.Text,
                A = new Answer(new() { txtBoxAnswerOne.Text, txtBoxAnswerTwo.Text, txtBoxAnswerThree.Text, txtBoxAnswerFour.Text }, (uint)checkBoxes.IndexOf(checkBoxes.First(x => x.Checked))),
                Rating = int.Parse(txtBoxRating.Text)
            };

            var serialized = QonConvert.Serialize(tq);

            using (StreamWriter sw = new("questions.qon", true))
            {
                sw.WriteLine(serialized);
            }

            // Clear all text boxes for next question
            foreach (var textbox in Controls.OfType<TextBox>())
            {
                textbox.Text = "";
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ActivateForm<formAdminMenu>();
        }
    }
}
