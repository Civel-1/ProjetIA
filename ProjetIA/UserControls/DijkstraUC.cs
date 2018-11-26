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
    /// <summary>
    /// Cet UC affiche un ensemble de contrôle permettant à l'utilisateur de résoudre un problème
    /// de plus court chemin à l'aide de l'algorithme de Dijkstra, et d'en obtenir la correction
    /// générée par un algorithme de résolution programmé.
    /// </summary>
    public partial class DijkstraUC : UserControl
    {
        private IndexForm mainForm;

        /// <summary>
        /// Instance du graphe modélisant le problème soumis à l'utilisateur.
        /// </summary>
        private Graph currentGraph;
        /// <summary>
        /// Noeud de départ du problème.
        /// </summary>
        private NumNode initNode;
        /// <summary>
        /// Noeud d'arrivée (résolution du problème).
        /// </summary>
        private NumNode endNode;
        private SearchTree dijSolver;
        /// <summary>
        /// Liste contenant les listes d'ouverts et de fermés successivement générées par 
        /// le SearchTree. Les ouverts se toruvent en index pair, les fermés en index impair.
        /// </summary>
        private List<List<GenericNode>> openedClosedTracker;
        private EvaluationResult evalResult;
        
        public DijkstraUC(IndexForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;

            currentGraph = new Graph();
            dijSolver = SearchTree.Instance;

            initNode = new NumNode(currentGraph.InitNode, currentGraph);
            endNode = new NumNode(currentGraph.EndNode, currentGraph);

            //Obtention des listes d'ouverts et de fermés successifs générées par le solveur appliqué 
            //sur le graphe courant.
            openedClosedTracker = dijSolver.DijkstraSolve(currentGraph, initNode);

            evalResult = EvaluationResult.Instance;
            evalResult.DijkstraStatus = EvaluationResult.Status.In_Progress;
        }

        private void DijkstraUC_Load(object sender, EventArgs e)
        {
            mainForm.LoadImage(currentGraph.imgPath, imgGraph);

            bool emptyTree = true;
            dijSolver.GetSearchTree(treeViewDijkstra, emptyTree);
            treeViewDijkstra.ExpandAll();

            //Le remplissage du TreeView par l'utilisateur se fait à l'aide du submitNode button.
            treeViewDijkstra.LabelEdit = false;

            dataGridViewOuvertsFermes.Columns.Add("Opened", "Ouverts");
            dataGridViewOuvertsFermes.Columns.Add("Closed", "Fermés");
            dataGridViewOuvertsFermes.Rows.Add(initNode.ToString(), "");

            labelEndNode.Text = endNode.ToString();
        }

        /// <summary>
        /// Insertion d'ouverts et de fermés par l'utilisateur dans le DataGridView récapitulatif.
        /// </summary>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //index 0 : ouverts, index 1 : fermés
            string[] openedClosedSubmitted = new string[2];

            if (textBoxOuverts.Text != "" || textBoxFermes.Text != "")
            {
                openedClosedSubmitted[0] = FormatAnswer(textBoxOuverts.Text);
                openedClosedSubmitted[1] = FormatAnswer(textBoxFermes.Text);

                dataGridViewOuvertsFermes.Rows.Add(openedClosedSubmitted);
            }

            textBoxOuverts.Clear();
            textBoxFermes.Clear();
        }

        /// <summary>
        /// Fin de l'évaluation, l'utilisateur estime avoir terminé.
        /// </summary>
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            bool isTreeCorrect = CheckTreeAnswers();
            bool isOpenedClosedCorrect = CheckOpenedClosedAnswer();

            evalResult.resultDijkstra = 0;

            //Rappel notaion : 2 points pour les listes d'ouverts et de fermés, 1 point 
            //pour l'arbre de recherche. 0 point en cas d'erreur0
            if (isOpenedClosedCorrect)
                evalResult.resultDijkstra += 2;
            if (isTreeCorrect)
                evalResult.resultDijkstra += 1;
            
            evalResult.DijkstraStatus = EvaluationResult.Status.Done;

            InactivateInteractions();
        }

        /// <summary>
        /// Remplissage d'un noeud vide dans le TreeView
        /// </summary>
        private void submitNode_Click(object sender, EventArgs e)
        {
            if(textBoxNode.Text != null && treeViewDijkstra.SelectedNode != null)
                treeViewDijkstra.SelectedNode.Text = FormatAnswer(textBoxNode.Text);         
        }

        /// <summary>
        /// Rémanence du noeud sélectionné dans la textBox d'insertion de noeud dans le TreeView.
        /// </summary>
        private void treeViewDijkstra_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeViewDijkstra.SelectedNode.Text != "...")
                textBoxNode.Text = treeViewDijkstra.SelectedNode.Text;
            else
                textBoxNode.Text = null;
        }

        /// <summary>
        /// Corrige les réponses données par l'utilisateur dans le TreeView. Retourne un booléen
        /// validant ou non la justesse des réponses.
        /// </summary>
        private bool CheckTreeAnswers()
        {
            //Récupération d'un arbre de recherche correctement rempli par le solveur SearchTree.
            bool emptyTree = false;
            TreeView treeViewCorrection = new TreeView();
            dijSolver.GetSearchTree(treeViewCorrection, emptyTree);

            //Récupération des noeuds des SearchTree. Nécessite l'utilisation de méthodes récursives.
            List<TreeNodeCollection> answeredNodes = new List<TreeNodeCollection>();
            List<TreeNodeCollection> correctNodes = new List<TreeNodeCollection>();

            GetAllNodes(treeViewDijkstra.Nodes, answeredNodes);
            GetAllNodes(treeViewCorrection.Nodes, correctNodes);

            bool isCorrect = true;

            //Affichage de la correction sur le TreeView.
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

        /// <summary>
        /// Enumère l'ensemble des noeuds d'un TreeView à partir d'un de ses noeuds 
        /// et les stocke dans une liste de collection de noeuds.
        /// </summary>
        private void GetAllNodes(TreeNodeCollection nodes, List<TreeNodeCollection> nodesList)
        {
            nodesList.Add(nodes);

            //Parcours récursif du TreeView (collections chaînées de TreeNodes)
            foreach (TreeNode tn in nodes)
            {
                if (tn.Nodes != null) 
                    GetAllNodes(tn.Nodes, nodesList);
                else
                    return;
            }
        }

        /// <summary>
        /// Corrige les réponses données par l'utilisateur dans le DataGridView sur les ouverts et les fermés. Retourne un booléen
        /// validant ou non la justesse des réponses.
        /// </summary>
        /// <returns></returns>
        private bool CheckOpenedClosedAnswer()
        {
            bool isCorrect = true;

            //Récupération des identifiants alphabétiques des noeuds des ouverts et des fermés corrects générés par le solveur.
            //Les comparaisons s'effectuent sur les valeurs de ces identifiants.
            List<string> openedClosedIdTracker = GetNodesTrackerId(openedClosedTracker);

            //Index maximal possible pour parcourir conjointement le DataGridView et la liste d'ouverts et de fermés corrects.
            int indexMax = Math.Min(dataGridViewOuvertsFermes.RowCount, openedClosedIdTracker.Count);

            //Affichage de la correction
            for(int i = 0; i < indexMax; i++)
            {
                for (int j = 0; j < dataGridViewOuvertsFermes.ColumnCount; j++)
                {
                    //Les ouverts sont en première colonne du DataGridView et en index pair dans la liste d'ouverts et de fermés corrects.
                    //Les fermés sont en seconde colonne du DataGridView et en index impair dans la liste d'ouverts et de fermés corrects.
                    if (!(dataGridViewOuvertsFermes.Rows[i].Cells[j].Value as string).Contains(openedClosedIdTracker[2 * i + j]))
                    {
                        dataGridViewOuvertsFermes.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        isCorrect = false;
                    }
                    else
                        dataGridViewOuvertsFermes.Rows[i].Cells[j].Style.ForeColor = Color.Green;
                }
            }

            //Si l'utilisateur n'a pas rentré le nombre correct de listes d'ouverts et de fermés, c'est incorrect.
            if(indexMax != dataGridViewOuvertsFermes.RowCount || indexMax != openedClosedIdTracker.Count)
            {
                isCorrect = false;
                //Si il en a entré trop
                if (indexMax < dataGridViewOuvertsFermes.RowCount)
                {
                    //Toutes les listes excédentaires sont corrigées en rouge
                    for (int i = indexMax; i < dataGridViewOuvertsFermes.RowCount; i++)
                        for (int j = 0; j < dataGridViewOuvertsFermes.ColumnCount; j++)
                            dataGridViewOuvertsFermes.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                }               
            }

            return isCorrect;
        }

        /// <summary>
        /// Retourne la liste des identifiants des noeuds compris dans la liste des ouverts et fermés
        /// générée par le solveur. Ici, ce sont des lettres de l'alphabet.
        /// </summary>
        private List<string> GetNodesTrackerId(List<List<GenericNode>> nodesTracker)
        {
            List<string> nodesIdTracker = new List<string>();

            foreach (List<GenericNode> gnList in nodesTracker)
            {
                string nodesId = "";

                foreach (GenericNode gn in gnList)
                    nodesId += gn.ToString();

                 nodesIdTracker.Add(nodesId);
            }

            return nodesIdTracker;
        }

        /// <summary>
        /// Formate les réponses entrées au clavier par l'utilisateur. Les caractères sont convertis
        /// en lettres haut-de-casse ou rejetés.
        /// </summary>
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

        /// <summary>
        /// Inactive les contrôles de l'UC à la fin de l'évaluation. Vide les textBox.
        /// </summary>
        private void InactivateInteractions()
        {
            dataGridViewOuvertsFermes.Enabled = false;
            treeViewDijkstra.ExpandAll();
            treeViewDijkstra.Enabled = false;
            textBoxFermes.Enabled = false;
            textBoxFermes.Text = null;
            textBoxOuverts.Enabled = false;
            textBoxOuverts.Text = null;
            textBoxNode.Enabled = false;
            textBoxNode.Text = null;
            buttonSubmit.Enabled = false;
            submitNode.Enabled = false;
        }
    }
}
