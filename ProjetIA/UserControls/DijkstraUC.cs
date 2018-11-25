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
        private NumNode initNode;
        private SearchTree dijSolver;
        private List<List<GenericNode>> OpenedClosedTracker;
        private List<List<string>> AnswersOpenedClosed;
        
        public DijkstraUC(IndexForm _mainForm)
        {

            InitializeComponent();
            mainForm = _mainForm;

            currentGraph = new Graph();
            dijSolver = new SearchTree();

            initNode = new NumNode(currentGraph.InitNode, currentGraph);
            OpenedClosedTracker = dijSolver.DijkstraSolve(currentGraph, initNode);
            AnswersOpenedClosed = new List<List<string>>();          
        }

        private void DijkstraUC_Load(object sender, EventArgs e)
        {
            mainForm.LoadImage(currentGraph.imgPath, imgGraph);

            bool emptyTree = true;
            dijSolver.GetSearchTree(treeViewDijkstra, emptyTree);
            treeViewDijkstra.ExpandAll();

            treeViewDijkstra.LabelEdit = true;

            dataGridViewOuvertsFermes.Columns.Add("Opened", "Ouverts");
            dataGridViewOuvertsFermes.Columns.Add("Closed", "Fermés");
            dataGridViewOuvertsFermes.Rows.Add(initNode.ToString(), "");
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
            CheckTreeAnswers();
        }

        private string FormatAnswer(string answer)
        {
            char[] alphabet = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G',
                'H', 'I', 'J', 'K', 'L', 'M', 'O',
                'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                'W', 'X', 'Y', 'Z'
            };

            List<char> answerBreakdown = answer.ToUpper().ToList();
            string answerChecked = "";

            foreach (char c in answerBreakdown)
            {
                if (alphabet.Contains(c))
                    answerChecked += c.ToString();
            }

            return answerChecked;
        }

        private bool[] CheckOpenedClosedAnswer(List<string> answeredNodes, List<GenericNode> correctOpenedNodes, List<GenericNode> correctClosedNodes)
        {
            bool[] areCorrectOpenedClosed = new bool[] { true, true };

            string openedId = "";
            string closedId = "";

            foreach (GenericNode gn in correctOpenedNodes)
                openedId += gn.ToString();
            foreach (GenericNode gn in correctClosedNodes)
                closedId += gn.ToString();

            if (answeredNodes[0].Count() != openedId.Count() || !answeredNodes[0].Contains(openedId))
                areCorrectOpenedClosed[0] = false;
            if (answeredNodes[1].Count() != closedId.Count() || !answeredNodes[1].Contains(closedId))
                areCorrectOpenedClosed[1] = false;

            return areCorrectOpenedClosed;
        }

        private void submitNode_Click(object sender, EventArgs e)
        {
            if(textBoxNode.Text != null && treeViewDijkstra.SelectedNode != null)
            {
                treeViewDijkstra.SelectedNode.Text = FormatAnswer(textBoxNode.Text);
            }
        }

        private void treeViewDijkstra_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeViewDijkstra.SelectedNode.Text != "...")
                textBoxNode.Text = treeViewDijkstra.SelectedNode.Text;
            else
                textBoxNode.Text = null;
        }

        private bool CheckTreeAnswers()
        {
            bool emptyTree = false;
            TreeView treeViewCorrection = new TreeView();
            dijSolver.GetSearchTree(treeViewCorrection, emptyTree);

            List<TreeNodeCollection> answeredNodes = new List<TreeNodeCollection>();
            List<TreeNodeCollection> correctNodes = new List<TreeNodeCollection>();
            GetAllNodes(treeViewDijkstra.Nodes, answeredNodes);
            GetAllNodes(treeViewCorrection.Nodes, correctNodes);

            bool isCorrect = true;

            for(int i = 0; i < answeredNodes.Count(); i++)
            {
                for(int j = 0; j < answeredNodes[i].Count; j++)
                {
                    if (answeredNodes[i][j].Text != correctNodes[i][j].Text)
                    {
                        answeredNodes[i][j].ForeColor = Color.Red;
                        answeredNodes[i][j].Text += " -> " + correctNodes[i][j].Text;
                        isCorrect = false;
                    }
                    else
                        answeredNodes[i][j].ForeColor = Color.Green;
                }
            }

            return isCorrect;
        }

        private void GetAllNodes(TreeNodeCollection nodes, List<TreeNodeCollection> nodesList)
        {
            nodesList.Add(nodes);

            foreach (TreeNode tn in nodes)
            {
                if (tn.Nodes != null)
                { 
                    GetAllNodes(tn.Nodes, nodesList);
                }
                else
                    return;
            }
        }
    }
}
