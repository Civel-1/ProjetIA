using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA
{
    /// <summary>
    /// Classe héritant de GenericNode. Représente des noeuds identifiés par des lettres.
    /// </summary>
    public class AlphaBetNode : GenericNode
    {
        public AlphaBetNode(int num, Graph graph) : base (num, graph) { }

        public override bool IsEqual(GenericNode genNode)
        {
            AlphaBetNode alphaNode = (AlphaBetNode)genNode;
            return Num == alphaNode.Num;
        }

        /// <summary>
        /// Cout de l'arc séparant le noeud courant du GenericNode genNode.
        /// </summary>
        /// <param name="genNode"></param>
        /// <returns></returns>
        public override double GetArcCost(GenericNode genNode)
        {
            AlphaBetNode alphaNode = (AlphaBetNode)genNode;
            return graph.AdjacentMatrix[Num, alphaNode.Num];
        }

        /// <summary>
        /// Obtient la liste des GenericNode successeurs du noeud courant dans le graphe graph, à partir de la matrice d'adjacence graph.AdjacentMatrix.
        /// </summary>
        /// <returns></returns>
        public override List<GenericNode> GetSuccessors()
        {
            List<GenericNode> successors = new List<GenericNode>();

            for (int i = 0; i < graph.NbNodes; i++)
            {
                if (graph.AdjacentMatrix[Num, i] != -1)
                {
                    AlphaBetNode successor = new AlphaBetNode(i, graph);
                    successors.Add(successor);
                }
            }
            return successors;
        }

        /// <summary>
        /// Cout heuristique nul. Méthode de Dijkstra.
        /// </summary>
        /// <returns></returns>
        public override double CalculateHCost()
        {
            return (0);
        }

        public override bool GetEndState()
        {
            return (Num == graph.EndNode);
        }

        //ToString() renvoie l'identifiant alphabétique correspondant à l'identifiant numérique des AlphaBetNodes.
        public override string ToString()
        {
            char[] alphabet = new char[]
            {
            'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z'
            };

            return Convert.ToString(alphabet[Num]);
        }
    }
}
