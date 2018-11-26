using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA
{
    /// <summary>
    /// Classe singleton permettant d'obtenir un solveur de problème de plus court chemin. Ce solveur utilise 
    /// l'algorithme de Dijkstra.
    /// </summary>
    public class SearchTree
    {
        /// <summary>
        /// Liste des ouverts.
        /// </summary>
        public List<GenericNode> OpenedNodes { get; set; }
        /// <summary>
        /// Liste des fermés.
        /// </summary>
        public List<GenericNode> ClosedNodes { get; set; }
        private static SearchTree instance;

        /// <summary>
        /// Instance unique de SearchTree.
        /// </summary>
        public static SearchTree Instance
        {
            get
            {
                if (instance == null)
                    instance = new SearchTree();

                return instance;
            }
        }

        /// <summary>
        /// Renvoie le noeud clone trouvé dans les fermés.
        /// </summary>
        private GenericNode SearchInClosed(GenericNode node)
        {
            int i = 0;

            while (i < ClosedNodes.Count)
            {
                if (ClosedNodes[i].IsEqual(node))
                    return ClosedNodes[i];
                i++;
            }
            return null;
        }

        /// <summary>
        /// Renvoie le noeud clone trouvé dans les ouverts.
        /// </summary>
        private GenericNode SearchInOpened(GenericNode node)
        {
            int i = 0;

            while (i < OpenedNodes.Count)
            {
                if (OpenedNodes[i].IsEqual(node))
                    return OpenedNodes[i];
                i++;
            }
            return null;
        }

        /// <summary>
        /// Résout un problème de plus court chemin à l'aide de l'algorithme de Dijkstra.
        /// La méthode parcourt un graphe graph à partir d'un noeud initital initNode.
        /// Elle renvoie un tracker des différentes listes d'ouverts et de fermés produites à chaque étape 
        /// de recherche. 
        /// </summary>
        public List<List<GenericNode>> DijkstraSolve(Graph graph, GenericNode initNode)
        {
            List<List<GenericNode>> OpenedClosedTracker = new List<List<GenericNode>>();

            OpenedNodes = new List<GenericNode>();
            ClosedNodes = new List<GenericNode>();

            // Le noeud passé en paramètre est supposé être le noeud initial
            GenericNode node = initNode;
            OpenedNodes.Add(initNode);

            OpenedClosedTracker.Add(Clone(OpenedNodes));
            OpenedClosedTracker.Add(Clone(ClosedNodes));

            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (OpenedNodes.Count != 0 && node.GetEndState() == false)
            {
                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                OpenedNodes.Remove(node);
                ClosedNodes.Add(node);

                // Il faut trouver les noeuds successeurs de node
                this.UpdateSuccessors(node);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre

                OpenedClosedTracker.Add(Clone(OpenedNodes));
                OpenedClosedTracker.Add(Clone(ClosedNodes));

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (OpenedNodes.Count > 0)
                    node = OpenedNodes[0];
                else
                    node = null;
            }

            // Dijstra terminé.

            return OpenedClosedTracker;
        }

        private void UpdateSuccessors(GenericNode node)
        {
            // On fait appel à GetListSucc, méthode abstraite qu'on doit réécrire pour chaque
            // problème. Elle doit retourner la liste complète des noeuds successeurs de N.
            List<GenericNode> successors = node.GetSuccessors();

            foreach (GenericNode successorNode in successors)
            {
                // N2 est-il une copie d'un nœud déjà vu et placé dans la liste des fermés ?
                GenericNode closedSuccessor = SearchInClosed(successorNode);

                if (closedSuccessor == null)
                {
                    // Rien dans les fermés. Est-il dans les ouverts ?
                    GenericNode openedSuccessor = SearchInOpened(successorNode);

                    if (openedSuccessor != null)
                    {
                        // Il existe, donc on l'a déjà vu, N2 n'est qu'une copie de N2Bis
                        // Le nouveau chemin passant par N est-il meilleur ?
                        if (node.GCost + node.GetArcCost(successorNode) < openedSuccessor.GCost)
                        {
                            // Mise à jour de N2bis
                            // somme de GCost et HCost effectuée à la mise à jour de GCost
                            openedSuccessor.GCost = node.GCost + node.GetArcCost(successorNode);
                            // HCost pas recalculé car toujours bon                       
                            // Mise à jour de la famille ....
                            openedSuccessor.FlushParent();
                            openedSuccessor.ParentNode = node;
                            // Mise à jour des ouverts
                            OpenedNodes.Remove(openedSuccessor);
                            this.InsertNewNodeInOpenList(openedSuccessor);
                        }
                        // else on ne fait rien, car le nouveau chemin est moins bon
                    }
                    else
                    {
                        // N2 est nouveau, MAJ et insertion dans les ouverts
                        successorNode.GCost = node.GCost + node.GetArcCost(successorNode);
                        successorNode.ParentNode = node;
                        this.InsertNewNodeInOpenList(successorNode);
                    }
                }
                // else il est dans les fermés donc on ne fait rien,
                // car on a déjà trouvé le plus court chemin pour aller en N2
            }
        }

        public void InsertNewNodeInOpenList(GenericNode NewNode)
        {
            // Insertion pour respecter l'ordre du cout total le plus petit au plus grand
            if (this.OpenedNodes.Count == 0)
                OpenedNodes.Add(NewNode);
            
            else
            {
                GenericNode genNode = OpenedNodes[0];
                bool found = false;
                int i = 0;
                do
                    if (NewNode.TotCost < genNode.TotCost)
                    {
                        OpenedNodes.Insert(i, NewNode);
                        found = true;
                    }
                    else
                    {
                        i++;
                        if (OpenedNodes.Count == i)
                        {
                            genNode = null;
                            OpenedNodes.Insert(i, NewNode);
                        }
                        else
                        { genNode = OpenedNodes[i]; }
                    }
                while ((genNode != null) && (found == false));
            }
        }

       /// <summary>
       /// Rempli un TreeView avec l'abre de recherche de l'algorithme de Dijkstra. Peut renvoyer un arbre sans texte 
       /// ou disposant à chaque noeud un identifiant alphabétique.
       /// </summary>
       /// <param name="isEmpty">si true, la méthode renvoie un arbre sans texte.</param>
        public void GetSearchTree(TreeView treeView, bool isEmpty)
        {
            if (ClosedNodes == null) return;
            if (ClosedNodes.Count == 0) return;

            // On suppose le TreeView préexistant
            treeView.Nodes.Clear();

            TreeNode treeNode;
            if (isEmpty)
                treeNode = new TreeNode("...");
            else
                treeNode = new TreeNode(ClosedNodes[0].ToString());

            treeView.Nodes.Add(treeNode);

            AddBranch(ClosedNodes[0], treeNode, isEmpty);
        }

        // AjouteBranche est exclusivement appelée par GetSearchTree; les noeuds sont ajoutés de manière récursive
        private void AddBranch(GenericNode genNode, TreeNode treeNode, bool isEmpty)
        {
            foreach (GenericNode childNode in genNode.Children)
            {
                TreeNode childTreeNode;

                if(isEmpty)
                   childTreeNode = new TreeNode("...");
                else
                    childTreeNode = new TreeNode(childNode.ToString());

                treeNode.Nodes.Add(childTreeNode);
                if (childNode.Children.Count > 0)
                    AddBranch(childNode, childTreeNode, isEmpty);
            }
        }

        /// <summary>
        /// Copie les références vers les noeuds d'une liste dans une autre.
        /// </summary>
        private List<GenericNode> Clone(List<GenericNode> initialList)
        {
            List<GenericNode> newList = new List<GenericNode>();

            foreach (GenericNode n in initialList)
                newList.Add(n);

            return newList;
        }
    }
}
