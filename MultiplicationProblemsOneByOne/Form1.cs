using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiplicationProblemsOneByOne
{
    public partial class Form1 : Form
    {
        private const int countOfProblems = 8;
        private const int countOfMultipliers = 2;
        private Font font = new Font("Microsoft Sans Serif", 18);
        private int difficulty = 0;
        private int indexOfCurrentProblem = 0; 
        private List<int> rightAnswers = new List<int>();
        List<int[]> problems = new List<int[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            int difficulty = 0;
            if (radioButton1.Checked) difficulty = 2;
            if (radioButton2.Checked) difficulty = 3;
            if (radioButton3.Checked) difficulty = 4;
            radioButton1.TabStop = false;
            radioButton2.TabStop = false;
            radioButton3.TabStop = false;
            Reset(difficulty);
        }

        private void Reset(int difficulty)
        {
            this.difficulty = difficulty;
            mainPanel.Width = 20 + 45 * this.difficulty;
            mainPanel.Height = 110 + 45 * this.difficulty;
            MinimumSize = new Size(220 + 45 * this.difficulty, 210 + 45 * this.difficulty);
            MaximumSize = new Size(220 + 45 * this.difficulty, 210 + 45 * this.difficulty);
            mainPanel.BackColor = SystemColors.Control;
            indexOfCurrentProblem = 0;
            rightAnswers.Clear();
            problems.Clear();
            GenerateSums(countOfProblems);
            Display(indexOfCurrentProblem);
            ResetProgress();
        }

        private void GenerateSums(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int[] problem = new int[countOfMultipliers];
                do
                {
                    for (int j = 0; j < countOfMultipliers; j++)
                    {
                        do
                        {
                            problem[j] = random.Next((int)Math.Pow(10, difficulty - 1), (int)Math.Pow(10, difficulty));
                        }
                        while (problem[j] % 10 == 0);
                    }
                }
                while (problems.Contains(problem));
                problems.Add(problem);
            }
        }

        private void Display(int index)
        {
            mainPanel.Controls.Clear();
            int yLocation = 5;
            for (int i = 0; i < problems[index].Length; i++)
            {
                mainPanel.Controls.Add(CreateLabel("multiplier" + i, problems[index][i].ToString(), new Point(0, yLocation), new Size(mainPanel.Size.Width, 30), ContentAlignment.TopRight));
                yLocation += 30;
            }
            mainPanel.Controls.Add(CreateLabel("x", "x", new Point(0, 18), new Size(30, 30), ContentAlignment.TopLeft));
            mainPanel.Controls["x"].BringToFront();
            yLocation -= 25;
            mainPanel.Controls.Add(CreateLabel("lineOne", "_______________________________________________________________________", new Point(0, yLocation), new Size(mainPanel.Size.Width + 10, 40), ContentAlignment.TopLeft));
            mainPanel.Controls["lineOne"].SendToBack();
            yLocation += 30;
            for (int i = 0; i < difficulty; i++)
            {
                mainPanel.Controls.Add(CreateCellsPanel("summand" + i, new Point(20, yLocation), new Size(mainPanel.Size.Width - 23, 40)));
                mainPanel.Controls["summand" + i].BringToFront();
                yLocation += 45;
            }
            for (int i = 0; i < difficulty - 1; i++)
            {
                mainPanel.Controls.Add(CreateLabel("plus" + i, "+", new Point(0, 93 + 45 * i), new Size(20, 20), ContentAlignment.TopLeft));
            }
            mainPanel.Controls.Add(CreateCellsPanel("answer", new Point(20, yLocation), new Size(mainPanel.Size.Width - 23, 40)));
            yLocation -= 30;
            mainPanel.Controls.Add(CreateLabel("secondLine", "_______________________________________________________________________", new Point(0, yLocation), new Size(mainPanel.Size.Width + 10, 40), ContentAlignment.TopLeft));
        }

        private Label CreateLabel(string name, string content, Point location, Size size, ContentAlignment align)
        {
            Label label = new Label();
            label.Text = content;
            label.Font = font;
            label.Size = size;
            label.Location = location;
            label.TextAlign = align;
            label.Name = name;
            return label;
        }

        private Panel CreateCellsPanel(string name, Point location, Size size)
        {
            Panel panel = new Panel();
            panel.Location = location;
            panel.Size = size;
            panel.Name = name;
            for (int i = 0; i < difficulty * countOfMultipliers; i++)
            {
                TextBox tb = new TextBox();
                tb.Name = i.ToString();
                tb.Location = new Point(panel.Size.Width - 21 * (i + 1), 0);
                tb.Size = new Size(20, 20);
                tb.Font = font;
                tb.MaxLength = 1;
                tb.KeyDown += new KeyEventHandler(NextTabOnReturnOrSpace);
                tb.KeyDown += new KeyEventHandler(ControlWithArrows);
                tb.KeyPress += new KeyPressEventHandler(OnlyDigitsInput);
                panel.Controls.Add(tb);
            }
            return panel;
        }

        private void OnlyDigitsInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SelectAllOnEnter(object sender, EventArgs e)
        {
            (sender as NumericUpDown).Select(0, this.ActiveControl.ToString().Length);
        }

        private void NextTabOnReturnOrSpace(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void ControlWithArrows(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    e.SuppressKeyPress = true;
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
                    break;
                case Keys.Up:
                    e.SuppressKeyPress = true;
                    for (int i = 0; i < difficulty * countOfMultipliers; i++)
                    {
                        this.SelectNextControl(this.ActiveControl, false, true, true, true);
                    }
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    for (int i = 0; i < difficulty * countOfMultipliers; i++)
                    {
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                    break;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            Check(indexOfCurrentProblem);
        }

        private bool Check(int index)
        {
            int[] problem = problems[index];
            bool isRight = true;
            List<int> summandsAnswer = new List<int>();
            List<int> summandsInput = new List<int>();
            int temp = problem[countOfMultipliers - 1];
            for (int i = 0; i < difficulty; i++)
            {
                int summand = problem[0] * (temp % 10);
                summandsAnswer.Add(summand * (int)Math.Pow(10, i));
                string mask = CreateMaskOfAnswer(summand, i);
                summandsInput.Add(ReadCellsToInt("summand" + i, mask));
                temp = temp / 10;
            }
            int answerInput = ReadCellsToInt("answer", CreateMaskOfAnswer(problem[0] * problem[1], 0));
            int answer = 1;
            foreach (int multiplier in problem)
            {
                answer = answer * multiplier;
            }
            if (answer == answerInput)
            {
                foreach (Control c in mainPanel.Controls["answer"].Controls)
                {
                    c.BackColor = Color.LightGreen;
                }
            }
            else
            {
                isRight = false;
                foreach (Control c in mainPanel.Controls["answer"].Controls)
                {
                    c.BackColor = Color.IndianRed;
                }
            }
            for (int i = 0; i < difficulty; i++)
            {
                if (summandsInput[i] == summandsAnswer[i])
                {
                    foreach (Control c in mainPanel.Controls["summand" + i].Controls)
                    {
                        c.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    isRight = false;
                    foreach (Control c in mainPanel.Controls["summand" + i].Controls)
                    {
                        c.BackColor = Color.IndianRed;
                    }
                }
            }
            if (isRight)
            {
                mainPanel.BackColor = Color.LightGreen;
                foreach (Control c in mainPanel.Controls)
                {
                    c.BackColor = Color.LightGreen;
                }
            }
            else
            {
                mainPanel.BackColor = Color.IndianRed;
                foreach (Control c in mainPanel.Controls)
                {
                    c.BackColor = Color.IndianRed;
                }
            }
            return isRight;
        }

        private string CreateMaskOfAnswer(int answer, int shift)
        {
            string mask = "";
            for (int i = 0; i < difficulty * countOfMultipliers; i++)
            {
                mask += "0";
            }
            string strAnswer = answer.ToString();
            for (int i = strAnswer.Length - 1; i >= 0; i--)
            {
                mask = mask.Remove(mask.Length - 1 - i - shift, 1).Insert(mask.Length - 1 - i - shift, "1");
            }
            return mask;
        }

        private int ReadCellsToInt(string cellsPanelName, string mask)
        {
            int readed = 0;
            for (int i = 0; i < difficulty * countOfMultipliers; i++)
            {
                int temp;
                if (!int.TryParse(mainPanel.Controls[cellsPanelName].Controls[i.ToString()].Text, out temp))
                {
                    if (mask[mask.Length - 1 - i].ToString() == "0")
                        temp = 0;
                    else temp = -1;
                }
                readed += (int)(temp * Math.Pow(10, i));
            }
            return readed;
        }

        public void Justify(RichTextBox richTextBox)
        {
            string text = richTextBox.Text;
            string[] lines = text.Split(new[] { "\r\n" }, StringSplitOptions.None).Select(l => l.Trim()).ToArray();

            List<string> result = new List<string>();

            foreach (string line in lines)
            {
                result.Add(StretchToWidth(line, richTextBox));
            }

            richTextBox.Text = string.Join("\r\n", result);
        }

        private string StretchToWidth(string text, RichTextBox richTextBox)
        {
            if (text.Length < 2)
                return text;

            const char hairspace = '\u200A';

            double basewidth = TextRenderer.MeasureText(text, richTextBox.Font).Width;
            double doublewidth = TextRenderer.MeasureText(text + text, richTextBox.Font).Width;
            double doublewidthplusspace = TextRenderer.MeasureText(text + hairspace + text, richTextBox.Font).Width;
            double spacewidth = doublewidthplusspace - doublewidth;


            double leftoverspace = richTextBox.Width - basewidth;

            int approximateInserts = Math.Max(0, (int)Math.Floor(leftoverspace / spacewidth));

            return InsertFillerChar(hairspace, text, approximateInserts);
        }

        private static string InsertFillerChar(char filler, string text, int inserts)
        {
            string result = "";
            int inserted = 0;

            for (int i = 0; i < text.Length; i++)
            {
                result += text[i];

                if (i >= text.Length - 1) continue;

                int shouldbeinserted = (int)(inserts * (i + 1) / (text.Length - 1.0));
                int insertnow = shouldbeinserted - inserted;
                for (int j = 0; j < insertnow; j++)
                    result += filler;
                inserted += insertnow;
            }

            return result;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            bool isRight = Check(indexOfCurrentProblem);
            if (isRight)
            {
                rightAnswers.Add(indexOfCurrentProblem);
            }
            Progress(indexOfCurrentProblem, isRight);
            indexOfCurrentProblem++;
            if (indexOfCurrentProblem >= countOfProblems)
            {
                GradeMessageBox();
                Reset(difficulty);
            }
            mainPanel.BackColor = SystemColors.Control;
            Display(indexOfCurrentProblem);
        }

        private void ResetProgress()
        {
            richTextBoxProgress.Text = "";
            richTextBoxProgress.ForeColor = SystemColors.Control;
            for (int i = 0; i < countOfProblems; i++)
            {
                richTextBoxProgress.AppendText("* ");
            }
            richTextBoxProgress.Text = richTextBoxProgress.Text.Trim();
            Justify(richTextBoxProgress);
        }
        private void Progress(int index, bool isRight)
        {
            Color right = Color.Green;
            Color wrong = Color.Red;
            richTextBoxProgress.Select(findStartPosition(richTextBoxProgress.Text, "*", this.indexOfCurrentProblem), 1);
            if (isRight) richTextBoxProgress.SelectionColor = right;
            else richTextBoxProgress.SelectionColor = wrong;
            richTextBoxProgress.DeselectAll();
        }
        private int findStartPosition(string text, string character, int count)
        {
            int index = 0;
            while (count > 0)
            {
                index = text.IndexOf(character, index + 1);
                count--;
            }
            return index;
        }
        private void GradeMessageBox()
        {
            string gradeString = "";
            switch (rightAnswers.Count)
            {
                case 8:
                    gradeString = "Молодец";
                    break;
                case 7:
                case 6:
                    gradeString = "Хорошо";
                    break;
                case 5:
                case 4:
                    gradeString = "Надо стараться";
                    break;
                default:
                    gradeString = "Плохо";
                    break;
            }
            MessageBox.Show("Твое достижение - " + gradeString + "\nПравильных ответов " + rightAnswers.Count + " из " + problems.Count, "Оценка");
        }
    }
}
