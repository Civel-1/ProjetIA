using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetIA;

namespace Dijkstra_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph currentGraph = new Graph();
            SearchTree DijSolver = new SearchTree();
            AlphaBetNode initNode = new AlphaBetNode(currentGraph.InitNode, currentGraph);
            List<List<GenericNode>> OpenedClosedStates = DijSolver.DijkstraSolve(currentGraph, initNode);

            foreach(List<GenericNode> lGnode in OpenedClosedStates)
            {
                foreach(GenericNode n in lGnode)
                {
                    Console.Write(n.Num.ToString());
                }

                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}
