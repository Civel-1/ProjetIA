using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA
{
    public class NumNode : GenericNode
    {
        public NumNode(int num, Graph graph) : base (num, graph) { }

        public override bool IsEqual(GenericNode genNode)
        {
            NumNode numNode = (NumNode)genNode;
            return Num == numNode.Num;
        }

        /// <summary>
        /// Cout de l'arc séparant le noeud courant du GenericNode genNode.
        /// </summary>
        /// <param name="genNode"></param>
        /// <returns></returns>
        public override double GetArcCost(GenericNode genNode)
        {
            NumNode numNode = (NumNode)genNode;
            return graph.AdjacentMatrix[Num, numNode.Num];
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
                    NumNode successor = new NumNode(i, graph);
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

        public override string ToString()
        {
            return Convert.ToString(Num);
        }
    }
}
