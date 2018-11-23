using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA.UserControls
{
    public partial class DijkstraUC : UserControl
    {
        private IndexForm mainForm;
        private Graph currentGraph;
        private SearchTree DijSolver;
        private List<List<GenericNode>> OpenedClosedTracker;
        private List<List<string>> AnswersOpenedClosed;
        private char[] alphabet = new char[] 
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z'
        };

        public DijkstraUC(IndexForm _mainForm)
        {

            InitializeComponent();
            mainForm = _mainForm;

            currentGraph = new Graph();
            DijSolver = new SearchTree();

            NumNode initNode = new NumNode(currentGraph.InitNode, currentGraph);
            List<List<GenericNode>> OpenedClosedTracker = DijSolver.DijkstraSolve(currentGraph, initNode);

            List<List<string>> AnswersOpenedClosed = new List<List<string>>();          
        }

        private void DijkstraUC_Load(object sender, EventArgs e)
        {
            mainForm.LoadImage(currentGraph.imgPath, imgGraph);

            dataGridViewOuvertsFermes.Columns.Add("Opened", "Ouverts");
            dataGridViewOuvertsFermes.Columns.Add("Closed", "Fermés");
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string[] openedClosedSubmitted = new string[2];

            if (textBoxOuverts.Text != "" || textBoxFermes.Text != "")
            {
                openedClosedSubmitted[0] = FormatAnswer(textBoxOuverts.Text);
                openedClosedSubmitted[1] = FormatAnswer(textBoxFermes.Text);

                dataGridViewOuvertsFermes.Rows.Add(openedClosedSubmitted);

                AnswersOpenedClosed.Add(new List<string>() { openedClosedSubmitted[0], openedClosedSubmitted[1] });
            }

            textBoxOuverts.Clear();
            textBoxFermes.Clear();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            
        }

        private string FormatAnswer(string answer)
        {
            List<char> answerBreakdown = answer.ToUpper().ToList();
            string answerChecked = "";

            foreach (char c in answerBreakdown)
            {
                if (alphabet.Contains(c))
                    answerChecked += c.ToString() + " ";
            }

            return answerChecked;
        }

        private bool[] CheckAnswer(List<string> answeredNodes, List<GenericNode> correctOpenedNodes, List<GenericNode> correctClosedNodes)
        {
            bool[] areCorrectOpenedClosed = new bool[] { true, true };

            string OpenedId = "";
            string ClosedId = "";



            return areCorrectOpenedClosed;
        }
    }
}
