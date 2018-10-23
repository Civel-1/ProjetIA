using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA
{
    class SearchTree
    {
        public List<GenericNode> OpenedNodes;
        public List<GenericNode> ClosedNodes;

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

        public List<GenericNode> AStarSolve(GenericNode initNode)
        {
            OpenedNodes = new List<GenericNode>();
            ClosedNodes = new List<GenericNode>();

            // Le noeud passé en paramètre est supposé être le noeud initial
            GenericNode node = initNode;
            OpenedNodes.Add(initNode);

            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (OpenedNodes.Count != 0 && node.EndState == false)
            {
                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                OpenedNodes.Remove(node);
                ClosedNodes.Add(node);

                // Il faut trouver les noeuds successeurs de N
                this.UpdateSuccessors(node);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (OpenedNodes.Count > 0)
                {
                    node = OpenedNodes[0];
                }
                else
                {
                    node = null;
                }
            }

            // A* terminé
            // On retourne le chemin qui va du noeud initial au noeud final sous forme de liste
            // Le chemin est retrouvé en partant du noeud final et en accédant aux parents de manière
            // itérative jusqu'à ce qu'on tombe sur le noeud initial

            List<GenericNode> path = new List<GenericNode>();
            if (node != null)
            {
                path.Add(node);

                while (node != initNode)
                {
                    node = node.ParentNode;
                    path.Insert(0, node);  // On insère en position 1
                }
            }
            return path;
        }

        private void UpdateSuccessors(GenericNode node)
        {
            // On fait appel à GetListSucc, méthode abstraite qu'on doit réécrire pour chaque
            // problème. Elle doit retourner la liste complète des noeuds successeurs de N.
            List<GenericNode> successors = node.GetListSucc();

            foreach (GenericNode successorNode in successors)
            {
                // N2 est-il une copie d'un nœud déjà vu et placé dans la liste des fermés ?
                GenericNode N2bis = SearchInClosed(successorNode);

                if (N2bis == null)
                {
                    // Rien dans les fermés. Est-il dans les ouverts ?
                    N2bis = SearchInOpened(successorNode);
                    if (N2bis != null)
                    {
                        // Il existe, donc on l'a déjà vu, N2 n'est qu'une copie de N2Bis
                        // Le nouveau chemin passant par N est-il meilleur ?
                        if (node.GetGCost() + node.GetArcCost(successorNode) < N2bis.GetGCost())
                        {
                            // Mise à jour de N2bis
                            N2bis.SetGCost(node.GetGCost() + node.GetArcCost(successorNode));
                            // HCost pas recalculé car toujours bon
                            N2bis.RecalculeCoutTotal(); // somme de GCost et HCost
                            // Mise à jour de la famille ....
                            N2bis.Supprime_Liens_Parent();
                            N2bis.SetNoeud_Parent(node);
                            // Mise à jour des ouverts
                            OpenedNodes.Remove(N2bis);
                            this.InsertNewNodeInOpenList(N2bis);
                        }
                        // else on ne fait rien, car le nouveau chemin est moins bon
                    }
                    else
                    {
                        // N2 est nouveau, MAJ et insertion dans les ouverts
                        successorNode.SetGCost(node.GetGCost() + node.GetArcCost(successorNode));
                        successorNode.SetNoeud_Parent(node);
                        successorNode.calculCoutTotal(); // somme de GCost et HCost
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
            { OpenedNodes.Add(NewNode); }
            else
            {
                GenericNode N = OpenedNodes[0];
                bool trouve = false;
                int i = 0;
                do
                    if (NewNode.Cout_Total < N.Cout_Total)
                    {
                        OpenedNodes.Insert(i, NewNode);
                        trouve = true;
                    }
                    else
                    {
                        i++;
                        if (OpenedNodes.Count == i)
                        {
                            N = null;
                            OpenedNodes.Insert(i, NewNode);
                        }
                        else
                        { N = OpenedNodes[i]; }
                    }
                while ((N != null) && (trouve == false));
            }
        }

        // Si on veut afficher l'arbre de recherche, il suffit de passer un treeview en paramètres
        // Celui-ci est mis à jour avec les noeuds de la liste des fermés, on ne tient pas compte des ouverts
        public void GetSearchTree(TreeView TV)
        {
            if (ClosedNodes == null) return;
            if (ClosedNodes.Count == 0) return;

            // On suppose le TreeView préexistant
            TV.Nodes.Clear();

            TreeNode TN = new TreeNode(ClosedNodes[0].ToString());
            TV.Nodes.Add(TN);

            AjouteBranche(ClosedNodes[0], TN);
        }

        // AjouteBranche est exclusivement appelée par GetSearchTree; les noeuds sont ajoutés de manière récursive
        private void AjouteBranche(GenericNode GN, TreeNode TN)
        {
            foreach (GenericNode GNfils in GN.GetEnfants())
            {
                TreeNode TNfils = new TreeNode(GNfils.ToString());
                TN.Nodes.Add(TNfils);
                if (GNfils.GetEnfants().Count > 0) AjouteBranche(GNfils, TNfils);
            }
        }

    }
}
