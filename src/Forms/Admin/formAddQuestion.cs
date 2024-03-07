using System.Data;
using System.Diagnostics;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Forms
{
    public partial class formAddQuestion : Form
    {
        public formAddQuestion()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Debug.Print("Clicked Button Craete");
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

            var serialized = LonConvert.Serialize(tq);

            using (StreamWriter sw = new("questions.qon", true))
            {
                sw.WriteLine(serialized);
            }

            foreach (var textbox in Controls.OfType<TextBox>())
            {
                textbox.Text = "";
            }

            Debug.Print($"Written to file");
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ActivateForm<formMenu>();
        }

        private void txtBoxRating_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
