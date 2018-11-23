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
            
            StartEvaluating();
        }

        public void StartEvaluating()
        {
            dataGridViewOuvertsFermes.Columns.Add("Opened", "Ouverts");
            dataGridViewOuvertsFermes.Columns.Add("Closed", "Fermés");

            NumNode initNode = new NumNode(currentGraph.InitNode, currentGraph);
            List<List<GenericNode>> OpenedClosedStates = DijSolver.DijkstraSolve(currentGraph, initNode);
        }

        private void DijkstraUC_Load(object sender, EventArgs e)
        {
            mainForm.LoadImage(currentGraph.imgPath, imgGraph);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string[] openedClosedSubmitted = new string[2];

            if (textBoxOuverts.Text != "" || textBoxFermes.Text != "")
            {
                openedClosedSubmitted[0] = AnswerFormatCheck(textBoxOuverts.Text);
                openedClosedSubmitted[1] = AnswerFormatCheck(textBoxFermes.Text);

                dataGridViewOuvertsFermes.Rows.Add(openedClosedSubmitted);
            }

            textBoxOuverts.Clear();
            textBoxFermes.Clear();
        }

        private string AnswerFormatCheck(string answer)
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
    }
}
